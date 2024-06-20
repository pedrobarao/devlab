using Lab.Core.Commons.Validators;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications;

public class CustomerLegalAgeSpec : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer entity)
    {
        return entity.BirthDate.Date >= DateTime.Now.Date.AddYears(-18);
    }

    public string ErrorMessage => "Error message here";
}