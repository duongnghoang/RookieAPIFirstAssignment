namespace Application.UseCases.Todos.GetAllTodosUseCase;

public class GetAllTodoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}