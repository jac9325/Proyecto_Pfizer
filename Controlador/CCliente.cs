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
    public class CCliente
    {
        public static int Insert_cliente(Clientes cliente)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCliente", value: cliente.idCliente, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                    parametros.Add("@nombres", cliente.nombres);
                    parametros.Add("@apellidos", cliente.apellidos);
                    parametros.Add("@NroDocumento", cliente.NroDocumento);
                    parametros.Add("@tipoDocumento", cliente.tipoDocumento);

                    var id = db.Execute("spuInsert_clientes", parametros, commandType: CommandType.StoredProcedure);

                    return id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Clientes> List_Clientes()
        {
            List<Clientes> listClientes = new List<Clientes>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listClientes = db.Query<Clientes>(
                        "spuList_clientes", commandType: CommandType.StoredProcedure).ToList();
                }
                return listClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Clientes> List_Clientes_like_documento(string texto)
        {
            List<Clientes> listClientes = new List<Clientes>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@text", texto);

                    listClientes = db.Query<Clientes>(
                        "spuList_clientes_like_tipo_documento", parametros,commandType: CommandType.StoredProcedure).ToList();
                }
                return listClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Clientes> List_Clientes_like_nombre(string texto)
        {
            List<Clientes> listClientes = new List<Clientes>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@text", texto);

                    listClientes = db.Query<Clientes>(
                        "spuList_clientes_like_nombre", parametros,commandType: CommandType.StoredProcedure).ToList();
                }
                return listClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
