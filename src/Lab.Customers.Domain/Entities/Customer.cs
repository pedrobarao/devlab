using Lab.Core.Commons.Entities;
using Lab.Core.Commons.Exceptions;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Customers.Domain.Entities;

public class Customer : Entity, IAggregateRoot
{
    protected Customer()
    {
    }

    public Customer(Name name, Cpf cpf, DateTime birthDate)
    {
        Name = name.IsValid() ? name : throw new DomainException("Invalid name");
        Cpf = Cpf.Validate(cpf.Number) ? cpf : throw new DomainException("Invalid CPF");
        BirthDate = IsValidBirthDate() ? birthDate : throw new DomainException("Invalid birth date");
    }

    public Name Name { get; private set; }
    public Cpf Cpf { get; private set; }
    public DateTime BirthDate { get; private set; }

    public bool IsValidBirthDate()
    {
        return BirthDate.CompareTo(DateTime.Now.AddYears(-18)) > 0;
    }
}