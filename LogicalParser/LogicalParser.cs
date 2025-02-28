namespace LogicalParser;

public static class LogicalParser
{
    public static IEvaluatable Parse(string input)
    {
        IEvaluatable result = new ;

        return result;
    }

    public static int FindSign(string input, int requiredLevel = 0)
    {
        int index = 0;
        int level = 0;
        foreach (char c in input)
        {
            if (c == '(')
            {
                level++;
                continue;
            }
            if (c == ')')
            {
                level--;
                continue;
            }

            if (level == requiredLevel && IsLogicalSign(c))
            {
                return index;
            }

            index++;
        }

        return FindSign(input, requiredLevel + 1);
    }

    public static bool IsLogicalSign(char c)
    {
        if (c == '&' || c == '|' || c == '!' || c == '~' || c == '-' || c == '>') return true;
        else return false;
    }

    public static LogicalSigns MapSign(string input, int index)
    {
        
    }
}