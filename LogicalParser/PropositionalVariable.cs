namespace LogicalParser;

public class PropositionalVariable: IEvaluatable
{
    public bool Value { get; }
    
    public string Name { get; }

    public PropositionalVariable(string name)
    {
        Name = name;
    }
    
    public bool Evaluate()
    {
        return Value;
    }
}