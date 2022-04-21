using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Egresos
    {
        public int idEgreso { get; set; }
        public double monto{ get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public int idUsuario { get; set; }
        public int idCajaSesion { get; set; }
    }
}
