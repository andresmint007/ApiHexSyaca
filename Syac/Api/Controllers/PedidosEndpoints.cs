using Application.Dtos;
using Application.UsesCases.Commands;
using Application.UsesCases.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public static class PedidosEndpoints
    {
        public static void MapPedidosEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/pedidos").WithTags("Pedidos");

            group.MapPost("/", async ([FromServices] IMediator mediator, [FromBody] CrearPedidoDto dto) =>
            {
                var id = await mediator.Send(new CreatePedidoCommand(dto));
                return Results.Created($"/api/pedidos/{id}", new { id });
            });
            app.MapGet("/api/pedidos", async (IMediator mediator) =>
            {
                var pedidos = await mediator.Send(new GetAllPedidosQuery());
                return Results.Ok(pedidos);
            })
            .Produces<List<PedidoDto>>(StatusCodes.Status200OK);

        }
    }
}
