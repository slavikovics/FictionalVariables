namespace LogicalParser;

public class Disjunction: IEvaluatable
{
    public IEvaluatable LeftSide { get; }
    
    public IEvaluatable RightSide { get; }

    public Disjunction(IEvaluatable leftSide, IEvaluatable rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        return LeftSide.Evaluate(variables) || RightSide.Evaluate(variables);
    }
    
    public override string ToString()
    {
        return $"({LeftSide}|{RightSide})";
    }
}