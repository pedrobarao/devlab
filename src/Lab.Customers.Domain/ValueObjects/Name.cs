namespace Lab.Customers.Domain.ValueObjects;

public record Name(string FirstName, string LastName)
{
    public string FirstName { get; init; } = FirstName;
    public string LastName { get; init; } = LastName;

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}