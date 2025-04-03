using Application.UseCases.Common;
using Application.UseCases.Todos.AddTodo;
using Application.UseCases.Todos.UpdateTodo;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services

        // Register use cases
        services.AddScoped<IAddTodoUseCase, AddTodoUseCase>();
        services.AddScoped<IUpdateTodoUseCase, UpdateTodoUseCase>();
        
        return services;
    }
}