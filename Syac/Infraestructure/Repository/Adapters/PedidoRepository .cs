using Application.Dtos;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static Infraestructure.Repository.Persistance;

namespace Infraestructure.Repository.Adapters
{

    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CrearPedidoAsync(Pedido pedido, List<DetallePedidoProducto> detalles)
        {
            using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();

                foreach (DetallePedidoProducto detalle in detalles)
                {
                    detalle.PED_IdPedido = pedido.PED_IdPedido;
                }

                await _context.DetallePedidoProductos.AddRangeAsync(detalles);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return pedido.PED_IdPedido;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<List<Pedido>> GetAllPedidosAsync()
        {
            return await _context.Pedidos
                    .Include(p => p.Cliente)
                    .Include(p => p.Estado)
                    .Include(p => p.Prioridad)
                    .Include(p => p.Detalles)
                        .ThenInclude(d => d.Producto)
                    .ToListAsync();
        }
    }

}
