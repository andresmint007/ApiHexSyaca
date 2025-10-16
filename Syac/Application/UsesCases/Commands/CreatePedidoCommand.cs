using Application.Dtos;
using MediatR;

namespace Application.UsesCases.Commands
{
    public record CreatePedidoCommand(CrearPedidoDto Pedido) : IRequest<int>;

}
