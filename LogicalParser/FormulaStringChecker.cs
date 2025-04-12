// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для проверки корректности формулы
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using System.ComponentModel.Design;

namespace LogicalParser;

public static class FormulaStringChecker
{
    public static bool Check(string formula)
    {
        bool success = false;
        IEvaluatable parsedFormula;
        if (formula.Contains("(0)") || formula.Contains("(1)")) return success;
        
        try
        {
            parsedFormula = FormulaParser.Parse(formula);
        }
        catch (Exception)
        {
            return success;
        }
        
        if (parsedFormula.ToString() == formula) success = true;
        return success;
    }
}