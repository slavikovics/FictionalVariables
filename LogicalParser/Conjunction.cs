namespace LogicalParser;

public class Conjunction: IEvaluatable
{
    public IEvaluatable LeftSide { get; set; }
    
    public IEvaluatable RightSide { get; set; }

    public Conjunction(IEvaluatable leftSide, IEvaluatable rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables, List<bool> partialResults)
    {
        partialResults.Add(LeftSide.Evaluate(variables, partialResults) && RightSide.Evaluate(variables, partialResults));
        return LeftSide.Evaluate(variables, partialResults) && RightSide.Evaluate(variables, partialResults);
    }
    
    public override string ToString()
    {
        return LeftSide.ToString() + RightSide.ToString() + $"({LeftSide.ToString()} & {RightSide.ToString()})";
    }
}