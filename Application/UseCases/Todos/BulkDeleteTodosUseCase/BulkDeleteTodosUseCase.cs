using Application.Gateways;
using Application.UseCases.Common;
using Domain.Shared;

namespace Application.UseCases.Todos.BulkRemoveTodosUseCase;

public class BulkDeleteTodosUseCase : IBulkDeleteTodosUseCase
{
    private readonly ITodoRepository _todoRepository;

    public BulkDeleteTodosUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<List<Guid>>> ExecuteAsync(List<Guid> request)
    {
        foreach (var id in request)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                return Result.Failure<List<Guid>>($"Todo with ID {id} not found.");
            }
            _todoRepository.Delete(todo);
        }

        await _todoRepository.SaveChangesAsync();

        return Result.Success(request);
    }
}

public interface IBulkDeleteTodosUseCase : IBaseUseCase<List<Guid>, List<Guid>>
{
}
