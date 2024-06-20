namespace Lab.Core.Commons.Specifications;

public class ValidationResult
{
    public ValidationResult(IEnumerable<string> errors)
    {
        Errors = errors ?? Enumerable.Empty<string>();
    }

    public IEnumerable<string> Errors { get; }
    public bool IsValid => !Errors.Any();
}