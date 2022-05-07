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
        public static string Update_Lote(Lote lote)
        {
            string response = "Se ha modificado de manera correcta";
            try
            {
                using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idLote", value: lote.idLote);
                    parameters.Add("@nombre", value: lote.nombre);
                    parameters.Add("@codigo", value: lote.codigo);
                    parameters.Add("@descripcion", value: lote.descripcion);
                    parameters.Add("@fecha", value: lote.fecha);

                    var id = db.Execute("spuInsert_lote", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                response = ex.ToString();
            }
            return response;
        }
        public static void Restore_lote(LoteProducto lote)
        {
            string response = "ok";
            try
            {
                using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idLoteProducto", value: lote.idLoteProducto);
                    parameters.Add("@cantidad", value: lote.cantidad);


                    var id = db.Execute("spuRestaurarLote", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                response = ex.ToString();
            }
        }
        public static void Add_lote_producto(LoteProducto lote)
        {
            using (IDbConnection db = new
                   SqlConnection(conexion.Conexion))
            {
                //using dinamic parameter
                var parameters = new DynamicParameters();
                parameters.Add("@idLote", value: lote.idLote);
                parameters.Add("@idProducto", value: lote.idProducto);
                parameters.Add("@cantidad", value: lote.cantidad);

                var id = db.Execute("spuInsertLote", parameters, commandType: CommandType.StoredProcedure);
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

        public static List<LoteProducto> getLoteProducto(int idProducto)
        {
            List<LoteProducto> lote = new List<LoteProducto>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idProducto", idProducto);

                    lote = db.Query<LoteProducto>(
                        "spuGetLotes_productos_by_producto", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return lote;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static LoteProducto GetLoteProductobyIdProductoandLote(int idlote, int idProducto)
        {
            List<LoteProducto> lote = new List<LoteProducto>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idLote", idlote);
                    parametros.Add("@idProducto", idProducto);

                    lote = db.Query<LoteProducto>(
                        "spuGetLoteProductobyIdLoteandIdProducto", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return lote[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void descontarLote(int idProducto,int idLote, int cantidad)
        {
            List<LoteProducto> lote = new List<LoteProducto>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idLote", idLote);
                    parametros.Add("@idProducto", idProducto);
                    parametros.Add("@cantidad", cantidad);

                    lote = db.Query<LoteProducto>(
                        "spuEdit_loteproducto", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Lote> List_lotes()
        {
            List<Lote> listLotes = new List<Lote>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listLotes = db.Query<Lote>(
                        "spuListar_Lotes", commandType: CommandType.StoredProcedure).ToList();
                }
                return listLotes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
