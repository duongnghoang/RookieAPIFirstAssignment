using Application.Gateways;
using Application.UseCases.Common;
using Infrastructure.Base;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add your infrastructure services here
        // e.g., services.AddHttpClient(), services.AddLogging(), etc.

        // Register repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}