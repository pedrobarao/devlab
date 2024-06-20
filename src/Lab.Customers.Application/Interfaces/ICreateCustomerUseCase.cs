using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface ICreateCustomerUseCase : IUseCase<NewCustomerDto, CustomerCreatedDto>
{
}