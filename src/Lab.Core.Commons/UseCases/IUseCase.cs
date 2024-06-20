using Lab.Core.Commons.Communication;

namespace Lab.Core.Commons.UseCases;

public interface IUseCase<TRequest>
{
    Task Execute(TRequest request);
}
public interface IUseCase<TRequest, TResult> where TResult : IOperationResult
{
    Task<TResult> Execute(TRequest request);
}

