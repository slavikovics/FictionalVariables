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

    private bool IsFictionalVariable(string variableName)
    {
        var formulaWithOne = FormulaString.Replace(variableName, "1");
        var formulaWithZero = FormulaString.Replace(variableName, "0");
        
        var tableOne = new Table(formulaWithOne);
        var resultOne = tableOne.IndexForm;
        
        var tableZero = new Table(formulaWithZero);
        var resultZero = tableZero.IndexForm;
        
        bool result = resultOne == resultZero;
        return result;
    }

    public void FindFictionalVariables()
    {
        var allVariables = FormulaParser.FindAllPropositionalVariables(FormulaString);

        foreach (var variable in allVariables)
        {
            if (IsFictionalVariable(variable)) FictionalVariables.Add(variable);
        }
    }
}