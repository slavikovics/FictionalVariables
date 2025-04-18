// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для поиска фиктивных переменных
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using System.Diagnostics;

namespace LogicalParser;

public class FictionalVariablesFinder
{
    private string FormulaString { get; }

    public List<string> FictionalVariables { get; }
    
    public FictionalVariablesFinder(string formulaString)
    {
        FormulaString = formulaString;
        FictionalVariables = [];
    }

    private bool IsFictionalVariable(string variableName, bool showTime = true)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var formulaWithOneStr = FormulaString.Replace(variableName, "1");
        var formulaWithZeroStr = FormulaString.Replace(variableName, "0");

        var formulaWithOne = FormulaParser.Parse(formulaWithOneStr);
        var formulaWithZero = FormulaParser.Parse(formulaWithZeroStr);
        var formulaWithOneVariables = FormulaParser.FindAllPropositionalVariables(formulaWithOneStr);
        var formulaWithZeroVariables = FormulaParser.FindAllPropositionalVariables(formulaWithZeroStr);
        
        var resultOne = OptionsBuilder.FindIndexForm(formulaWithOneVariables, formulaWithOne);
        var resultZero = OptionsBuilder.FindIndexForm(formulaWithZeroVariables, formulaWithZero);
        sw.Stop();
        if (showTime) Console.WriteLine($"Переменная {variableName.ToUpper()} проверена за {sw.ElapsedMilliseconds} мс.");
        
        for (int i = 0; i < resultOne.Length; i++)
        {
            if (resultOne[i] != resultZero[i]) return false;
        }
        
        return true;
    }

    public void FindFictionalVariables(bool showTime = true)
    {
        var allVariables = FormulaParser.FindAllPropositionalVariables(FormulaString);

        for (int i = 0; i < allVariables.Count; i++)
        {
            if (IsFictionalVariable(allVariables[i], showTime)) FictionalVariables.Add(allVariables[i]);
        }

        OptionsBuilder.CachedArguments = null;
    }
}