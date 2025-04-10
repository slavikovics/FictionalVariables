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
        return !Formula.Evaluate(variables);
    }
    
    public override string ToString()
    {
        return $"(!{Formula})";
    }
}