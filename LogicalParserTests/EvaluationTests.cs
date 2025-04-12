// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования нахождения значения формулы
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class EvaluationTests
{
    [TestMethod]
    public void EvaluationTest1()
    {
        Dictionary<string, bool> variables = [];
        variables.Add("a", true);
        variables.Add("b", false);
        variables.Add("c", true);
        
        IEvaluatable logicalFormula = FormulaParser.Parse("(a&b)|(a|b&c)");
        Assert.AreEqual(logicalFormula.Evaluate(variables), true);
    }
    
    [TestMethod]
    public void EvaluationTest2()
    {
        Dictionary<string, bool> variables = [];
        variables.Add("a", false);
        variables.Add("b", false);
        variables.Add("c", false);
        
        IEvaluatable logicalFormula = FormulaParser.Parse("(a&b)|(a|b&c)");
        Assert.AreEqual(logicalFormula.Evaluate(variables), false);
    }
    
    [TestMethod]
    public void EvaluationTest3()
    {
        Dictionary<string, bool> variables = [];
        variables.Add("a", false);
        variables.Add("b", true);
        variables.Add("c", false);
        
        IEvaluatable logicalFormula = FormulaParser.Parse("(a&b)|(a|b&c)");
        Assert.AreEqual(logicalFormula.Evaluate(variables), false);
    }
    
    [TestMethod]
    public void EvaluationTest4()
    {
        Dictionary<string, bool> variables = [];
        variables.Add("a", true);
        variables.Add("b", false);
        variables.Add("c", false);
        
        IEvaluatable logicalFormula = FormulaParser.Parse("(a&b)|(a|b&c)");
        Assert.AreEqual(logicalFormula.Evaluate(variables), true);
    }
    
    [TestMethod]
    public void EvaluationTest5()
    {
        Dictionary<string, bool> variables = [];
        variables.Add("a", false);
        variables.Add("b", false);
        variables.Add("c", false);
        
        IEvaluatable logicalFormula = FormulaParser.Parse("!a&!c&!b");
        Assert.AreEqual(logicalFormula.Evaluate(variables), true);
    }
}