// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для пропозициональной переменной
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

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
    
    public bool Evaluate(EvaluatableSource variables)
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