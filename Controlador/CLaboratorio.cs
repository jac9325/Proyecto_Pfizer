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
    public class CLaboratorio
    {
        public static List<Laboratorio> List_Laboratories()
        {
            List<Laboratorio> listLaboratorios = new List<Laboratorio>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listLaboratorios = db.Query<Laboratorio>(
                        "spuList_laboratory", commandType: CommandType.StoredProcedure).ToList(); ;
                }
                return listLaboratorios;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
