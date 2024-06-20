using Lab.Core.Commons.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab.WebApi.Core.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected ICollection<string> Errors = new List<string>();

    protected ActionResult ResponseDefault(object? result = null)
    {
        if (IsValidOperation()) return Ok(result);

        return BadRequestDefault();
    }

    protected ActionResult BadRequestDefault()
    {
        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "details", Errors.ToArray() }
        }));
    }

    protected ActionResult ResponseDefault(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros) AddError(erro.ErrorMessage);

        return ResponseDefault();
    }

    protected ActionResult ResponseDefault<T>(OperationResult<T> result)
    {
        HasErrors(result);
        return ResponseDefault(result.GetData());
    }

    protected ActionResult ResponseDefault(OperationResult result)
    {
        HasErrors(result);
        return ResponseDefault();
    }

    protected bool HasErrors(OperationResult result)
    {
        if (result is null || !result.GetErrors().Any()) return false;

        foreach (var message in result.GetErrors().Values) AddError(message);

        return true;
    }

    protected bool IsValidOperation()
    {
        return !Errors.Any();
    }

    protected void AddError(string erro)
    {
        Errors.Add(erro);
    }

    protected void AddErrors(IReadOnlyDictionary<string, string> errors)
    {
        foreach (var error in errors) AddError(error.Value);
    }

    protected void ClearErrors()
    {
        Errors.Clear();
    }
}