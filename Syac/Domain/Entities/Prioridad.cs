using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prioridad
    {
        public int PRI_IdPrioridad { get; set; }
        public string PRI_NombrePrioridad { get; set; }
        public bool PRI_Activo { get; set; }
        public string PRI_CreadoPor { get; set; }
        public DateTime PRI_FechaCreacion { get; set; }
    }
}
