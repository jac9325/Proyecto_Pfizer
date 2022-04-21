using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LoteProducto
    {
        public int idLoteProducto { get; set; }
        public int idLote { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int estadoVenta { get; set; }

    }
}
