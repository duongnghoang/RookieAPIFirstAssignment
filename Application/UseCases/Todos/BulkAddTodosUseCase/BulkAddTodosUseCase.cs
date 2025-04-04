using Application.Gateways;
using Application.UseCases.Common;
using Application.UseCases.Todos.AddTodo;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.UseCases.Todos.BulkAddTodosUseCase;

public class BulkAddTodosUseCase : IBulkAddTodosUseCase
{
    private readonly ITodoRepository _todoRepository;

    public BulkAddTodosUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<List<AddTodoResponse>>> ExecuteAsync(List<AddTodoRequest> request)
    {
        if (request.Count == 0)
        {
            return Result.Failure<List<AddTodoResponse>>("Request cannot be empty.");
        }

        if (request.Any(p => string.IsNullOrEmpty(p.Title)))
        {
            return Result.Failure<List<AddTodoResponse>>("Each todos title must not be empty");
        }

        var todos = request.Adapt<List<Todo>>();
        await _todoRepository.BulkAddAsync(todos);
        var response = todos.Adapt<List<AddTodoResponse>>();

        return Result.Success(response);
    }
}

public interface IBulkAddTodosUseCase : IBaseUseCase<List<AddTodoRequest>, List<AddTodoResponse>>
{

}