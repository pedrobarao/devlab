using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications.Validators;

public class CustomerValidator : SpecificationValidator<Customer>
{
    public CustomerValidator()
    {
        Add(new CustomerLegalAgeSpec());
        Add(new CustomerCpfSpec());
        Add(new CustomerFullNameSpec());
    }
}