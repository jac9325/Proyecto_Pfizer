using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controlador
{
    public class CMarca
    {
        public static string Insert_marca(Marca marca)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@nombre", marca.nombre);
                    parametros.Add("@@descripcion", marca.descripcion);

                    var insert = db.Query<Marca>(
                        "spuInsert_marca", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Marca> List_marca()
        {
            List<Marca> listMarcas = new List<Marca>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listMarcas = db.Query<Marca>(
                        "spuList_marca", commandType: CommandType.StoredProcedure).ToList();
                }
                return listMarcas;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Delete_presentacion(int idPresentacion)
        {

            try
            {

                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idPresentacion", idPresentacion);
                    db.Query(
                        "spuDelete_presentacion", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Update_Marca(Marca marca)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idMarca", marca.idMarca);
                    parametros.Add("@nombre", marca.nombre);
                    parametros.Add("@descripcion", marca.descripcion);


                    var insert = db.Query<Marca>(
                        "spuUpdate_marca", parametros, commandType: CommandType.StoredProcedure);


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
