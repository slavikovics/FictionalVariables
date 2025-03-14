using System.Text;

namespace LogicalParser;

public class Table
{
    private List<int> ColumnSizes { get; set; }

    public string Content;

    private int _length;

    public Table(List<string> formulas, List<Dictionary<string, bool>> options)
    {        
        Content = "";
        ColumnSizes = new List<int>();
        BuildHeading(formulas);
        BuildBody(options, formulas);
    }

    public Table(string input)
    {
        Content = "";
        var variables = FormulaParser.FindAllPropositionalVariables(input);
        var formulas = new List<string>();
        FormulaParser.Parse(input, formulas);
        var options = OptionsBuilder.BuildOptions(variables);
        ColumnSizes = new List<int>();
        BuildHeading(variables.Concat(formulas).ToList());
        BuildBody(options, variables.Concat(formulas).ToList());
    }

    private void BuildHeading(List<string> formulas)
    { 
        _length = 0;
        
        foreach (var formula in formulas)
        {
            _length += formula.Length + 2;
            ColumnSizes.Add(formula.Length + 2);
        }
        
        Content = new string(' ', _length) + "\n";
        foreach (var formula in formulas) Content += $" {formula} ";
        Content += "\n";
    }

    private void BuildBody(List<Dictionary<string, bool>> options, List<string> formulas)
    {
        for (int i = 0; i < options.Count; i++)
        {
            //Content += new string(' ', _length) + "\n";
            for (int j = 0; j < formulas.Count; j++)
            {
                string marginLeft = new string(' ', ColumnSizes[j] / 2);
                string marginRight = new string(' ', ColumnSizes[j] - 1 - marginLeft.Length);
                Content += $"{marginLeft}{ToString(FormulaParser.Parse(formulas[j]).Evaluate(options[i]))}{marginRight}";
            } 

            Content += '\n';
        }

        Content += "\n";
        //Content += new string(' ', _length) + "\n";
    }

    private string ToString(bool input)
    {
        if (input) return "1";
        return "0";
    }
}