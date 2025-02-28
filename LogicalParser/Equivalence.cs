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
    
    public bool Evaluate(Dictionary<string, bool> variables, List<bool> partialResults)
    {
        if (LeftSide.Evaluate(variables, partialResults) == RightSide.Evaluate(variables, partialResults))
        {
            partialResults.Add(true);
            return true;
        }
        partialResults.Add(false);
        return false;
    }
    
    public override string ToString()
    {
        return LeftSide.ToString() + RightSide.ToString() + $"({LeftSide.ToString()} ~ {RightSide.ToString()})";
    }
}