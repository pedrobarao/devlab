using Lab.Core.Commons.Communication;
using Lab.Core.Commons.UseCases;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Repositories;

namespace Lab.Customers.Application.UseCases;

public class ListCustomerUseCase(ICustomerRepository customerRepository)
    : IListCustomerUseCase, IUseCase<QueryCustomerDto, Result<PagedResult<CustomerDto>>>
{
    public async Task<Result<PagedResult<CustomerDto>>> Handle(QueryCustomerDto query)
    {
        var pagedCustomers = await customerRepository.ListPagedAsync(query.PageSize, query.PageIndex, query.Filter);

        var pagedCustomersDto = pagedCustomers.MapItems(p => new CustomerDto
        {
            Id = p.Id,
            Name = p.Name.FirstName,
            BirthDate = p.BirthDate,
            Cpf = p.Cpf.Number
        });

        Result.SetData(pagedCustomersDto);

        return Result;
    }

    public Result<PagedResult<CustomerDto>> Result { get; } = new();

    public bool ValidateInput(QueryCustomerDto request)
    {
        throw new NotImplementedException();
    }
}