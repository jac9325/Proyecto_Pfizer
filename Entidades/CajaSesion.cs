using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajaSesion
    {
        public int idCajaSesion { get; set; }
        public int idCaja { get; set; }
        public DateTime fechaInicio{ get; set; }
        public DateTime fechaCierre { get; set; }
        public int estado{ get; set; }
        public double montoInicio { get; set; }
        public double montoCierre { get; set; }
    }
}
