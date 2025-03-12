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
        
        arguments = ["a", "b"];
        options = OptionsBuilder.BuildOptions(arguments);
        Assert.AreEqual(options.Count, 4);
        
        arguments = ["a"];
        options = OptionsBuilder.BuildOptions(arguments);
        Assert.AreEqual(options.Count, 2);
    }
}