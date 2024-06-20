namespace Lab.Core.Commons.Specifications;

public interface ISpecification<TEntity> where TEntity : class
{
    string ErrorMessage { get; }
    bool IsSatisfiedBy(TEntity entity);
}