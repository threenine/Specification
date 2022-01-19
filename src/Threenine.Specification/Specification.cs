namespace Threenine.Specification;

public abstract class Specification<TEntity> : ISpecification<TEntity>  where TEntity : class 
{
    public abstract bool SatisfiedBy(TEntity o);
}