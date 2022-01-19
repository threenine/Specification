namespace Threenine.Specification;

public class ExpressionSpecification<TEntity> : CompositeSpecification<TEntity>   where TEntity : class
{
    private readonly Func<TEntity, bool> expression;
    
    public ExpressionSpecification(Func<TEntity, bool> expression)
    {
        if (expression == null)
            throw new ArgumentNullException();
        this.expression = expression;
    }

    public override bool SatisfiedBy(TEntity o)   {
        return expression(o);
    }
}