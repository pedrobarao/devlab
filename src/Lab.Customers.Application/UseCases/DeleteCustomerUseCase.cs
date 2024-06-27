using Lab.Core.Commons.Communication;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class DeleteCustomerUseCase(ICustomerRepository customerRepository) : IDeleteCustomerUseCase
{
    public IOperationResult OperationResult { get; } = Result.Create();

    public async Task<IOperationResult> Execute(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        if (customer is null)
        {
            OperationResult.AddError("Customer not found.");
            return OperationResult;
        }

        customerRepository.Delete(customer);
        await customerRepository.UnitOfWork.Commit();

        return OperationResult;
    }

    public bool ValidateInput(Guid request)
    {
        throw new NotImplementedException();
    }
}