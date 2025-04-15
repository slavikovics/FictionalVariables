namespace LogicalParser;

public class EvaluatableSource
{
    public string[] VariableNames { get; set; }
    
    public bool[] VariableValues { get; set; }
    
    private Dictionary<string, int> VariableIndexes { get; set; }

    public EvaluatableSource(List<string> variables)
    {
        VariableNames = variables.ToArray();
        VariableIndexes = [];
        for (int i = 0; i < variables.Count; i++)
        {
            VariableIndexes.Add(VariableNames[i], i);
        }
    }

    public bool this[string variableName] => VariableValues[VariableIndexes[variableName]];
}