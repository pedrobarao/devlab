using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;

namespace Lab.Customers.Application.Interfaces;

public interface IDeleteCustomerUseCase : IUseCase<Guid, IOperationResult>
{
}