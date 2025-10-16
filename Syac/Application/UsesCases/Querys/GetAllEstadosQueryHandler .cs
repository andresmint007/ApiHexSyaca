using Application.Dtos;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases.Querys
{
    public class GetAllEstadosQueryHandler : IRequestHandler<GetAllEstadosQuery, List<EstadoDto>>
    {
        private readonly IParametricosRepository _estadoRepository;

        public GetAllEstadosQueryHandler(IParametricosRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<List<EstadoDto>> Handle(GetAllEstadosQuery request, CancellationToken cancellationToken)
        {
            var estados = await _estadoRepository.GetAllEstadosAsync();
            return estados.Select(e => new EstadoDto
            {
                Id = e.EST_IDEstado,
                Nombre = e.EST_NombreEstado,
                Activo = e.EST_Activo
            }).ToList();
        }
    }
}
