using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface ICreateCustomerUseCase
{
    Task<IOperationResult<CustomerCreatedDto>> ExecuteAsync(NewCustomerDto newCustomerDto);
}