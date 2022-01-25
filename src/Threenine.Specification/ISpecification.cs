namespace Threenine.Specification;

public interface ISpecification<in TEntity> where TEntity : class  
{
    bool SatisfiedBy(TEntity o);
}