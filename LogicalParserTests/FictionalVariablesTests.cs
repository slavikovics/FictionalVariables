// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования поиска фиктивных переменных в формуле
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public sealed class FictionalVariablesTests
{
    [TestMethod]
    public void FictionalVariablesTest()
    {
        string formula = "a";
        var fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        var variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 0);
        
        formula = "(a|b)";
        fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 0);
        
        formula = "(a|1)";
        fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 1);
        Assert.IsTrue(variables.Contains("a"));
        
        formula = "(a|0)";
        fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 0);
        
        formula = "((a|1)&(b|1))";
        fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 2);
        Assert.IsTrue(variables.Contains("a"));
        Assert.IsTrue(variables.Contains("b"));
        
        formula = "((1|0)&(1|0))";
        fictionalVariablesFinder = new FictionalVariablesFinder(formula);
        fictionalVariablesFinder.FindFictionalVariables();
        variables = fictionalVariablesFinder.FictionalVariables;
        Assert.AreEqual(variables.Count, 0);
    }
}