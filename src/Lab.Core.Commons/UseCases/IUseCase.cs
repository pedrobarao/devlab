using Lab.Core.Commons.Communication;

namespace Lab.Core.Commons.UseCases;

public interface IRequestValidate<in TRequest>
{
    bool ValidateInput(TRequest request);
}

public interface IUseCase<in TRequest> : IRequestValidate<TRequest>
{
    IOperationResult OperationResult { get; }
    Task<IOperationResult> Execute(TRequest request);
}

public interface IUseCase<in TRequest, TResult> : IRequestValidate<TRequest>
{
    IOperationResult<TResult> OperationResult { get; }
    Task<IOperationResult<TResult>> Execute(TRequest request);
}