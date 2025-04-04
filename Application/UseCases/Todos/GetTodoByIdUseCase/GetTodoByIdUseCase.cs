using Application.Gateways;
using Application.UseCases.Common;
using Domain.Shared;
using Mapster;

namespace Application.UseCases.Todos.GetTodoByIdUseCase;

public class GetTodoByIdUseCase : IGetTodoByIdUseCase
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoByIdUseCase(ITodoRepository context)
    {
        _todoRepository = context;
    }

    public async Task<Result<GetTodoByIdResponse>> ExecuteAsync(Guid request)
    {
        var todo = await _todoRepository.GetByIdAsync(request);
        if (todo == null)
        {
            return Result.Failure<GetTodoByIdResponse>("Todo not found");
        }
        var response = todo.Adapt<GetTodoByIdResponse>();

        return Result.Success(response);
    }
}

public interface IGetTodoByIdUseCase : IBaseUseCase<Guid, GetTodoByIdResponse>
{
}