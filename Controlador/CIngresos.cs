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
    public  class CIngresos
    {
        public static List<Ingresos> getListIngresosbyCaja(int idCajaSesion)
        {
            List<Ingresos> listIngresos = new List<Ingresos>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCajaSesion", value: idCajaSesion);

                    listIngresos = db.Query<Ingresos>(
                        "spuList_Ingresos_by_idCajaSesion", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return listIngresos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
