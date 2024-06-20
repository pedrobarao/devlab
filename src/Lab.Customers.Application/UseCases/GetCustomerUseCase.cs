using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class GetCustomerUseCase(ICustomerRepository customerRepository) : IGetCustomerUseCase
{
    public async Task<CustomerDto?> Execute(Guid id)
    {
        var customers = await customerRepository.GetByIdAsync(id);

        if (customers is null) return null;

        return new CustomerDto
        {
            Id = customers.Id,
            Name = customers.Name.ToString(),
            Cpf = customers.Cpf.ToString(),
            BirthDate = customers.BirthDate
        };
    }
}