using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;
using Lab.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Customers.Api.v1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/customers")]
public class CustomerController(
    ICreateCustomerUseCase createCustomerUseCase,
    IGetCustomerUseCase getCustomerUseCase,
    IListCustomerUseCase listCustomerUseCase,
    IUpdateCustomerUseCase updateCustomerUseCase,
    IDeleteCustomerUseCase deleteCustomerUseCase,
    ILogger<CustomerController> logger)
    : MainController
{
    [HttpPost]
    public async Task<IActionResult> Create(NewCustomerDto newCustomer)
    {
        var result = await createCustomerUseCase.Execute(newCustomer);

        if (result.HasErrors())
        {
            AddErrors(result.GetErrors());
            return BadRequestDefault();
        }

        return Created($"{result.GetData().Id}", result.GetData());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await getCustomerUseCase.Execute(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] QueryCustomerDto query)
    {
        var result = await listCustomerUseCase.Execute(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCustomerDto updateCustomer, Guid id)
    {
        if (id != updateCustomer.Id) return BadRequest("The consumer id is invalid.");

        var result = await updateCustomerUseCase.Execute(updateCustomer);

        if (result.HasErrors())
        {
            AddErrors(result.GetErrors());
            return BadRequestDefault();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await deleteCustomerUseCase.Execute(id);

        if (result.HasErrors())
        {
            AddErrors(result.GetErrors());
            return BadRequestDefault();
        }

        return NoContent();
    }
}