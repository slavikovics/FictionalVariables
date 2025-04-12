// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для парсинга сокращённой формулы языка логики высказываний
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

namespace LogicalParser;

public static class FormulaParser
{
    public static IEvaluatable Parse(string input)
    {
        IEvaluatable? result = null;
        input = input.Replace(" ", "").ToLower();
        CheckBracketCount(input);
        
        if (!HasSign(input))
        {
            if (input == "1") result = new Truth();
            else if (input == "0") result = new False();
            if (result is not null) return result;
            
            result = new PropositionalVariable(input);
            return result;
        }
        
        string left = FindLeftSubFormula(input);
        string right = FindRightSubFormula(input);
        char sign = input[FindMiddleSign(input)];

        switch (sign)
        {
            case '!': result = new Negation(Parse(right)); break;
            case '&': result = new Conjunction(Parse(left), Parse(right)); break;
            case '|': result = new Disjunction(Parse(left), Parse(right)); break;
            case '-': result = new Implication(Parse(left), Parse(right)); break;
            case '~': result = new Equivalence(Parse(left), Parse(right)); break;
        }

        if (result is not null) return result;
        throw new FormatException("Invalid formula");
    }

    public static int FindMiddleSign(string input, int requiredLevel = 0)
    {
        int result;
        int index = 0;
        int level = 0;
        List<int> signs = [];
        
        for (int i = 0; i < input.Length; i++) 
        {
            if (input[i] == '(')
            {
                level++;
                index++;
                continue;
            }
            if (input[i] == ')')
            {
                level--;
                index++;
                continue;
            }

            if (level == requiredLevel && IsLogicalSign(input[i]))
            {
                signs.Add(index);
            }

            index++;
        }

        if (signs.Count != 0) result = signs[0];
        else result = FindMiddleSign(input, requiredLevel + 1);
        return result;
    }

    private static bool IsLogicalSign(char c)
    {
        bool result = c == '&' || c == '|' || c == '!' || c == '~' || c == '-' || c == '>';
        return result;
    }

    private static bool HasSign(string input)
    {
        bool result = false;
        
        for (int i = 0; i < input.Length; i++)
        {
            if (IsLogicalSign(input[i]))
            {
                result = true;
                break;
            }
        }

        return result;
    }

    public static string NormalizeBrackets(string input)
    {
        string result;
        int openBrackets = 0;
        int closeBrackets = 0;
        
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(') openBrackets++;
            else if (input[i] == ')') closeBrackets++;
        }

        if (openBrackets == closeBrackets) result = input;
        else if (openBrackets > closeBrackets) result = input.Substring(1);
        else result = input.Substring(0, input.Length - 1);

        return result;
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

    public static List<string> FindAllPropositionalVariables(string input)
    {
        var variables = new List<string>();

        foreach (var c in input)
        {
            if (IsPropositionalVariable(c.ToString()) && !variables.Contains(c.ToString())) variables.Add(c.ToString());
        }

        return variables;
    }

    private static bool IsPropositionalVariable(string input)
    {
        if (input.Length > 1) return false;
        return char.IsLetter(Convert.ToChar(input));
    }

    private static void CheckBracketCount(string formula)
    {
        int leftBrackets = 0;
        int rightBrackets = 0;

        foreach (char c in formula)
        {
            if (c == '(') leftBrackets++;
            else if (c == ')') rightBrackets++;
        }
        
        if (leftBrackets != rightBrackets) throw new FormatException("Invalid brackets count");
    }
}