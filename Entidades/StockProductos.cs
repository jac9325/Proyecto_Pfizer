using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockProductos
    {
        public int idStockPrecio { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int StockActual { get; set; }
        public double precioVenta { get; set; }
        public int stockMinimo { get; set; }
    }
}
