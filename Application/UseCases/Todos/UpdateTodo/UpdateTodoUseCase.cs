using Application.UseCases.Common;
using Domain.Shared;

namespace Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoUseCase : IUpdateTodoUseCase
{
    public Task<Result<UpdateTodoResponse>> ExecuteAsync(UpdateTodoRequest request)
    {
        throw new NotImplementedException();
    }
}

public interface IUpdateTodoUseCase : IBaseUseCase<UpdateTodoRequest, UpdateTodoResponse>
{
}