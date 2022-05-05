using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentaReport
    {
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double descuento { get; set; }
        public double subtotal { get; set; }
        public double igv { get; set; }
        public double total { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }

    }
}
