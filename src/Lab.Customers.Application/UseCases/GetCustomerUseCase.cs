using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class GetCustomerUseCase(ICustomerRepository customerRepository) : IGetCustomerUseCase
{
    public async Task<CustomerDto?> GetByIdAsync(Guid id)
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

    public async Task<PagedResult<CustomerDto>> ListAsync(QueryCustomerDto query)
    {
        var pagedCustomers = await customerRepository.ListPagedAsync(query.PageSize, query.PageIndex, query.Filter);

        var pagedCustomersDto = pagedCustomers.MapItems(p => new CustomerDto
        {
            Id = p.Id,
            Name = p.Name.FirstName,
            BirthDate = p.BirthDate,
            Cpf = p.Cpf.Number
        });

        return pagedCustomersDto;
    }
}