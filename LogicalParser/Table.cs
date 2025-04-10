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

        foreach (var option in options)
        {
            bool evaluationResult = Formula.Evaluate(option);
            IndexForm += ToString(evaluationResult);
        }
    }

    private string ToString(bool input)
    {
        if (input) return "1";
        return "0";
    }
}