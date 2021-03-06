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
        public static StockProductos Stock_by_producto(int idProducto)
        {
            List<StockProductos> list = new List<StockProductos>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idProducto", value: idProducto);

                    list = db.Query<StockProductos>(
                        "spuList_Stock_Producto", parametros,commandType: CommandType.StoredProcedure).ToList(); ;
                }
                return list[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<StockProductos> stockProductos_like(string texto)
        {
            List<StockProductos> list = new List<StockProductos>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@texto",value:texto);

                    list = db.Query<StockProductos>(
                        "spuSearch_stock_precio", parametros, commandType: CommandType.StoredProcedure).ToList(); ;
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
