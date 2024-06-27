using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    public IOperationResult OperationResult { get; } = Result.Create();

    public async Task<IOperationResult> Execute(UpdateCustomerDto updateCustomer)
    {
        return OperationResult;
    }

    public bool ValidateInput(UpdateCustomerDto request)
    {
        throw new NotImplementedException();
    }
}