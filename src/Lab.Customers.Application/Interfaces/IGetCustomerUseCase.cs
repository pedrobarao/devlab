using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface IGetCustomerUseCase : IUseCase<Guid, IOperationResult<CustomerDto?>>
{
}