using Application.Gateways;
using Application.UseCases.Common;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoUseCase : IUpdateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<UpdateTodoResponse>> ExecuteAsync(UpdateTodoRequest request)
    {
        var todo = await _todoRepository.GetByIdAsync(request.Id);
        if (todo == null)
        {
            return Result.Failure<UpdateTodoResponse>("Todo not found");
        }
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return Result.Failure<UpdateTodoResponse>("Title cannot be empty.");
        }

        var updateTodo = request.Adapt(todo);
        await _todoRepository.UpdateAsync(updateTodo);

        return Result.Success(updateTodo.Adapt<UpdateTodoResponse>());
    }
}

public interface IUpdateTodoUseCase : IBaseUseCase<UpdateTodoRequest, UpdateTodoResponse>
{
}