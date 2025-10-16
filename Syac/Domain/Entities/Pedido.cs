using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido
    {
        public int PED_IdPedido { get; set; }
        public int CLI_IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime PED_FechaRegistro { get; set; }
        public int EST_IDEstado { get; set; }
        public Estado Estado { get; set; }
        public string PED_DireccionEntrega { get; set; }
        public int PRI_IdPrioridad { get; set; }
        public Prioridad Prioridad { get; set; }
        public decimal PED_ValorParcialoTotal { get; set; }
        public string PED_CreadoPor { get; set; }
        public DateTime PED_FechaCreacion { get; set; }

        public ICollection<DetallePedidoProducto> Detalles { get; set; }
    }
}
