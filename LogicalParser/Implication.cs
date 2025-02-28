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
    
    public bool Evaluate(Dictionary<string, bool> variables, List<bool> partialResults)
    {
        if (LeftSide.Evaluate(variables, partialResults) && RightSide.Evaluate(variables, partialResults) == false)
        {
            partialResults.Add(false);
            return false;
        }
        partialResults.Add(true);
        return true;
    }
    
    public override string ToString()
    {
        return LeftSide.ToString() + RightSide.ToString() + $"({LeftSide.ToString()} -> {RightSide.ToString()})";
    }
}