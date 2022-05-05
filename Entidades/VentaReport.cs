using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentaReport
    {
        public int idVenta { get; set; }
        public DateTime fechaVenta { get; set; }
        public double subTotal { get; set; }
        public double igv { get; set; }
        public double total { get; set; }
        public double descuento { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        List<DetalleVentaReport> listaDetalleVentas = new List<DetalleVentaReport>();



    }
}
