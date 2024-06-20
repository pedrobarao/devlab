using Lab.Core.Commons.Specifications;
using Lab.Customers.Domain.Entities;

namespace Lab.Customers.Domain.Specifications.Validators;

public class CustomerLegalAgeValidator : SpecificationValidator<Customer>
{
    public CustomerLegalAgeValidator()
    {
        Add(new CustomerLegalAgeSpec());
    }
}