using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface IGetCustomerUseCase
{
    Task<CustomerDto?> GetByIdAsync(Guid id);
    Task<PagedResult<CustomerDto>> ListAsync(QueryCustomerDto query);
}