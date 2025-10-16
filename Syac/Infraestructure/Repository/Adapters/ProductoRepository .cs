using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infraestructure.Repository.Persistance;

namespace Infraestructure.Repository.Adapters
{
    public class ProductoRepository :IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Where(p => p.PRO_Activo)
                .ToListAsync();
        }
    }
}
