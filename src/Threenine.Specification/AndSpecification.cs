namespace Threenine.Specification;

public class AndSpecification<TEntity> : CompositeSpecification<TEntity>   where TEntity : class 
{
    readonly ISpecification<TEntity> leftSpecification;
    readonly ISpecification<TEntity> rightSpecification;

    public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)  {
        leftSpecification = left;
        rightSpecification = right;
    }

    public override bool SatisfiedBy(TEntity o)   {
        return leftSpecification.SatisfiedBy(o) 
               && rightSpecification.SatisfiedBy(o);
    }
}