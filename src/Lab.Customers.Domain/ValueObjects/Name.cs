namespace Lab.Customers.Domain.ValueObjects;

public record Name(string FirstName, string LastName)
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}