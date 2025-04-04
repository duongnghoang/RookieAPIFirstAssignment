﻿namespace Application.UseCases.Todos.GetTodoByIdUseCase;

public class GetTodoByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}