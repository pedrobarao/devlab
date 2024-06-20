using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerLegalAgeSpec : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer entity)
    {
        return entity.BirthDate.ToDateTime(TimeOnly.MinValue) <= DateTime.Now.AddYears(-18);
    }

    public string ErrorMessage => "Customer must be of legal age";
}