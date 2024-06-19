using System.Diagnostics;
using Lab.Customers.Application.DTOs.Inputs;
using Lab.Customers.Application.Interfaces;
using Lab.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Customers.Api.Controllers;

[Route("api/customers")]
public class CustomerController(
    ICreateCustomerUseCase createCustomerUseCase,
    IGetCustomerUseCase getCustomerUseCase,
    IUpdateCustomerUseCase updateCustomerUseCase,
    IDeleteCustomerUseCase deleteCustomerUseCase,
    ILogger<CustomerController> logger)
    : MainController
{
    [HttpPost]
    public async Task<IActionResult> Create(NewCustomerDto newCustomer)
    {
        var result = await createCustomerUseCase.ExecuteAsync(newCustomer);

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
        var customer = await getCustomerUseCase.GetByIdAsync(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] QueryCustomerDto query)
    {
        using var activity = Activity.Current;

        activity?.SetTag("query.Filter", query.Filter);
        var result = await getCustomerUseCase.ListAsync(query);

        if (result.Items.Any()) activity?.AddEvent(new ActivityEvent("Customer list not found."));

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCustomerDto updateCustomer, Guid id)
    {
        if (id != updateCustomer.Id) return BadRequest("The consumer id is invalid.");

        var result = await updateCustomerUseCase.ExecuteAsync(updateCustomer);

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
        var result = await deleteCustomerUseCase.ExecuteAsync(id);

        if (result.HasErrors())
        {
            AddErrors(result.GetErrors());
            return BadRequestDefault();
        }

        return NoContent();
    }
}