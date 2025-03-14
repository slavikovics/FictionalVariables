using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class TableTests
{
    [TestMethod]
    public void FormsTest()
    {
        string input = "a|b";
        Table table = new Table(input);
        Assert.AreEqual(table.DisjunctiveForm, "(!a&b)|(a&!b)|(a&b)");
        Assert.AreEqual(table.ConjunctiveForm, "(a|b)");
    }
}