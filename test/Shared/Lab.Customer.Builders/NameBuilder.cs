using Bogus;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Test.Shared.Builders;

public class NameBuilder : Faker<Name>
{
    public NameBuilder()
    {
        RuleFor(o => o.FirstName, f => f.Person.FirstName);
        RuleFor(o => o.LastName, f => f.Person.LastName);
    }

    public Name Build()
    {
        return Generate();
    }

    public NameBuilder WithInvalidName()
    {
        RuleFor(o => o.FirstName, f => "");
        RuleFor(o => o.LastName, f => "");

        return this;
    }
}