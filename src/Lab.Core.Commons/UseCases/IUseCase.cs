using Lab.Core.Commons.Communication;

namespace Lab.Core.Commons.UseCases;

public interface IUseCase<TRequest>
{
    IOperationResult OperationResult { get; }
    Task<IOperationResult> Execute(TRequest request);
}

public interface IUseCase<TRequest, TResult>
{
    IOperationResult<TResult> OperationResult { get; }
    Task<IOperationResult<TResult>> Execute(TRequest request);
}