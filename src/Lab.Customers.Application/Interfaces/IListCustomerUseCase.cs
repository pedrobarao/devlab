using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface IListCustomerUseCase : IUseCase<QueryCustomerDto, PagedResult<CustomerDto>>
{
}