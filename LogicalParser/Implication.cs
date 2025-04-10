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
        if (LeftSide.Evaluate(variables) && RightSide.Evaluate(variables) == false)
        {
            return false;
        }
        
        return true;
    }
    
    public override string ToString()
    {
        return $"({LeftSide}->{RightSide})";
    }
}