using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permisos
    {
        public int idPerfil { get; set; }
        public int idUsuario { get; set; }
        public int caja { get; set; }
        public int venta { get; set; }
        public int compra { get; set; }
        public int almacen { get; set; }
        public int administrador { get; set; }
    }
}
