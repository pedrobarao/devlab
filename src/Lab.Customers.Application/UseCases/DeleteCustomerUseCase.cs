using Lab.Core.Commons.Communication;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class DeleteCustomerUseCase : IDeleteCustomerUseCase
{
    public async Task<IOperationResult> Execute(Guid id)
    {
        throw new NotImplementedException();
    }
}