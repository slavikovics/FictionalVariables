namespace LogicalParser;

public class PropositionalVariable: IEvaluatable
{
    public bool Value { get; }

    public PropositionalVariable(bool value)
    {
        Value = value;
    }
    
    public bool Evaluate()
    {
        return Value;
    }
}