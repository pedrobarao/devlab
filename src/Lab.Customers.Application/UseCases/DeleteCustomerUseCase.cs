using Lab.Core.Commons.Communication;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class DeleteCustomerUseCase : IDeleteCustomerUseCase
{
    public Task<OperationResult> ExecuteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}