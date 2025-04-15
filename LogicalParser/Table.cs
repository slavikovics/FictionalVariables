// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для таблицы истинности
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using System.Diagnostics;

namespace LogicalParser;

public class Table
{
    public bool[] IndexForm { get; private set; }
    
    public int OptionsCount { get; private set; }

    private IEvaluatable Formula { get; }

    public Table(string input)
    {
        input = input.ToLower();
        
        var variables = FormulaParser.FindAllPropositionalVariables(input);
        Formula = FormulaParser.Parse(input);
        var sw1 = new Stopwatch();
        sw1.Start();
        var options = OptionsBuilder.BuildOptions(variables);
        sw1.Stop();
        Console.WriteLine($"Took {sw1.ElapsedMilliseconds} ms to build options");
        
        var sw2 = new Stopwatch();
        sw2.Start();
        BuildBody(options);
        sw2.Stop();
        Console.WriteLine($"Took {sw2.ElapsedMilliseconds} ms to find index form");
    }

    private void BuildBody(List<Dictionary<string, bool>> options)
    {
        if (options.Count == 0) options.Add([]);
        IndexForm = new bool[options.Count];
        OptionsCount = options.Count;
        
        for (int i = 0; i < options.Count; i++)
        {
            //IndexForm[i] = Formula.Evaluate(options[i]);
            //IndexForm += ToString(evaluationResult);
        }
    }

    private string ToString(bool input)
    {
        string result = "0";
        if (input) result = "1";
        return result;
    }
}