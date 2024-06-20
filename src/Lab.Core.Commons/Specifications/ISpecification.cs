namespace Lab.Core.Commons.Validators;

public interface ISpecification<TEntity> where TEntity : class
{
    bool IsSatisfiedBy(TEntity entity);
    string ErrorMessage { get; }
}