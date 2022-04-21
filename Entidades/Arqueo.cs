using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Arqueo
    {
        public int idArqueo { get; set; }
        public double montoIncial { get; set; }
        public DateTime fechaCierre { get; set; }
        public double montocierre { get; set; }
        public double montoSistema { get; set; }
        public int estado { get; set; }
        public int idCajaSesion { get; set; }
        public double faltante { get; set; }
        public double sobrante { get; set; }
        public double montoFisico { get; set; }
    }
}
