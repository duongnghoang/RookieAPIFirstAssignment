namespace Application.UseCases.Todos.AddTodo;

public class AddTodoRequest
{
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}