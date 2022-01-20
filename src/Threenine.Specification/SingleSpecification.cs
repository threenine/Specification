namespace Threenine.Specification;

public class SingleSpecification<TEntity> :  Specification<TEntity>   where TEntity : class
{
    private readonly Func<TEntity, bool> _expression;

    public SingleSpecification(Func<TEntity, bool> expression)
    {
        _expression = expression ?? throw new ArgumentNullException();
    }
    public override bool SatisfiedBy(TEntity o)
    {
        return _expression(o);
    }
}