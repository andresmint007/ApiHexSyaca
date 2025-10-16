using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public int CLI_IdCliente { get; set; }
        public string CLI_Identificacion { get; set; }
        public string CLI_Nombre { get; set; }
        public string CLI_Direccion { get; set; }
        public string CLI_Telefono { get; set; }
        public string CLI_CreadoPor { get; set; }
        public DateTime CLI_FechaCreacion { get; set; }
    }

}
