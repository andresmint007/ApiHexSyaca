using Application.Dtos;
using Application.UsesCases.Querys;
using Domain.Ports;
using MediatR;

public class GetAllPedidosQueryHandler : IRequestHandler<GetAllPedidosQuery, List<PedidoDto>>
{
    private readonly IPedidoRepository _pedidoRepository;

    public GetAllPedidosQueryHandler(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<List<PedidoDto>> Handle(GetAllPedidosQuery request, CancellationToken cancellationToken)
    {
        var pedidos = await _pedidoRepository.GetAllPedidosAsync();

        var pedidosDto = pedidos.Select(p => new PedidoDto
        {
            PED_IdPedido = p.PED_IdPedido,
            CLI_IdCliente = p.CLI_IdCliente,
            PED_FechaRegistro = p.PED_FechaRegistro,
            EST_IDEstado = p.EST_IDEstado,
            PED_DireccionEntrega = p.PED_DireccionEntrega,
            PRI_IdPrioridad = p.PRI_IdPrioridad,
            PED_ValorParcialoTotal = p.PED_ValorParcialoTotal,

            // Mapear el cliente (si quieres incluir info del cliente)
            ClienteNombre = p.Cliente?.CLI_Nombre,
            EstadoNombre = p.Estado?.EST_NombreEstado,
            PrioridadNombre = p.Prioridad?.PRI_NombrePrioridad,

            // Mapear detalles de pedido
            DetallePedidos = p.Detalles?.Select(d => new DetallePedidoDtoRep
            {
                DPP_IdDetalle = d.DPP_IdDetalle,
                PRO_IdProducto = d.PRO_IdProducto,
                DPP_Cantidad = d.DPP_Cantidad,
                ProductoNombre = d.Producto?.PRO_Nombre,
                ValorUnitario = d.Producto?.PRO_ValorUnitario ?? 0,
                ValorTotalDetalle = (d.DPP_Cantidad * (d.Producto?.PRO_ValorUnitario ?? 0))
            }).ToList()
        }).ToList();

        return pedidosDto;
    }
}
