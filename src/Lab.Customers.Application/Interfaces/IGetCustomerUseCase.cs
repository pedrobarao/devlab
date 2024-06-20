using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Outputs;

namespace Lab.Customers.Application.Interfaces;

public interface IGetCustomerUseCase : IUseCase<Guid, CustomerDto?>
{
}