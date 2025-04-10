using LogicalParser;

namespace FictionalVariablesConsole;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Input logical formula");
            var formula = Console.ReadLine();
            if (formula is null) continue;
            
            Console.WriteLine();
            PrintFictionalVariables(formula);
            Console.WriteLine();
        }
    }

    static void PrintFictionalVariables(string formula)
    {
        try
        {
            if (!FormulaStringChecker.Check(formula)) throw new Exception("Not logical formula");
            var fictionalVariablesFinder = new FictionalVariablesFinder(formula);
            fictionalVariablesFinder.FindFictionalVariables();
            
            Console.WriteLine("Found fictional variables:");
            foreach (var variable in fictionalVariablesFinder.FictionalVariables)
            {
                Console.WriteLine(variable);
            }

            if (fictionalVariablesFinder.FictionalVariables.Count == 0)
            {
                PrintInRed("No fictional variables found");
            }
        }
        catch (Exception e)
        {
            PrintInRed("It's not logical formula");
        }
    }

    static void PrintInRed(string content)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(content);
        Console.ForegroundColor = ConsoleColor.White;
    }
}