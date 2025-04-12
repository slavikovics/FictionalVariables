// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для отрицания
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

namespace LogicalParser;

public class Negation: IEvaluatable
{
    public IEvaluatable Formula { get; }

    public Negation(IEvaluatable formula)
    {
        Formula = formula;
    }
    
    public bool Evaluate(Dictionary<string, bool> variables)
    {
        bool value = !Formula.Evaluate(variables);
        return value;
    }
    
    public override string ToString()
    {
        string result = $"(!{Formula})";
        return result;
    }
}