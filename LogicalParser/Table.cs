using System.Text;

namespace LogicalParser;

public class Table
{
    public string IndexForm { get; private set; }

    public Table(string input)
    {
        input = input.ToLower();
        IndexForm = "";

        var formulas = new List<string>();
        
        var variables = FormulaParser.FindAllPropositionalVariables(input);
        FormulaParser.Parse(input, formulas);
        var options = OptionsBuilder.BuildOptions(variables);
        
        BuildBody(options, variables.Concat(formulas).ToList());
    }

    private void BuildBody(List<Dictionary<string, bool>> options, List<string> formulas)
    {
        bool lastEvaluation = false;
        if (options.Count == 0) options.Add([]);
        
        for (int i = 0; i < options.Count; i++)
        {
            for (int j = 0; j < formulas.Count; j++)
            {
                lastEvaluation = FormulaParser.Parse(formulas[j]).Evaluate(options[i]);
            }
            
            IndexForm += ToString(lastEvaluation);
        }
    }

    private string ToString(bool input)
    {
        if (input) return "1";
        return "0";
    }
}