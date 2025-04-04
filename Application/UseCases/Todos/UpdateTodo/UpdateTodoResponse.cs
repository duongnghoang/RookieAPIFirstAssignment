﻿namespace Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}