// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования парсинга формулы
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public sealed class ParsingTests
{
    [TestMethod]
    public void FindingSignTest()
    {
        Assert.AreEqual(FormulaParser.FindMiddleSign("a&b"), 1);
        Assert.AreEqual(FormulaParser.FindMiddleSign("(a&b)"), 2);
        Assert.AreEqual(FormulaParser.FindMiddleSign("(a|b)"), 2);
        Assert.AreEqual(FormulaParser.FindMiddleSign("!a"), 0);
        Assert.AreEqual(FormulaParser.FindMiddleSign("(a&(b&c))"), 2);
        Assert.AreEqual(FormulaParser.FindMiddleSign("a->b"), 1);
        Assert.AreEqual(FormulaParser.FindMiddleSign("((a->b)&(a|b))"), 7);
        Assert.AreEqual(FormulaParser.FindMiddleSign("(((a->b)&(a|b)))"), 8);
    }

    [TestMethod]
    public void NormalizeBracketsTest()
    {
        Assert.AreEqual(FormulaParser.NormalizeBrackets("a&b"), "a&b");
        Assert.AreEqual(FormulaParser.NormalizeBrackets("(a&b"), "a&b");
        Assert.AreEqual(FormulaParser.NormalizeBrackets("a&b)"), "a&b");
        Assert.AreEqual(FormulaParser.NormalizeBrackets("((a&b)"), "(a&b)");
        Assert.AreEqual(FormulaParser.NormalizeBrackets("(a&b))"), "(a&b)");
        Assert.AreEqual(FormulaParser.NormalizeBrackets("a&b)"), "a&b");
    }

    [TestMethod]
    public void FindLeftSubFormulaTest()
    {
        Assert.AreEqual(FormulaParser.FindLeftSubFormula("((a->b)&(a|b))"), "(a->b)");
        Assert.AreEqual(FormulaParser.FindLeftSubFormula("a&b"), "a");
        Assert.AreEqual(FormulaParser.FindLeftSubFormula("!a"), "");
        Assert.AreEqual(FormulaParser.FindLeftSubFormula("((a->!b)&(a|b&c))"), "(a->!b)");
        Assert.AreEqual(FormulaParser.FindLeftSubFormula("a&b&c"), "a");
    }

    [TestMethod]
    public void FindRightSubFormulaTest()
    {
        Assert.AreEqual(FormulaParser.FindRightSubFormula("((a->b)&(a|b))"), "(a|b)");
        Assert.AreEqual(FormulaParser.FindRightSubFormula("a&b"), "b");
        Assert.AreEqual(FormulaParser.FindRightSubFormula("!a"), "a");
        Assert.AreEqual(FormulaParser.FindRightSubFormula("((a->!b)&(a|b&c))"), "(a|b&c)");
        Assert.AreEqual(FormulaParser.FindRightSubFormula("a&b&c"), "b&c");
    }

    [TestMethod]
    public void ParseTest()
    {
        IEvaluatable logicalFormula = FormulaParser.Parse("(a&b)|(a|b&c)");
        Assert.IsTrue(logicalFormula is Disjunction);
    }
}