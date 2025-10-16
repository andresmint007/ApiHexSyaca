using Domain.Entities;

namespace Domain.Ports
{

    public interface IPedidoRepository
    {
        Task<int> CrearPedidoAsync(Pedido pedido, List<DetallePedidoProducto> detalles);
        Task<List<Pedido>> GetAllPedidosAsync();
    }

}
