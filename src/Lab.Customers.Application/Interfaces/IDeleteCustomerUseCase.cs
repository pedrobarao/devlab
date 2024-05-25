using Lab.Core.Commons.Communication;

namespace Lab.Customers.Application.Interfaces;

public interface IDeleteCustomerUseCase
{
    Task<OperationResult> ExecuteAsync(Guid id);
}