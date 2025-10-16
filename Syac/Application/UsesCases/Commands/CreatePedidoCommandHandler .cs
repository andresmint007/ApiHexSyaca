using Application.Dtos;
using Application.Enums;
using Domain.Entities;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases.Commands
{
    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommand, int>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CreatePedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<int> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            CrearPedidoDto dto = request.Pedido;

            decimal total = dto.Productos.Sum(p => p.ValorUnitario * p.Cantidad);

            int prioridadId = total switch
            {
                <= 500 => 1,        
                <= 1000 => 2,       
                _ => 3              
            };

            Pedido pedido = new Pedido
            {
                CLI_IdCliente = dto.ClienteId,
                PED_FechaRegistro = DateTime.Now,
                EST_IDEstado = (int)Estados.Registrado, 
                PED_DireccionEntrega = dto.DireccionEntrega,
                PRI_IdPrioridad = prioridadId,
                PED_ValorParcialoTotal = total,
                PED_CreadoPor = dto.CreadoPor,
                PED_FechaCreacion = DateTime.Now
            };

            var detalles = dto.Productos.Select(p => new DetallePedidoProducto
            {
                PRO_IdProducto = p.ProductoId,
                DPP_Cantidad = p.Cantidad,
                DPP_CreadoPor = dto.CreadoPor,
                DPP_FechaCreacion = DateTime.Now
            }).ToList();

            var idPedido = await _pedidoRepository.CrearPedidoAsync(pedido, detalles);

            return idPedido;
        }
    }
}
