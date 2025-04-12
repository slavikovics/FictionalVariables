// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования проверки формулы на корректность
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public sealed class IsFormulaValidTests
{
    [TestMethod]
    public void TestIsFormulaValid()
    {
        string formula = "a";
        bool isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(!a)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "((!a)|b)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(((!a)|b)&c)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "((((!a)|b)&c)->d)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(((((!a)|b)&c)->d)~e)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "1";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "0";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(!1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(!0)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(0|1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "(a|1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
        
        formula = "((a|1)&(b|0))";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsTrue(isValid);
    }
    
    [TestMethod]
    public void TestIsFormulaInvalid()
    {
        string formula = "(a)";
        bool isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "!a";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "!(a)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(!a)|b";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "((!a|b)&c)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "((((!a)|b)&c)->d";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "((!a)|b)&c)->d)~e)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(0)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "!1";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "!0";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "0|1";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(0)|1";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(0)|(1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "0|(1)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "a|1";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(a=b)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
        
        formula = "(a|1)&(b|0)";
        isValid = FormulaStringChecker.Check(formula);
        Assert.IsFalse(isValid);
    }
}