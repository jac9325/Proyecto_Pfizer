using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        public int idCliente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int estado { get; set; }
        public string NroDocumento { get; set; }
        public string tipoDocumento { get; set; }
    }
}
