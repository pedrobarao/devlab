using Bogus;
using Lab.Customers.Domain.Entities;

namespace Lab.Test.Shared.Builders;

public class CustomerBuilder : Faker<Customer>
{
    public CustomerBuilder()
    {
        Locale = "pt_BR";

        var name = new NameBuilder().Build();
        var cpf = new CpfBuilder().Build();

        RuleFor(o => o.Id, f => Guid.NewGuid());
        RuleFor(o => o.BirthDate, f => f.Date.PastDateOnly(18));
        RuleFor(o => o.Name, f => name);
        RuleFor(o => o.Cpf, f => cpf);
    }

    public Customer Builder()
    {
        return Generate();
    }

    public List<Customer> Builder(int count)
    {
        return Generate(count);
    }

    public CustomerBuilder WithInvalidName()
    {
        var name = new NameBuilder().WithInvalidName().Build();

        RuleFor(o => o.Name, f => name);
        return this;
    }

    public CustomerBuilder WithInvalidCpf()
    {
        var cpf = new CpfBuilder().WithInvalidNumber().Build();

        RuleFor(o => o.Cpf, f => cpf);
        return this;
    }
}