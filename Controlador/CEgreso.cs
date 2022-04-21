using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CEgreso
    {
        public static List<Egresos> List_egresos(int idCajaSesion)
        {
            List<Egresos> listEgresos = new List<Egresos>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCajaSesion", idCajaSesion);

                    listEgresos = db.Query<Egresos>(
                        "spuListEgresos_by_sesion", parametros,commandType: CommandType.StoredProcedure).ToList();
                }
                return listEgresos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Insert_egreso(Egresos egreso)
        {
            string response = "Se ha insertado de manera correcta";
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@monto", egreso.monto);
                    parametros.Add("@motivo", egreso.motivo);
                    parametros.Add("@observacion", egreso.observacion);
                    parametros.Add("@fecha", egreso.fecha);
                    parametros.Add("@idUsuario", egreso.idUsuario);
                    parametros.Add("@idCajaSesion", egreso.idCajaSesion);

                    var insert = db.Query<Egresos>(
                        "spuInsert_egreso", parametros, commandType: CommandType.StoredProcedure);


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
