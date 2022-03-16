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
    public class CStockProducto
    {
        public static List<StockProductos> List_stock()
        {
            List<StockProductos> list = new List<StockProductos>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    list = db.Query<StockProductos>(
                        "spuList_stock", commandType: CommandType.StoredProcedure).ToList(); ;
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
