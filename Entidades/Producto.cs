using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int  idProducto { get; set; }
        public string nombre { get; set; }
        public int idPresentacion { get; set; }
        public int idCategoria { get; set; }
        public string composicion { get; set; }
        public int @idLaboratorio { get; set; }
        public int @idMarca { get; set; }
        public int fraccion { get; set; }
        public string codigo { get; set; }
        public string @recomendacion { get; set; }
        public string ubicacion { get; set; }
        public string informacionAdicional { get; set; }
        public int estado { get; set; }
        public int idProductoHijo { get; set; }
        public int cantidad { get; set; }

    }
}
