namespace Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}