// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для проверки знаний пользователя
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace FictionalVariablesConsole;

public static class KnowledgeTest
{
    public static void TestingUserKnowledge()
    {
        int mark = 0;
        Console.WriteLine();
        
        for (int i = 0; i < 10; i++)
        {
            if (SingleTest())
            {
                Console.WriteLine("Ответ верный");
                mark++;
            }
            else
            {
                Program.PrintInRed("Ответ неверный");
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
        
        testFormula = Program.TranslateFormulaToInnerLanguage(testFormula);
        var fictionalVariablesFinder = new FictionalVariablesFinder(testFormula);
        fictionalVariablesFinder.FindFictionalVariables(false);

        if (fictionalVariablesFinder.FictionalVariables.Count.ToString() != resp) return false;
        return true;
    }

    private static List<string> GenerateArguments(int numberOfVariables, int numberOfOperations)
    {
        Random rand = new Random();
        List<string> allVariables = ["A", "B", "C", "D", "E", "F"];
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

        for (int i = 0; i < numberOfOperations; i++)
        {
            int operation = rand.Next(4);
            int randomArgument = rand.Next(arguments.Count);
            var argument = arguments[randomArgument];
            
            if (testFormula != "") testFormula = "(" + testFormula + operations[operation] + argument + ")";
            else
            {
                testFormula = argument;
                i--;
            }
            
            arguments.RemoveAt(randomArgument);
        }

        return testFormula;
    }
}