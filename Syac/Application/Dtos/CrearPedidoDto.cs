using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CrearPedidoDto
    {
        public int ClienteId { get; set; }
        public string DireccionEntrega { get; set; }
        public List<DetallePedidoDto> Productos { get; set; }
        public string CreadoPor { get; set; }
    }
}
