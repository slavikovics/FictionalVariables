using System.ComponentModel.Design;

namespace LogicalParser;

public static class FormulaStringChecker
{
    public static bool Check(string formula)
    {
        IEvaluatable parsedFormula;
        if (formula.Contains("(0)") || formula.Contains("(1)")) return false;
        
        try
        {
            parsedFormula = FormulaParser.Parse(formula);
        }
        catch (Exception)
        {
            return false;
        }
        
        if (parsedFormula.ToString() == formula) return true;
        return false;
    }
}