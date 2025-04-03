namespace Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoRequest
{
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}