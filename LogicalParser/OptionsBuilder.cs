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
    public static List<bool[]> BuildArguments(List<string> arguments)
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

    public static List<bool[]>? CachedArguments { get; set; }
    
    public static bool[] FindIndexForm(List<string> propositionalVariables, IEvaluatable formula)
    {
        if (CachedArguments == null) CachedArguments = BuildArguments(propositionalVariables);
        bool[] result = new bool[CachedArguments.Count];

        EvaluatableSource source = new EvaluatableSource(propositionalVariables);
        source.PrecomputeIndexes(formula);
        
        for (int i = 0; i < CachedArguments.Count; i++)
        {
            source.VariableValues = CachedArguments[i];
            result[i] = formula.Evaluate(source);
        }
        
        return result;
    }
}