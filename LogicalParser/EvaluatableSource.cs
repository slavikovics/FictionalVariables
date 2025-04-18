// Выполнил студент группы 321701 БГУИР:
// - Самович Вячеслав Максимович
// Вариант 7
//
// Класс аргументов для нахождения значения логической формулы
// 12.04.2025
//
// Источники:
// - Логические основы интеллектуальных систем. Практикум : учебно - метод. пособие / В. В. Голенков [и др.]. – Минск : БГУИР, 2011. – 70 с. : ил.
//

namespace LogicalParser;

public class EvaluatableSource
{
    public string[] VariableNames { get; set; }
    
    public bool[] VariableValues { get; set; }
    
    private Dictionary<string, int> VariableIndexes { get; set; }

    public EvaluatableSource(List<string> variables)
    {
        VariableNames = variables.ToArray();
        VariableIndexes = [];
        for (int i = 0; i < variables.Count; i++)
        {
            VariableIndexes.Add(VariableNames[i], i);
        }
    }

    public void PrecomputeIndexes(IEvaluatable evaluatable)
    {
        if (evaluatable is PropositionalVariable)
        {
            var variable = (PropositionalVariable)evaluatable;
            variable.VariableIndex = VariableIndexes[variable.Name];
            return;
        }

        if (evaluatable is Truth || evaluatable is False) return;

        if (evaluatable is Negation)
        {
            var operation = (Negation)evaluatable;
            PrecomputeIndexes(operation.Formula);
            return;
        }

        if (evaluatable is Conjunction)
        {
            var operation = (Conjunction)evaluatable;
            PrecomputeIndexes(operation.LeftSide);
            PrecomputeIndexes(operation.RightSide);
            return;
        }
        
        if (evaluatable is Disjunction)
        {
            var operation = (Disjunction)evaluatable;
            PrecomputeIndexes(operation.LeftSide);
            PrecomputeIndexes(operation.RightSide);
            return;
        }
        
        if (evaluatable is Implication)
        {
            var operation = (Implication)evaluatable;
            PrecomputeIndexes(operation.LeftSide);
            PrecomputeIndexes(operation.RightSide);
            return;
        }
        
        if (evaluatable is Equivalence)
        {
            var operation = (Equivalence)evaluatable;
            PrecomputeIndexes(operation.LeftSide);
            PrecomputeIndexes(operation.RightSide);
        }
    }
    
    public bool this[int variableIndex] => VariableValues[variableIndex];
}