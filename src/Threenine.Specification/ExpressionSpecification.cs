namespace Threenine.Specification;

public class ExpressionSpecification<TEntity> : CompositeSpecification<TEntity> where TEntity : class
{
    private readonly Func<TEntity, bool> expression;

    public ExpressionSpecification(Func<TEntity, bool> expression)
    {
        this.expression = expression ?? throw new ArgumentNullException();
    }

    public override bool SatisfiedBy(TEntity o)
    {
        return expression(o);
    }
}