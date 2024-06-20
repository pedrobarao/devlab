using Lab.Core.Commons.Communication;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Entities;
using Lab.Customers.Domain.Repositories;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Customers.Application.UseCases;

public class CreateCustomerUseCase(ICustomerRepository customerRepository) : ICreateCustomerUseCase
{
    public IOperationResult<CustomerCreatedDto> OperationResult { get; } =
        new OperationResult<CustomerCreatedDto>();

    public async Task<IOperationResult<CustomerCreatedDto>> Execute(NewCustomerDto newCustomerDto)
    {
        var name = new Name(newCustomerDto.FirstName, newCustomerDto.LastName);
        var cpf = new Cpf(newCustomerDto.Cpf);
        var customer = new Customer(name, cpf, newCustomerDto.BirthDate);
        var validationResult = customer.Validate();

        if (!validationResult.IsValid) OperationResult.AddErrors(validationResult);

        customerRepository.Add(customer);
        await customerRepository.UnitOfWork.Commit();

        OperationResult.SetData(new CustomerCreatedDto { Id = customer.Id });

        return OperationResult;
    }
}