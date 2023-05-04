using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Groware.Datos.Contexto;
using TodoApp.Groware.Datos.Repositorios.Implementaciones;
using TodoApp.Groware.Datos.Repositorios.Interfaces;

namespace TodoApp.Groware.Datos
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ITareasRepositorio, TareasRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}