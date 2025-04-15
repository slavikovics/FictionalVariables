// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс для истины
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

namespace LogicalParser;

public class Truth: IEvaluatable
{
    public bool Evaluate(EvaluatableSource variables)
    {
        bool value = true;
        return value;
    }

    public override string ToString()
    {
        string result = "1";
        return result;
    }
}