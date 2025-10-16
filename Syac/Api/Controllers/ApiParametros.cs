using Application.Dtos;
using Application.UsesCases.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  
        public static class ApiParametros
        {
            public static void MapParametrosEndpoints(this IEndpointRouteBuilder app)
            {
            var group = app.MapGroup("/api/parametros").WithTags("Parámetros");

            group.MapGet("/clientes", async ([FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllClientesQuery());
                return Results.Ok(result);
            }).Produces<List<ClienteDto>>(StatusCodes.Status200OK);
            

            group.MapGet("/productos", async ([FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllProductosQuery());
                return Results.Ok(result);
            }).Produces<List<ProductoDto>>(StatusCodes.Status200OK);

            group.MapGet("/estados", async ([FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllEstadosQuery());
                return Results.Ok(result);
            }).Produces<List<EstadoDto>>(StatusCodes.Status200OK);
        }
        }
    
}
