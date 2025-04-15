// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для нахождения всевозможных списков значений переменных для построения таблицы истинности 
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using System.Diagnostics;

namespace LogicalParser;

public static class OptionsBuilder
{
    public static List<Dictionary<string, bool>>? CachedOptions { get; set; }
    public static List<string>? CachedVariables { get; set; }
    
    public static List<string> BuildArguments(List<string> arguments)
    {
        List<string> options = [];
        int count = arguments.Count;
        if (count == 0) return options;
        
        string firstOption = new string('0', count -1) + "0";
        string diff = new string('0', count - 1) + "1";
        options.Add(firstOption);

        while (options.Last().Contains("0"))
        {
            firstOption = Sum(firstOption, diff);
            options.Add(firstOption);
        }
        
        return options;
    }
    
    public static string Sum(string firstArgument, string secondArgument)
    {
        string result = "";

        int memorizedOne = 0;
        for (int i = firstArgument.Length - 1; i >= 0; i--)
        {
            int iterationResult = Convert.ToInt32(firstArgument.Substring(i, 1)) + Convert.ToInt32(secondArgument.Substring(i, 1)) + memorizedOne;
            switch (iterationResult)
            {
                case 0: memorizedOne = 0;
                    result = "0" + result;
                    break;
                
                case 1: memorizedOne = 0;
                    result = "1" + result;
                    break;
                
                case 2: memorizedOne = 1;
                    result = "0" + result;
                    break;
                
                case 3: memorizedOne = 1;
                    result = "1" + result;
                    break;
            }
        }
        if (memorizedOne == 1) result = "1" + result;

        return result;
    }
    
    public static List<bool[]> BuildArgumentsNew(List<string> arguments)
    {
        List<bool[]> options = [];
        int count = arguments.Count;
        if (count == 0) return options;
        
        bool[] firstOption = new bool[count];
        bool[] diff = new bool[count];
        diff[count - 1] = true;
        
        options.Add(firstOption);

        for (int i = 0; i < Math.Pow(2, count); i++)
        {
            firstOption = Sum(firstOption, diff);
            options.Add(firstOption);
        }
        
        return options;
    }

    public static bool[] Sum(bool[] firstArgument, bool[] secondArgument)
    {
        bool[] result = new bool[firstArgument.Length];
        bool memorizedOne = false;
        
        for (int i = firstArgument.Length - 1; i >= 0 ; i--)
        {
            if (firstArgument[i] && secondArgument[i])
            {
                result[i] = memorizedOne;
                memorizedOne = true;
            }
            else if ((!firstArgument[i] && secondArgument[i]) || (firstArgument[i] && !secondArgument[i]))
            {
                if (memorizedOne) result[i] = false;
                else result[i] = true;
            }
            else
            {
                result[i] = memorizedOne;
                memorizedOne = false;
            }
        }

        return result;
    }
    
    public static List<Dictionary<string, bool>> BuildOptionsNew(List<bool[]> arguments, List<string> propositionalVariables)
    {
        List<Dictionary<string, bool>> options = [];
        
        for (int i = 0; i < arguments.Count; i++)
        {
            Dictionary<string, bool> option = [];

            for (int j = 0; j < arguments[i].Length; j++)
            {
                option.Add(propositionalVariables[j], arguments[i][j]);
            }
            
            options.Add(option);
        }
        
        return options;
    }

    private static bool CharConversion(char c)
    {
        bool result = c != '0';
        return result;
    }
    
    public static List<Dictionary<string, bool>> BuildOptions(List<string> arguments, List<string> propositionalVariables)
    {
        List<Dictionary<string, bool>> options = [];
        
        for (int i = 0; i < arguments.Count; i++)
        {
            Dictionary<string, bool> option = [];

            for (int j = 0; j < arguments[i].Length; j++)
            {
                option.Add(propositionalVariables[j], CharConversion(arguments[i][j]));
            }
            
            options.Add(option);
        }
        
        return options;
    }

    public static void ReplaceVariables(List<Dictionary<string, bool>> options,
        string oldVariable, string newVariable)
    {
        foreach (var dict in options)
        {
            bool value = dict[oldVariable];
            dict.Remove(oldVariable);
            dict.Add(newVariable, value);
        }
    }

    private static string? FindOldVariable(List<string>? oldVariables, List<string> newVariables)
    {
        if (oldVariables == null) return null;

        foreach (var old in oldVariables)
        {
            if (!newVariables.Contains(old)) return old;
        }

        return "";
    }
    
    private static string? FindNewVariable(List<string>? oldVariables, List<string> newVariables)
    {
        if (oldVariables == null) return null;

        foreach (var newVar in newVariables)
        {
            if (!oldVariables.Contains(newVar)) return newVar;
        }

        return "";
    }

    public static List<bool[]>? CachedArguments { get; set; }
    public static bool[] FindIndexForm(List<string> propositionalVariables, IEvaluatable formula)
    {
        Stopwatch sw1 = Stopwatch.StartNew();
        if (CachedArguments == null) CachedArguments = BuildArgumentsNew(propositionalVariables);
        Dictionary<string, bool> option = [];
        bool[] result = new bool[CachedArguments.Count];
        
        foreach (var variable in propositionalVariables)
        {
            option.Add(variable, false);
        }

        EvaluatableSource source = new EvaluatableSource(propositionalVariables);
        sw1.Stop();
        Console.WriteLine($"Preparation done in {sw1.ElapsedMilliseconds} ms");

        Stopwatch sw2 = Stopwatch.StartNew();
        for (int i = 0; i < CachedArguments.Count; i++)
        {
            // TODO process this dictionary with 0 time
            //for (int j = 0; j < propositionalVariables.Count; j++)
            //{
                //option[propositionalVariables[j]] = CachedArguments[i][j];
            //}
            source.VariableValues = CachedArguments[i];
            
            result[i] = formula.Evaluate(option);
        }
        
        sw2.Stop();
        Console.WriteLine($"Finding index form done in {sw2.ElapsedMilliseconds} ms");
        return result;
    }

    public static List<Dictionary<string, bool>> BuildOptions(List<string> propositionalVariables, bool useCached = true)
    {
        string? oldVariable = FindOldVariable(CachedVariables, propositionalVariables);
        string? newVariable = FindNewVariable(CachedVariables, propositionalVariables);
        
        if (useCached && CachedOptions != null && CachedVariables != null && oldVariable != null && newVariable != null)
        {
            CachedVariables = propositionalVariables;
            if (newVariable != "") ReplaceVariables(CachedOptions, oldVariable, newVariable);
            return  CachedOptions;
        }
        
        CachedVariables = propositionalVariables;
        Stopwatch sw1 = Stopwatch.StartNew();
        var arguments = BuildArguments(propositionalVariables);
        sw1.Stop();
        Stopwatch sw2 = Stopwatch.StartNew();
        var result = BuildOptions(arguments, propositionalVariables);
        sw2.Stop();
        CachedOptions = result;
        return result;
    }
}