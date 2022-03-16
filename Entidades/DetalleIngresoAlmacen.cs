using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleIngresoAlmacen
    {
        public int idDetalleIngresoAlmacen { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public double precioCompra { get; set; }
        public double precioVenta { get; set; }
        public DateTime fechaElaboracion { get; set; }
        public DateTime fechaVencimiento{ get; set; }
        public int idIngresoAlmacen  { get; set; }
        public int actualizar { get; set; }
        public bool eliminar { get; set; }
    }
}
