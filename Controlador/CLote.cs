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
    public class CLote
    {
        public static Lote Add_lote(Lote lote)
        {
            using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
            {
                //using dinamic parameter
                var parameters = new DynamicParameters();
                parameters.Add("@idLote", value: lote.idLote, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@nombre", value: lote.nombre);
                parameters.Add("@codigo", value: lote.codigo);
                parameters.Add("@descripcion", value: lote.descripcion);
                parameters.Add("@fecha", value: lote.fecha);

                var id =  db.Execute("spuInsert_lote", parameters, commandType: CommandType.StoredProcedure);
                lote.idLote = parameters.Get<int>("@idLote");
                return lote;
            }
        }
        public static Lote getLote(int idlote)
        {
            List<Lote> lote = new List<Lote>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idLote", idlote);

                    lote = db.Query<Lote>(
                        "spuGetLote", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return lote[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
