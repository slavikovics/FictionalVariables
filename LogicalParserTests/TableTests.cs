// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для тестирования таблицы истинности
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class TableTests
{
    [TestMethod]
    public void IndexForm1()
    {
        string input = "a&b&c&d";
        Table table = new Table(input);
        bool[] indexForm = new bool [16]
        {
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
            true
        };
        Assert.AreEqual(table.IndexForm, indexForm);
    }
    
    [TestMethod]
    public void IndexForm2()
    {
        string input = "((a&b)|c)->d";
        Table table = new Table(input);
        Assert.AreEqual(table.IndexForm, "1101110111010101");
    }
    
    [TestMethod]
    public void IndexForm3()
    {
        string input = "((a&b)|c)->!(d&(e~f))";
        Table table = new Table(input);
        Assert.AreEqual(table.IndexForm, "1111111111110110111111111111011011111111111101101111011011110110");
    }
    
    [TestMethod]
    public void IndexForm4()
    {
        string input = "!a";
        Table table = new Table(input);
        Assert.AreEqual(table.IndexForm, "10");
    }
    
    [TestMethod]
    public void IndexForm5()
    {
        string input = "a";
        Table table = new Table(input);
        Assert.AreEqual(table.IndexForm, "01");
    }
    
    [TestMethod]
    public void IndexForm6()
    {
        string input = "a|b|c";
        Table table = new Table(input);
        Assert.AreEqual(table.IndexForm, "01111111");
    }
}