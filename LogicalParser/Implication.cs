namespace LogicalParser;

public class Implication: IEvaluatable
{
    public IEvaluatable LeftSide { get; }
    
    public IEvaluatable RightSide { get; }

    public Implication(IEvaluatable leftSide, IEvaluatable rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool value = !(LeftSide.Evaluate(variables) && RightSide.Evaluate(variables) == false);
        return value;
    }
    
    public override string ToString()
    {
        string result = $"({LeftSide}->{RightSide})";
        return result;
    }
}