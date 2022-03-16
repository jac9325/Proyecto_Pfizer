using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IngresoAlmacen
    {
        public int idIngresoAlmacen { get; set; }
        public int idLote { get; set; }
        public string Lote { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string tipoComprobante { get; set; }
        public string nroComprobante{ get; set; }
        public double precioTotal { get; set; }
        public int idUsuario { get; set; }
        public List<DetalleIngresoAlmacen> listaIngresoAlmacen { get; set; }

    }    
}
