namespace LogicalParser;

public class OptionsBuilder
{
    public static List<string> BuildArguments(List<string> arguments)
    {
        List<string> options = ["0", "1"];
        int count = arguments.Count;

        for (int i = 0; i < count - 1; i++)
        {
            options = ResizeList(options);
        }
        
        return options;
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

    private static bool CharConversion(char c)
    {
        if (c == '0') return false;
        return true;
    }
    
    // TODO write tests for this + char conversion
    public static List<Dictionary<string, bool>> BuildOptions(List<string> arguments, List<string> propositionalVariables)
    {
        List<Dictionary<string, bool>> options = new List<Dictionary<string, bool>>();
        
        for (int i = 0; i < arguments.Count; i++)
        {
            if (arguments[0].Length != propositionalVariables.Count)
                throw new ArgumentException("Propositional variable count mismatch");

            Dictionary<string, bool> option = new Dictionary<string, bool>();

            for (int j = 0; j < arguments[i].Length; j++)
            {
                option.Add(propositionalVariables[j], CharConversion(arguments[i][j]));
            }
            
            options.Add(option);
        }
        
        return options;
    }
}