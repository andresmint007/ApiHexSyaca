using Application.UsesCases.Commands;
using Application.UsesCases.Querys;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Config
{
    public static class DenpedencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<GetAllClientesQueryHandler>());
            services.AddMediatR(cfg =>
               cfg.RegisterServicesFromAssemblyContaining<GetAllEstadosQueryHandler>());
            services.AddMediatR(cfg =>
               cfg.RegisterServicesFromAssemblyContaining<GetAllProductosQueryHandler>());
            services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblyContaining<CreatePedidoCommandHandler>());
            services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblyContaining<GetAllPedidosQueryHandler>());
            return services;

        }
    }
}
