using Application.Dtos;
using MediatR;

namespace Application.UsesCases.Querys
{

  public record GetAllClientesQuery() : IRequest<List<ClienteDto>>;


}
