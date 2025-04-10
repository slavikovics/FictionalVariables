namespace LogicalParser;

public class Negation: IEvaluatable
{
    public IEvaluatable Formula { get; }

    public Negation(IEvaluatable formula)
    {
        Formula = formula;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool value = !Formula.Evaluate(variables);
        return value;
    }
    
    public override string ToString()
    {
        string result = $"(!{Formula})";
        return result;
    }
}