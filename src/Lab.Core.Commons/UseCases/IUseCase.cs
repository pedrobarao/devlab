namespace Lab.Core.Commons.UseCases;

public interface IUseCase<TRequest>
{
    Task Execute(TRequest request);
}
public interface IUseCase<TRequest, TResult>
{
    Task<TResult> Execute(TRequest request);
}