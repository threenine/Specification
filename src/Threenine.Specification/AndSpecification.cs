namespace Threenine.Specification;

public class AndSpecification<TEntity> : CompositeSpecification<TEntity>   where TEntity : class 
{
    private readonly ISpecification<TEntity> _left;
    private readonly ISpecification<TEntity> _right;

    public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)  {
        _left = left;
        _right = right;
    }

    public override bool SatisfiedBy(TEntity o)   {
        return _left.SatisfiedBy(o) 
               && _right.SatisfiedBy(o);
    }
}