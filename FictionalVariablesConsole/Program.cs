// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для консольного ввода и вывода
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using System.Diagnostics;
using LogicalParser;

namespace FictionalVariablesConsole;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите формулу сокращённого языка логики высказываний. Или введите 'exit', чтобы завершить выполнение программы.");
            var formula = Console.ReadLine();
            if (formula is null) continue;
            if (formula == "exit") return;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine();
            PrintFictionalVariables(formula);
            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
            Console.WriteLine();
        }
    }

    static void PrintFictionalVariables(string formula)
    {
        try
        {
            formula = TranslateFormulaToInnerLanguage(formula);
            
            if (!FormulaStringChecker.Check(formula)) 
                throw new Exception("Введённое выражение не является формулой сокращённого языка логики высказываний.");
            
            var fictionalVariablesFinder = new FictionalVariablesFinder(formula);
            fictionalVariablesFinder.FindFictionalVariables();
            
            Console.WriteLine("Найденные фиктивные переменные:");
            foreach (var variable in fictionalVariablesFinder.FictionalVariables)
            {
                Console.WriteLine(variable.ToUpper());
            }

            if (fictionalVariablesFinder.FictionalVariables.Count == 0)
            {
                PrintInRed("Фиктивных переменных не найдено.");
            }
        }
        catch (Exception e)
        {
            PrintInRed("Введённое выражение не является формулой сокращённого языка логики высказываний.");
        }
    }

    static string TranslateFormulaToInnerLanguage(string formula)
    {
        formula = formula.Replace("\\/", "|").Replace("/\\", "&");

        for (int i = 0; i < formula.Length; i++)
        {
            if (char.IsLower(formula[i]) && char.IsLetter(formula[i]))
            {
                throw new Exception("Not logical formula");
            }
        }

        return formula.ToLower();
    }

    static void PrintInRed(string content)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(content);
        Console.ForegroundColor = ConsoleColor.White;
    }
}