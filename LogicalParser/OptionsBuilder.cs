namespace LogicalParser;

public class OptionsBuilder
{
    public static List<string> BuildOptions(List<string> arguments)
    {
        arguments.Add("0");
        arguments.Add("1");
        
        int count = arguments.Count;

        for (int i = 0; i < count - 1; i++)
        {
            arguments = ResizeList(arguments);
        }
        
        return arguments;
    }

    private static List<string> ResizeList(List<string> arguments)
    {
        int count = arguments.Count;

        for (int i = 0; i < count; i++)
        {
            arguments.Add(arguments[i]);
        }
        
        for (int i = 0; i < arguments.Count / 2; i++)
        {
            arguments[i] += "0";
        }

        for (int i = arguments.Count / 2; i < arguments.Count; i++)
        {
            arguments[i] += "1";
        }
        
        return arguments;
    }

    private static Dictionary<string, bool> BuildOptions(List<string> arguments, List<string> propositionalVariables)
    {
        foreach (var variable in propositionalVariables)
        {
            
        }
    }
}