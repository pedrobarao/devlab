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
        var result = await createCustomerUseCase.Handle(newCustomer);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return Created($"{result.Data.Id}", result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await getCustomerUseCase.Handle(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] QueryCustomerDto query)
    {
        var result = await listCustomerUseCase.Handle(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCustomerDto updateCustomer, Guid id)
    {
        if (id != updateCustomer.Id) return BadRequest("The consumer id is invalid.");

        var result = await updateCustomerUseCase.Handle(updateCustomer);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await deleteCustomerUseCase.Handle(id);

        if (!result.IsSuccess)
        {
            AddErrors(result.Errors);
            return BadRequestDefault();
        }

        return NoContent();
    }
}