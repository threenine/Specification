namespace Threenine.Specification;
/// <summary>
/// Or Specification to enable OR Clauses 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class OrSpecification<TEntity> : CompositeSpecification<TEntity> where TEntity : class
{
    readonly ISpecification<TEntity> leftSpecification;
    readonly ISpecification<TEntity> rightSpecification;

    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
    {
        leftSpecification = left;
        rightSpecification = right;
    }

    public override bool SatisfiedBy(TEntity o)
    {
        return leftSpecification.SatisfiedBy(o) 
               || rightSpecification.SatisfiedBy(o);
    }
}