using Lab.Core.Commons.Communication;
using Lab.Core.Commons.ValueObjects;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.DTOs.Outputs;
using Lab.Customers.Application.Interfaces;
using Lab.Customers.Domain.Entities;
using Lab.Customers.Domain.Repositories;
using Lab.Customers.Domain.Specifications.Validators;
using Lab.Customers.Domain.ValueObjects;

namespace Lab.Customers.Application.UseCases;

public class CreateCustomerUseCase(ICustomerRepository customerRepository) : ICreateCustomerUseCase
{
    public async Task<IOperationResult<CustomerCreatedDto>> Execute(NewCustomerDto newCustomerDto)
    {
        var name = new Name(newCustomerDto.FirstName, newCustomerDto.LastName);
        var cpf = new Cpf(newCustomerDto.Cpf);
        var customer = new Customer(name, cpf, newCustomerDto.BirthDate);

        var validate = new CustomerLegalAgeValidator().Validate(customer);
        
        // customerRepository.Add(customer);
        // await customerRepository.UnitOfWork.Commit();

        return new OperationResult<CustomerCreatedDto>(new CustomerCreatedDto { Id = Guid.NewGuid() });
    }
}