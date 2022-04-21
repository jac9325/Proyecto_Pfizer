using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDocumento
    {
        public int idTipoDocumento { get; set; }
        public string nombre { get; set; }
        public string serie { get; set; }
        public string correlativoInicioDocumento { get; set; }
        public string correlativoFinDocumento { get; set; }
        public string correlativoActual { get; set; }
    }
}
