using System.Linq.Expressions;

namespace Threenine.Specification;


public abstract class CompositeSpecification<TEntity> : Specification<TEntity>,  ICompositeSpecification<TEntity>   where TEntity : class  
{

    protected CompositeSpecification() { }

    protected CompositeSpecification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }
    public Expression<Func<TEntity, bool>> Criteria { get; }
    public ISpecification<TEntity> And(ISpecification<TEntity> specification)       
    {
        return new AndSpecification<TEntity>(this, specification);
    }
    public ISpecification<TEntity> Or(ISpecification<TEntity> specification)        
    {
        return new OrSpecification<TEntity>(this, specification);
    }
    public ISpecification<TEntity> Not(ISpecification<TEntity> specification)       
    {
        return new NotSpecification<TEntity>(specification);
    }
}
