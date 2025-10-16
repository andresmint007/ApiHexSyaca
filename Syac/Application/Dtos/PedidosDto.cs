using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{

        public class PedidoDto
        {
            public int PED_IdPedido { get; set; }
            public int CLI_IdCliente { get; set; }
            public string ClienteNombre { get; set; }
            public DateTime PED_FechaRegistro { get; set; }
            public int EST_IDEstado { get; set; }
            public string EstadoNombre { get; set; }
            public string PED_DireccionEntrega { get; set; }
            public int PRI_IdPrioridad { get; set; }
            public string PrioridadNombre { get; set; }
            public decimal PED_ValorParcialoTotal { get; set; }
            public List<DetallePedidoDtoRep> DetallePedidos { get; set; }
        }

        public class DetallePedidoDtoRep
        {
            public int DPP_IdDetalle { get; set; }
            public int PRO_IdProducto { get; set; }
            public string ProductoNombre { get; set; }
            public int DPP_Cantidad { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal ValorTotalDetalle { get; set; }
        }
    
}
