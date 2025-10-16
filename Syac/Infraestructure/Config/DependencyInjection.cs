using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Infraestructure.Repository.Persistance;


using Domain.Ports;
using Infraestructure.Repository.Adapters;

namespace Infraestructure.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IParametricosRepository, ParametricosRepository>();

            return services;
        }
    }
}
