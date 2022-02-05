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
    }
}
