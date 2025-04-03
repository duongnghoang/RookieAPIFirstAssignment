using Domain.Shared;

namespace Application.UseCases.Common;

public interface IBaseUseCase<in TRequest, TResponse>
{
    Task<Result<TResponse>> ExecuteAsync(TRequest request);
}