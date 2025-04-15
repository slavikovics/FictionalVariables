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

    private bool IsFictionalVariableNew(string variableName)
    {
        var formulaWithOneStr = FormulaString.Replace(variableName, "1");
        var formulaWithZeroStr = FormulaString.Replace(variableName, "0");

        var formulaWithOne = FormulaParser.Parse(formulaWithOneStr);
        var formulaWithZero = FormulaParser.Parse(formulaWithZeroStr);
        var formulaWithOneVariables = FormulaParser.FindAllPropositionalVariables(formulaWithOneStr);
        var formulaWithZeroVariables = FormulaParser.FindAllPropositionalVariables(formulaWithZeroStr);
        
        Stopwatch sw = Stopwatch.StartNew();
        var resultOne = OptionsBuilder.FindIndexForm(formulaWithOneVariables, formulaWithOne);
        var resultZero = OptionsBuilder.FindIndexForm(formulaWithZeroVariables, formulaWithZero);
        sw.Stop();
        Console.WriteLine($"One variable processed in {sw.ElapsedMilliseconds} ms.");
        
        for (int i = 0; i < resultOne.Length; i++)
        {
            if (resultOne[i] != resultZero[i]) return false;
        }
        
        return true;
    }

    private bool IsFictionalVariable(string variableName)
    {
        var formulaWithOne = FormulaString.Replace(variableName, "1");
        var formulaWithZero = FormulaString.Replace(variableName, "0");
        
        var tableOne = new Table(formulaWithOne);
        var resultOne = tableOne.IndexForm;
        
        
        var tableZero = new Table(formulaWithZero);
        var resultZero = tableZero.IndexForm;
        
        //bool result = resultOne == resultZero;

        for (int i = 0; i < tableOne.OptionsCount; i++)
        {
            if (resultOne[i] != resultZero[i]) return false;
        }
        
        return true;
    }

    public void FindFictionalVariables()
    {
        var allVariables = FormulaParser.FindAllPropositionalVariables(FormulaString);

        foreach (var variable in allVariables)
        {
            if (IsFictionalVariableNew(variable)) FictionalVariables.Add(variable);
        }

        OptionsBuilder.CachedOptions = null;
        OptionsBuilder.CachedVariables = null;
        OptionsBuilder.CachedArguments = null;
    }
}