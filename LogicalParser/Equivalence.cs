namespace LogicalParser;

public class Equivalence: IEvaluatable
{
    public IEvaluatable LeftSide { get; set; }
    
    public IEvaluatable RightSide { get; set; }

    public Equivalence(IEvaluatable leftSide, IEvaluatable rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }
    
    public bool Evaluate()
    {
        if (LeftSide.Evaluate() == RightSide.Evaluate()) return true;
        return false;
    }
}