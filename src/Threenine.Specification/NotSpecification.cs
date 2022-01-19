namespace Threenine.Specification;

public class NotSpecification<TEntity> : CompositeSpecification<TEntity> where TEntity : class
{
    readonly ISpecification<TEntity> specification;

    public NotSpecification(ISpecification<TEntity> spec)
    {
        specification = spec;
    }

    public override bool SatisfiedBy(TEntity o)
    {
        return !specification.SatisfiedBy(o);
    }
}