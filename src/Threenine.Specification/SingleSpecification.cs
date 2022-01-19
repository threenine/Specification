namespace Threenine.Specification;

public class SingleSpecification<TEntity> :  Specification<TEntity>   where TEntity : class
{
    private readonly Func<TEntity, bool> expression;

    public SingleSpecification(Func<TEntity, bool> expression)
    {
        if (expression == null)
            throw new ArgumentNullException();
        this.expression = expression;
    }
    public override bool SatisfiedBy(TEntity o)
    {
        return expression(o);
    }
}