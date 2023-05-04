using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoApp.Groware.Negocio.Tareas;

namespace TodoApp.Groware.Negocio
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
    
            services.AddScoped<ITareasNegocio, TareasNegocio>();

            return services;
        }
    }
}