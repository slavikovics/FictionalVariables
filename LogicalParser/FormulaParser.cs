namespace LogicalParser;

public static class FormulaParser
{
    //public static IEvaluatable Parse(string input)
    //{
    //    FindMiddleSign(input);
    //}

    public static int FindMiddleSign(string input, int requiredLevel = 0)
    {
        int index = 0;
        int level = 0;
        foreach (char c in input)
        {
            if (c == '(')
            {
                level++;
                index++;
                continue;
            }
            if (c == ')')
            {
                level--;
                index++;
                continue;
            }

            if (level == requiredLevel && IsLogicalSign(c))
            {
                return index;
            }

            index++;
        }

        return FindMiddleSign(input, requiredLevel + 1);
    }

    private static bool IsLogicalSign(char c)
    {
        if (c == '&' || c == '|' || c == '!' || c == '~' || c == '-' || c == '>') return true;
        return false;
    }

    public static string NormalizeBrackets(string input)
    {
        int openBrackets = 0;
        int closeBrackets = 0;
        
        foreach (var c in input)
        {
            if (c == '(') openBrackets++;
            else if (c == ')') closeBrackets++;
        }

        if (openBrackets == closeBrackets) return input;
        if (openBrackets > closeBrackets) return input.Substring(1);
        return input.Substring(0, input.Length - 1);
    }

    public static string FindLeftSubFormula(string input)
    {
        int middleSign = FindMiddleSign(input);
        return NormalizeBrackets(input.Substring(0, middleSign));
    }

    public static string FindRightSubFormula(string input)
    {
        int middleSign = FindMiddleSign(input);
        if (input[middleSign + 1] == '>') middleSign++;
        return NormalizeBrackets(input.Substring(middleSign + 1));
    }
}