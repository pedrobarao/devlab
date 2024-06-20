using Lab.Core.Commons.Specifications;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerCpfSpec : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer entity)
    {
        return Cpf.Validate(entity.Cpf.Number);
    }

    public string ErrorMessage => "CPF is invalid";
}