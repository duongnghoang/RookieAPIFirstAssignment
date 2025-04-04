namespace Application.UseCases.Todos.DeleteTodo;

public class DeleteTodoResponse
{
    public Guid DeletedId { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}