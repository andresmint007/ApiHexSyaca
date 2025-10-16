    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estado
    {
        public int EST_IDEstado { get; set; }
        public string EST_NombreEstado { get; set; }
        public bool EST_Activo { get; set; }
        public string EST_CreadoPor { get; set; }
        public DateTime EST_FechaCreacion { get; set; }
    }
}
