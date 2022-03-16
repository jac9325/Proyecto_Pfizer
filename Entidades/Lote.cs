using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lote
    {
        public int idLote { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public DateTime fecha { get; set; }
    }
}
