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
        BuildHeading(formulas);
        BuildBody(options, formulas);
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
        for (int i = 0; i < ColumnSizes.Count; i++)
        {
            Content += new string(' ', _length) + "\n";
            foreach (var formula in formulas) Content += $" {new string(' ', ColumnSizes[i] / 2)}{ToString(FormulaParser.Parse(formula).Evaluate(options[i]))}{new string(' ', ColumnSizes[i] / 2 + ColumnSizes[i] % 2)} ";
        }

        Content += "\n";
        Content += new string(' ', _length) + "\n";
    }

    private string ToString(bool input)
    {
        if (input) return "1";
        return "0";
    }
}