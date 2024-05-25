using Lab.Core.Commons.Communication;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;

namespace Lab.Customers.Application.UseCases;

public class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    public async Task<OperationResult> ExecuteAsync(UpdateCustomerDto updateCustomer)
    {
        throw new NotImplementedException();
    }
}