namespace LogicalParser;

public static class FormulaParser
{
    public static IEvaluatable Parse(string input)
    {
        if (!HasSign(input)) return new PropositionalVariable(input);
        
        string left = FindLeftSubFormula(input);
        string right = FindRightSubFormula(input);
        char sign = input[FindMiddleSign(input)];

        switch (sign)
        {
            case '!': return new Negation(Parse(right));
            case '&': return new Conjunction(Parse(left), Parse(right));
            case '|': return new Disjunction(Parse(left), Parse(right));
            case '-': return new Implication(Parse(left), Parse(right));
            case '~': return new Implication(Parse(left), Parse(right));
        }
        
        throw new FormatException("Invalid formula");
    }

    public static int FindMiddleSign(string input, int requiredLevel = 0)
    {
        int index = 0;
        int level = 0;
        List<int> signs = new List<int>();
        
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
                signs.Add(index);
            }

            index++;
        }

        if (signs.Count != 0) return FindOperationWithLowestPriority(input, signs);
        return FindMiddleSign(input, requiredLevel + 1);
    }

    private static bool IsLogicalSign(char c)
    {
        if (c == '&' || c == '|' || c == '!' || c == '~' || c == '-' || c == '>') return true;
        return false;
    }

    private static bool HasSign(string input)
    {
        foreach (var c in input)
        {
            if (IsLogicalSign(c)) return true;
        }

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

    public static int FindOperationWithLowestPriority(string input, List<int> signs)
    {
        foreach (int sign in signs) if (input[sign] == '~') return sign;
        foreach (int sign in signs) if (input[sign] == '-') return sign;
        foreach (int sign in signs) if (input[sign] == '|') return sign;
        foreach (int sign in signs) if (input[sign] == '&') return sign;
        foreach (int sign in signs) if (input[sign] == '!') return sign;
        
        throw new ArithmeticException("Invalid operation");
    }
}