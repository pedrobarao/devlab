using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class GetCustomerUseCase(ICustomerRepository customerRepository) : IGetCustomerUseCase
{
    public async Task<IOperationResult<CustomerDto?>> Execute(Guid id)
    {
        var customers = await customerRepository.GetByIdAsync(id);

        if (customers is null) return null;

        return new OperationResult<CustomerDto?>(new CustomerDto
        {
            Id = customers.Id,
            Name = customers.Name.ToString(),
            Cpf = customers.Cpf.ToString(),
            BirthDate = customers.BirthDate
        });
    }
}