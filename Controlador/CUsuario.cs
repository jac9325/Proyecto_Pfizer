using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Entidades;

namespace Controlador
{
    public class CUsuario
    {
        public static Usuario Login(string usuario, string pasword)
        {
            List<Usuario> user = new List<Usuario>();

                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@usuario", usuario);
                    parametros.Add("@password", pasword);

                    user = db.Query<Usuario>(
                        "spu_Login", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return user[0];
        }

        public static string Insert_usuario(Usuario usuario)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@usuario", usuario.usuario);
                    parametros.Add("@password", usuario.password);
                    parametros.Add("@nombre", usuario.nombre);
                    parametros.Add("@apellidos", usuario.apellidos);

                    var insert = db.Query<Usuario>(
                        "spuInsert_users", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Usuario> List_usuarios()
        {
            List<Usuario> listUsuarios = new List<Usuario>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listUsuarios = db.Query<Usuario>(
                        "spuList_users", commandType: CommandType.StoredProcedure).ToList();
                }
                return listUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Delete_usuarios(int idUsuario)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idUsuario", idUsuario);
                    db.Query(
                        "spuDelete_users", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Update_usuarios(Usuario usuarios)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idUsuario", usuarios.idUsuario);
                    parametros.Add("@usuario", usuarios.usuario);
                    parametros.Add("@password", usuarios.password);
                    parametros.Add("@nombre", usuarios.nombre);
                    parametros.Add("@apellidos", usuarios.apellidos);


                    var insert = db.Query<Usuario>(
                        "spuUpdate_users", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Permisos getPermisos(int idUsuario)
        {
            List<Permisos>  permisos = new List<Permisos>();

            using (IDbConnection db = new
                SqlConnection(conexion.Conexion))
            {
                var parametros = new DynamicParameters();

                parametros.Add("@idUsuario", idUsuario);

                permisos = db.Query<Permisos>(
                    "spuListarPermisosUsuarios", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            return permisos[0]; 
        }
        public static string Update_permisos(Permisos permisos)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idUsuario", permisos.idUsuario);
                    parametros.Add("@caja", permisos.caja);
                    parametros.Add("@compra", permisos.compra);
                    parametros.Add("@venta", permisos.venta);
                    parametros.Add("@almacen", permisos.almacen);
                    parametros.Add("@administrador", permisos.administrador);


                    var insert = db.Query<Permisos>(
                        "spuUpdate_permisos", parametros, commandType: CommandType.StoredProcedure);


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
