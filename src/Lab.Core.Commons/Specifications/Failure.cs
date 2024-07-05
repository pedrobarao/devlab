namespace Lab.Core.Commons.Specifications;

public class Failure
{
    public Failure(string errorMessage, string ruleName, string entityName)
    {
        ErrorMessage = errorMessage;
        RuleName = ruleName;
        EntityName = entityName;
    }

    public Failure(string errorMessage, string ruleName)
    {
        ErrorMessage = errorMessage;
        RuleName = ruleName;
    }

    public string ErrorMessage { get; set; }
    public string RuleName { get; set; }
    public string? EntityName { get; set; }
}