using Application.Dtos;
using Domain.Entities;
using Domain.Ports;
using MediatR;

namespace Application.UsesCases.Querys
{

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, List<ClienteDto>>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteDto>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            List<Cliente> clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(c => new ClienteDto
            {
                Id = c.CLI_IdCliente,
                Identificacion = c.CLI_Identificacion,
                Nombre = c.CLI_Nombre,
                Direccion = c.CLI_Direccion,
                Telefono = c.CLI_Telefono
            }).ToList();
        }
    }

}
