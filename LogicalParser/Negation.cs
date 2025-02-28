namespace LogicalParser;

public class Negation: IEvaluatable
{
    public IEvaluatable Formula { get; set; }

    public Negation(IEvaluatable formula)
    {
        Formula = formula;
    }
    
    public bool Evaluate()
    {
        return !Formula.Evaluate();
    }
}