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
    public class CPresentacion
    {
        public static string Insert_presentacion(Presentacion presentacion)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@nombre", presentacion.nombre);
                    parametros.Add("@descripcion", presentacion.descripcion);

                    var insert = db.Query<Presentacion>(
                        "spuInsert_presentacion", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Presentacion> List_Presentacion()
        {
            List<Presentacion> listPresentaciones = new List<Presentacion>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listPresentaciones = db.Query<Presentacion>(
                        "spuList_presentacion", commandType: CommandType.StoredProcedure).ToList(); 
                }
                return listPresentaciones;
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

        public static string Update_Presentacion(Presentacion presentacion)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idPresentacion", presentacion.idPresentacion);
                    parametros.Add("@nombre", presentacion.nombre);
                    parametros.Add("@descripcion", presentacion.descripcion);


                    var insert = db.Query<Presentacion>(
                        "spuUpdate_presentacion", parametros, commandType: CommandType.StoredProcedure);


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
