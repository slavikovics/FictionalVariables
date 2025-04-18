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
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Поиск фиктивных переменных");
            Console.WriteLine("2. Тестирование знаний пользователя");
            Console.WriteLine("exit. Введите 'exit', чтобы завершить выполнение программы.");
            string? resp = Console.ReadLine();
            
            if (resp == "1") FindingFictionalVariables();
            else if (resp == "2") TestingUserKnowledge();
            else if (resp == "exit") return;
            
            Console.WriteLine();
        }
    }

    private static void TestingUserKnowledge()
    {
        int mark = 0;
        
        for (int i = 0; i < 10; i++)
        {
            if (SingleTest())
            {
                Console.WriteLine("Ответ верный");
                mark++;
            }
            else
            {
                PrintInRed("Ответ неверный");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine($"Ваша оценка за тестирование: {mark} из 10");
    }

    private static bool SingleTest()
    {
        Random rand = new Random();
        int numberOfOperations = rand.Next(4) + 2;
        int numberOfVariables = rand.Next(numberOfOperations + 1) + 1;
        
        var arguments = GenerateArguments(numberOfVariables, numberOfOperations);
        var testFormula = GenerateTestFormula(arguments, numberOfOperations);
        Console.WriteLine($"Сколько фиктивных переменных в формуле: {testFormula}?");
        var resp = Console.ReadLine();
        
        testFormula = TranslateFormulaToInnerLanguage(testFormula);
        var fictionalVariablesFinder = new FictionalVariablesFinder(testFormula);
        fictionalVariablesFinder.FindFictionalVariables();

        if (fictionalVariablesFinder.FictionalVariables.Count.ToString() != resp) return false;
        return true;
    }

    private static List<string> GenerateArguments(int numberOfVariables, int numberOfOperations)
    {
        Random rand = new Random();
        List<string> allVariables = ["A", "B", "C", "D", "E"];
        List<string> arguments = [];
        
        arguments.AddRange(allVariables.GetRange(0, numberOfVariables));

        for (int i = 0; i < numberOfOperations + 1 - numberOfVariables; i++)
        {
            int seed = rand.Next(2);
            if (seed == 1)
            {
                arguments.Add("1");
            }
            else
            {
                arguments.Add("0");
            }
        }

        return arguments;
    }

    private static string GenerateTestFormula(List<string> arguments, int numberOfOperations)
    {
        List<string> operations = ["/\\", "\\/", "->", "~"];
        string testFormula = "";
        Random rand = new Random();

        for (int i = 0; i < numberOfOperations + 1; i++)
        {
            int operation = rand.Next(numberOfOperations);
            int randomArgument = rand.Next(arguments.Count);
            var argument = arguments[randomArgument];
            
            if (testFormula != "") testFormula = "(" + testFormula + operations[operation] + argument + ")";
            else testFormula = argument;
            
            arguments.RemoveAt(randomArgument);
        }

        return testFormula;
    }

    private static void FindingFictionalVariables()
    {
        while (true)
        {
            Console.WriteLine("Введите формулу сокращённого языка логики высказываний. Или введите 'exit', чтобы завершить выполнение программы.");
            var formula = Console.ReadLine();
            if (formula is null) return;
            if (formula == "exit") return;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine();
            PrintFictionalVariables(formula);
            stopWatch.Stop();
            Console.WriteLine($"Затраченное время: {stopWatch.Elapsed}");
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
            
            Console.WriteLine();
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
        if (formula.Contains("&") || formula.Contains("|")) throw new Exception("Wrong operation symbols");
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