using Application.Gateways;
using Application.UseCases.Common;
using Domain.Shared;
using Mapster;

namespace Application.UseCases.Todos.GetAllTodosUseCase;

public class GetAllTodosUseCase : IGetAllTodosUseCase
{
    private readonly ITodoRepository _todoRepository;

    public GetAllTodosUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<List<GetAllTodoResponse>>> ExecuteAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        var response = todos.Adapt<List<GetAllTodoResponse>>();

        return Result.Success(response);
    }
}

public interface IGetAllTodosUseCase : IBaseUseCase<List<GetAllTodoResponse>>
{
}