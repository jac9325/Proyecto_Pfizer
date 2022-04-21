using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entidades;

namespace Controlador
{
    public class CArqueos
    {
        public static string Insert_arqueo(Arqueo arqueo)
        {
            string response = "Se ha realizado el arquero correctamente";
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@montoInicial", arqueo.montoIncial);
                    parametros.Add("@fechaCierre", arqueo.fechaCierre);
                    parametros.Add("@montoCierre", arqueo.montocierre);
                    parametros.Add("@montoSistema", arqueo.montoSistema);
                    parametros.Add("@idCajaSesion", arqueo.idCajaSesion);
                    parametros.Add("@faltante", arqueo.faltante);
                    parametros.Add("@sobrante", arqueo.sobrante);
                    parametros.Add("@montoFisico", arqueo.montoFisico);

                    var insert = db.Query<Egresos>(
                        "spuRealizar_arqueo_caja", parametros, commandType: CommandType.StoredProcedure);


                    return response;
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
    }
}
