using System.Text;

namespace LogicalParser;

public class Table
{
    public string IndexForm { get; private set; }

    private IEvaluatable Formula { get; }

    public Table(string input)
    {
        input = input.ToLower();
        IndexForm = "";
        
        var variables = FormulaParser.FindAllPropositionalVariables(input);
        Formula = FormulaParser.Parse(input);
        var options = OptionsBuilder.BuildOptions(variables);
        
        BuildBody(options);
    }

    private void BuildBody(List<Dictionary<string, bool>> options)
    {
        if (options.Count == 0) options.Add([]);
        
        for (int i = 0; i < options.Count; i++)
        {
            bool evaluationResult = Formula.Evaluate(options[i]);
            IndexForm += ToString(evaluationResult);
        }
    }

    private string ToString(bool input)
    {
        string result = "0";
        if (input) result = "1";
        return result;
    }
}