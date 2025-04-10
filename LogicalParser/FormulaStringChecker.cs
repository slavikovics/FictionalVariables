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