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
    public class CProducto
    {
        public static string Insert_producto(Producto prroducto)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@nombre", prroducto.nombre);
                    parametros.Add("@idPresentacion", prroducto.idPresentacion);
                    parametros.Add("@idCategoria", prroducto.idCategoria);
                    parametros.Add("@composicion", prroducto.composicion);
                    parametros.Add("@idLaboratorio", prroducto.idLaboratorio);
                    parametros.Add("@idMarca", prroducto.idMarca);
                    parametros.Add("@fraccion", prroducto.fraccion);
                    parametros.Add("@codigo", prroducto.codigo);
                    parametros.Add("@recomendacion", prroducto.recomendacion);
                    parametros.Add("@ubicacion", prroducto.ubicacion);
                    parametros.Add("@informacionAdicional", prroducto.informacionAdicional);
                    parametros.Add("@cantidad", prroducto.cantidad);
                    parametros.Add("@idProductoHijo", prroducto.idProductoHijo);

                    var insert = db.Query<Producto>(
                        "spuInsertar_productos", parametros, commandType: CommandType.StoredProcedure);


                    return insert.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Producto> List_Product_like(string text)
        {
            List<Producto> listProducts = new List<Producto>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@text", text);

                    listProducts = db.Query<Producto>(
                        "spuList_products_like", parametros,commandType: CommandType.StoredProcedure).ToList();
                }
                return listProducts;
            } 
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Producto> List_Product()
        {
            List<Producto> listProducts = new List<Producto>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listProducts = db.Query<Producto>(
                        "spuListar_productos", commandType: CommandType.StoredProcedure).ToList();
                }
                return listProducts;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Delete_producto(int idProducto)
        {

            try
            {

                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idProducto", idProducto);
                    db.Query(
                        "spuEliminar_producto", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Update_Producto(Producto producto)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idProducto", producto.idProducto);
                    parametros.Add("@nombre", producto.nombre);
                    parametros.Add("@idPresentacion", producto.idPresentacion);
                    parametros.Add("@idCategoria", producto.idCategoria);
                    parametros.Add("@composicion", producto.composicion);
                    parametros.Add("@idLaboratorio", producto.idLaboratorio);
                    parametros.Add("@idMarca", producto.idMarca);
                    parametros.Add("@fraccion", producto.fraccion);
                    parametros.Add("@codigo", producto.codigo);
                    parametros.Add("@recomendacion", producto.recomendacion);
                    parametros.Add("@ubicacion", producto.ubicacion);
                    parametros.Add("@informacionAdicional", producto.informacionAdicional);
                    parametros.Add("@cantidad", producto.cantidad);
                    parametros.Add("@idProductoHijo", producto.idProductoHijo);


                    var insert = db.Query<Producto>(
                        "spuEditar_productos", parametros, commandType: CommandType.StoredProcedure);


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
