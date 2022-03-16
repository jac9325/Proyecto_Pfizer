using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Controlador
{
    public class CCategoria
    {
        public static string Insert_category(Categoria categoria)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@nombre", categoria.nombre);
                    parametros.Add("@@descripcion", categoria.descripcion);

                    var insert = db.Query<Categoria>(
                        "spuInser_category", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Categoria> List_Categories()
        {
            List<Categoria> listPersonas = new List<Categoria>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listPersonas = db.Query<Categoria>(
                        "spuList_category", commandType: CommandType.StoredProcedure).ToList(); ;
                }
                return listPersonas;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Delete_category(int idCategoria)
        {

            try
            {

                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idCategoria", idCategoria);
                    db.Query(
                        "spuDelete_category", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Update_Category(Categoria categoria)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCategoria", categoria.idCategoria);
                    parametros.Add("@nombre", categoria.nombre);
                    parametros.Add("@descripcion", categoria.descripcion);


                    var insert = db.Query<Categoria>(
                        "spuUpdate_category", parametros, commandType: CommandType.StoredProcedure);


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
