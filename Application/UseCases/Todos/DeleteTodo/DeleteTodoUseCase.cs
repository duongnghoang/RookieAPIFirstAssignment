using Application.Gateways;
using Application.UseCases.Common;
using Domain.Shared;

namespace Application.UseCases.Todos.DeleteTodo;

public class DeleteTodoUseCase : IDeleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    public DeleteTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<DeleteTodoResponse>> ExecuteAsync(Guid request)
    {
        var todo = await _todoRepository.GetByIdAsync(request);
        if (todo == null)
        {
            return Result.Failure<DeleteTodoResponse>("Todo not found");
        }
        _todoRepository.Delete(todo);
        await _todoRepository.SaveChangesAsync();

        return Result.Success(new DeleteTodoResponse
        {
            DeletedId = todo.Id,
            Title = todo.Title!,
            IsCompleted = todo.IsCompleted,
        });
    }
}

public interface IDeleteTodoUseCase : IBaseUseCase<Guid, DeleteTodoResponse>
{

}