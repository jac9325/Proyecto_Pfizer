using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockPrecioAlmacen
    {
        public int idStockPrecio { get; set; }
        public int idProducto { get; set; }
        public int stockActual { get; set; }
        public int precioActual { get; set; }
        public int precioVenta { get; set; }
        public int stockMinimo { get; set; }
    }
}
