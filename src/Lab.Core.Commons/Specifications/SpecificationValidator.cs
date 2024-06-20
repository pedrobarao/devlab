namespace Lab.Core.Commons.Specifications;

public abstract class SpecificationValidator<TEntity> where TEntity : class
{
    private readonly List<ISpecification<TEntity>> _specifications = new();

    public ValidationResult Validate(TEntity entity)
    {
        var errorMessages = GetErrors(entity);
        return new ValidationResult(errorMessages);
    }

    private IEnumerable<string> GetErrors(TEntity entity)
    {
        return _specifications
            .Where(spec => !spec.IsSatisfiedBy(entity))
            .Select(spec => spec.ErrorMessage);
    }

    protected void Add(ISpecification<TEntity> spec)
    {
        _specifications.Add(spec);
    }
}