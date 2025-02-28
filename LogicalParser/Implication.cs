namespace LogicalParser;

public class Implication: IEvaluatable
{
    public IEvaluatable LeftSide { get; set; }
    
    public IEvaluatable RightSide { get; set; }

    public Implication(IEvaluatable leftSide, IEvaluatable rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }
    
    public bool Evaluate()
    {
        if (LeftSide.Evaluate() && RightSide.Evaluate() == false) return false;
        return true;
    }
}