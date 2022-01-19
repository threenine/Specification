namespace Threenine.Specification;

public interface ICompositeSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    ISpecification<TEntity> And(ISpecification<TEntity> specification);
    ISpecification<TEntity> Or(ISpecification<TEntity> specification);
    ISpecification<TEntity> Not(ISpecification<TEntity> specification);
}