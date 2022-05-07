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

        public static string Add_laboratorio(Laboratorio laboratorio)
        {
            string response = "Se ha insertado de manera correcta";
            try
            {
                using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@nombre", value: laboratorio.nombre);
                    parameters.Add("@descripcion", value: laboratorio.descripcion);


                    var id = db.Execute("spuInser_laboratory", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                response = ex.ToString();
            }

            return response;
            
        }

        public static string Update_laboratorio(Laboratorio laboratorio)
        {
            string response = "Se ha modificado de manera correcta";
            try
            {
                using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idLaboratorio", value: laboratorio.idLaboratorio);
                    parameters.Add("@nombre", value: laboratorio.nombre);
                    parameters.Add("@descripcion", value: laboratorio.descripcion);


                    var id = db.Execute("spuUpdate_laboratory", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                response = ex.ToString();
            }

            return response;

        }

        public static string Delete_laboratorio(Laboratorio laboratorio)
        {
            string response = "Se ha anulado de manera correcta";
            try
            {
                using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idLaboratorio", value: laboratorio.idLaboratorio);



                    var id = db.Execute("spuDelete_laboratory", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                response = ex.ToString();
            }

            return response;

        }
    }
}
