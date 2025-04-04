﻿using Application.UseCases.Common;
using Application.UseCases.Todos.AddTodo;
using Application.UseCases.Todos.BulkAddTodosUseCase;
using Application.UseCases.Todos.BulkRemoveTodosUseCase;
using Application.UseCases.Todos.DeleteTodo;
using Application.UseCases.Todos.GetAllTodosUseCase;
using Application.UseCases.Todos.GetTodoByIdUseCase;
using Application.UseCases.Todos.UpdateTodo;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services

        // Register todo use cases
        services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
        services.AddScoped<IUpdateTodoUseCase, UpdateTodoUseCase>();
        services.AddScoped<IGetAllTodosUseCase, GetAllTodosUseCase>();
        services.AddScoped<IDeleteTodoUseCase, DeleteTodoUseCase>();
        services.AddScoped<IGetTodoByIdUseCase, GetTodoByIdUseCase>();
        services.AddScoped<IBulkAddTodosUseCase, BulkAddTodosUseCase>();
        services.AddScoped<IBulkDeleteTodosUseCase, BulkDeleteTodosUseCase>();

        return services;
    }
}