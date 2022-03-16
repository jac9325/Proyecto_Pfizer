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
    public class CCaja
    {
        public static Caja getCajaUser(int idUsuario)
        {
            List<Caja> listcaja = new List<Caja>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idUsuario", idUsuario);

                    listcaja = db.Query<Caja>(
                        "spuCharge_caja_user",parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return listcaja[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<CajaSesion> list_caja_sesion(int idcaja)
        {
            List<CajaSesion> listcaja = new List<CajaSesion>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCaja", idcaja);

                    listcaja = db.Query<CajaSesion>(
                        "spuTraerCajasIniciadas", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return listcaja;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string IniciarCaja(CajaSesion cajasesion)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idCaja", cajasesion.idCaja);
                    parametros.Add("@fechaInicio", cajasesion.fechaInicio);
                    parametros.Add("@fechaCierre", cajasesion.fechaCierre);
                    parametros.Add("@MontoInicio", cajasesion.montoInicio);

                    var insert = db.Query<CajaSesion>(
                        "spuIniciar_Caja", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
