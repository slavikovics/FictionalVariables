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
        bool value = LeftSide.Evaluate(variables) || RightSide.Evaluate(variables);
        return value;
    }
    
    public override string ToString()
    {
        string result = $"({LeftSide}|{RightSide})";
        return result;
    }
}