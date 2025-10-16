using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedidoProducto
    {
        public int DPP_IdDetalle { get; set; }
        public int PED_IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int PRO_IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int DPP_Cantidad { get; set; }
        public string DPP_CreadoPor { get; set; }
        public DateTime DPP_FechaCreacion { get; set; }
    }
}
