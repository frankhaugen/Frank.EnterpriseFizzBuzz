namespace Frank.EnterpriseFizzBuzz;

public class RuleEvaluatorService<T>
{
    private readonly IEnumerable<IRule<T>> _rules;

    public RuleEvaluatorService(IEnumerable<IRule<T>> rules)
    {
        _rules = rules;
    }

    public IEnumerable<IRule<T>> Evaluate(T input)
    {
        return _rules.Where(rule => rule.Evaluate(input));
    }
}