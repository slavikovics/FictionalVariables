namespace LogicalParser;

public class False: IEvaluatable
{
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool value = false;
        return value;
    }

    public override string ToString()
    {
        string result = "0";
        return result;
    }
}