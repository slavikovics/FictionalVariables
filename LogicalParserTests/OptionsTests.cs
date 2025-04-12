// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования нахождения всевозможных списков значений переменных и правильности порядка элементов в данных списках
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class OptionsTests
{
    [TestMethod]
    public void ArgumentsTests()
    {
        List<string> arguments = ["a", "b", "c"];
        List<string> options = OptionsBuilder.BuildArguments(arguments);
        Assert.AreEqual(options.Count, 8);
        
        arguments = ["a", "b"];
        options = OptionsBuilder.BuildArguments(arguments);
        Assert.AreEqual(options.Count, 4);
        
        arguments = ["a"];
        options = OptionsBuilder.BuildArguments(arguments);
        Assert.AreEqual(options.Count, 2);
    }

    [TestMethod]
    public void BuildOptionsTests()
    {
        List<string> arguments = ["a", "b"];
        List<string> options = OptionsBuilder.BuildArguments(arguments);
        List<Dictionary<string, bool>> results = OptionsBuilder.BuildOptions(options, arguments);

        foreach (var dict in results)
        {
            foreach (var argument in arguments)
            {
                if (!dict.ContainsKey(argument)) Assert.Fail();
            }
        }
    }

    [TestMethod]
    public void SumTests()
    {
        string first = "11";
        string second = "11";
        string result = OptionsBuilder.Sum(first, second);
        Assert.AreEqual(result, "110");
        
        first = "10";
        second = "11";
        result = OptionsBuilder.Sum(first, second);
        Assert.AreEqual(result, "101");
        
        first = "00";
        second = "11";
        result = OptionsBuilder.Sum(first, second);
        Assert.AreEqual(result, "11");
        
        first = "011111";
        second = "100000";
        result = OptionsBuilder.Sum(first, second);
        Assert.AreEqual(result, "111111");
    }
}