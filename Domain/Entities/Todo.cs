namespace Domain.Entities;

public class Todo : Entity
{
    public Todo(string title, bool isCompleted)
    {
        Title = title;
        IsCompleted = isCompleted;
    }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
}