using Lab.Core.Commons.Validators;

namespace Lab.Core.Commons.Specifications;

public abstract class SpecificationValidator<TEntity> where TEntity : class
{
    private readonly List<ISpecification<TEntity>> _specifications = new();

    public ValidationResult Validate(TEntity entity)
    {
        //_specifications.All(spec => spec.IsSatisfiedBy(entity));
        var errorMessages = GetErrors(entity);

        return new ValidationResult(errorMessages);
    }

    private IEnumerable<string> GetErrors(TEntity entity)
    {
        return _specifications
            .Where(spec => !spec.IsSatisfiedBy(entity))
            .Select(spec => spec.ErrorMessage);
    }

    public void Add(ISpecification<TEntity> spec)
    {
        _specifications.Add(spec);
    }
}