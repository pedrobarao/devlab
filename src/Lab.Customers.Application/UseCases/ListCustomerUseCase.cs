﻿using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class ListCustomerUseCase(ICustomerRepository customerRepository)
    : IListCustomerUseCase
{
    public async Task<PagedResult<CustomerDto>> Execute(QueryCustomerDto query)
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