using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        public int PRO_IdProducto { get; set; }
        public string PRO_Codigo { get; set; }
        public string PRO_Nombre { get; set; }
        public decimal PRO_ValorUnitario { get; set; }
        public bool PRO_Activo { get; set; }
        public string PRO_CreadoPor { get; set; }
        public DateTime PRO_FechaCreacion { get; set; }
    }
}
