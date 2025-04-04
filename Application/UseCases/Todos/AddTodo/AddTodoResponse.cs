namespace Application.UseCases.Todos.AddTodo;

public class AddTodoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}