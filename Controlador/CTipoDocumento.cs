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
    public class CTipoDocumento
    {
        public static List<TipoDocumento> List_documentos()
        {
            List<TipoDocumento> listDocumentos = new List<TipoDocumento>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listDocumentos = db.Query<TipoDocumento>(
                        "spuTraerDocumentos", commandType: CommandType.StoredProcedure).ToList();
                }
                return listDocumentos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
