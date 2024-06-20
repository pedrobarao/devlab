using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerFullNameSpec : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer entity)
    {
        return entity.Name.IsValid();
    }

    public string ErrorMessage => "Customer name is invalid";
}