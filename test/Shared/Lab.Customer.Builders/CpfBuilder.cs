using Bogus;
using Lab.Core.Commons.ValueObjects;

namespace Lab.Test.Shared.Builders;

public class CpfBuilder : Faker<Cpf>
{
    public CpfBuilder()
    {
        RuleFor(o => o.Number, f => "000.000.000-00");
    }

    public Cpf Build()
    {
        return Generate();
    }

    public CpfBuilder WithInvalidNumber()
    {
        RuleFor(o => o.Number, f => "000.000.000-00");
        return this;
    }
}