using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class OptionsTests
{
    [TestMethod]
    public void ArgumentsTests()
    {
        List<string> arguments = ["a", "b", "c"];
        List<string> options = OptionsBuilder.BuildOptions(arguments);
        
        Assert.AreEqual(options.Count, 8);
    }
}