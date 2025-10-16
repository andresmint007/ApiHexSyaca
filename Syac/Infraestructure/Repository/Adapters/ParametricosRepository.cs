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
    public class ParametricosRepository :IParametricosRepository
    {
        private readonly AppDbContext _context;

        public ParametricosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> GetAllEstadosAsync()
        {
            return await _context.Estados.ToListAsync();
        }
    }
}
