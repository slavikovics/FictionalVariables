using LogicalParser;

namespace LogicalParserTests;

[TestClass]
public class TimeTests
{
    [TestMethod]
    public void Options18()
    {
        string formula =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R\\/1))))))))))))))))))";
        var options = OptionsBuilder.BuildOptions(FormulaParser.FindAllPropositionalVariables(formula));
    }
    
    [TestMethod]
    public void Options19Uncached()
    {
        string formula1 =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(T\\/1)))))))))))))))))))";
        var options = OptionsBuilder.BuildOptions(FormulaParser.FindAllPropositionalVariables(formula1), false);
        string formula2 =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(S\\/1)))))))))))))))))))";
        options = OptionsBuilder.BuildOptions(FormulaParser.FindAllPropositionalVariables(formula2), false);
    }

    [TestMethod]
    public void Options19Cached()
    {
        string formula1 =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(T\\/1)))))))))))))))))))";
        var options = OptionsBuilder.BuildOptions(FormulaParser.FindAllPropositionalVariables(formula1), true);
        string formula2 =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(S\\/1)))))))))))))))))))";
        options = OptionsBuilder.BuildOptions(FormulaParser.FindAllPropositionalVariables(formula2), true);
    }

    [TestMethod]
    public void Arguments18()
    {
        string formula =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R\\/1))))))))))))))))))";
        var propositionalVariables = FormulaParser.FindAllPropositionalVariables(formula);
        List<string> arguments = OptionsBuilder.BuildArguments(propositionalVariables);
    }

    [TestMethod]
    public void ParseFormula18()
    {
        string formula =
            "(A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(S->(T->(U->(V->(W->(X->(Y->(Z->1))))))))))))))))))))))))))";
        var parsed = FormulaParser.Parse(formula);
    }
}