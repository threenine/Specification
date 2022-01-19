namespace Threenine.Specification;

public interface ISpecification<TEntity> where TEntity : class  
{
    bool SatisfiedBy(TEntity o);
    /*ISpecification<TEntity> And(ISpecification<TEntity> specification);
    ISpecification<TEntity> Or(ISpecification<TEntity> specification);
    ISpecification<TEntity> Not(ISpecification<TEntity> specification);*/
}