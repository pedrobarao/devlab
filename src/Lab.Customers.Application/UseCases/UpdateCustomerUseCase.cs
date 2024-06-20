using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    public IOperationResult OperationResult { get; } = new OperationResult();

    public async Task<IOperationResult> Execute(UpdateCustomerDto updateCustomer)
    {
        return OperationResult;
    }
}