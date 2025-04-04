using Application.Gateways;
using Application.UseCases.Common;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.UseCases.Todos.AddTodo;

public class AddTodoUseCase : IAddTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public AddTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<AddTodoResponse>> ExecuteAsync(AddTodoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.Failure<AddTodoResponse>("Title cannot be empty.");
        }
        var todo = request.Adapt<Todo>();
        await _todoRepository.AddAsync(todo);
        var response = todo.Adapt<AddTodoResponse>();

        return Result.Success(response);
    }
}

public interface IAddTodoUseCase : IBaseUseCase<AddTodoRequest, AddTodoResponse>
{
}