namespace LogicalParser;

public class Truth: IEvaluatable
{
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool value = true;
        return value;
    }

    public override string ToString()
    {
        string result = "1";
        return result;
    }
}