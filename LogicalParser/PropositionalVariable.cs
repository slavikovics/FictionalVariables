namespace LogicalParser;

public class PropositionalVariable: IEvaluatable
{
    public string Name { get; }

    public PropositionalVariable(string name)
    {
        for (int i = 0; i < name.Length; i++)
        {
            if (!char.IsLetter(name[i]))
            {
                throw new ArgumentException("Propositional variable name cannot include digits.");
            }

            Name = name;
        }
    }
    
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool result = variables[Name];
        return result;
    }

    public override string ToString()
    {
        string result = Name;
        return result;
    }
}