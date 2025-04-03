using Application.Gateways;
using Application.UseCases.Common;
using Domain.Entities;
using Domain.Shared;

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
        var todo = new Todo(request.Title, request.IsCompleted);
        await _todoRepository.AddAsync(todo);

        return Result.Success(new AddTodoResponse());
    }
}

public interface IAddTodoUseCase : IBaseUseCase<AddTodoRequest, AddTodoResponse>
{
}