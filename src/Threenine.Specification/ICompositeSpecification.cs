using System.Linq.Expressions;

namespace Threenine.Specification;

public interface ICompositeSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    ISpecification<TEntity> And(ISpecification<TEntity> specification);
    ISpecification<TEntity> Or(ISpecification<TEntity> specification);
    ISpecification<TEntity> Not(ISpecification<TEntity> specification);
}