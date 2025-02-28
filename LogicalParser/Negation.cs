namespace LogicalParser;

public class Negation: IEvaluatable
{
    public IEvaluatable Formula { get; set; }

    public Negation(IEvaluatable formula)
    {
        Formula = formula;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables, List<bool> partialResults)
    {
        partialResults.Add(!Formula.Evaluate(variables, partialResults));
        return !Formula.Evaluate(variables, partialResults);
    }
    
    public override string ToString()
    {
        return Formula.ToString() + "!" + Formula.ToString();
    }
}