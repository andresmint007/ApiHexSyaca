using Application.Dtos;
using Domain.Entities;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases.Querys
{
    public class GetAllProductosQueryHandler : IRequestHandler<GetAllProductosQuery, List<ProductoDto>>
    {
        private readonly IProductoRepository _productoRepository;

        public GetAllProductosQueryHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoDto>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            List<Producto> productos = await _productoRepository.GetAllAsync();
            return productos.Select(p => new ProductoDto
            {
                Id = p.PRO_IdProducto,
                Codigo = p.PRO_Codigo,
                Nombre = p.PRO_Nombre,
                ValorUnitario = p.PRO_ValorUnitario
            }).ToList();
        }
    }
}
