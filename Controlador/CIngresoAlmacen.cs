using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


namespace Controlador
{
    public class CIngresoAlmacen
    {
        public static void Add_ingreso_almacen(IngresoAlmacen ingresoAlmacen)
        {          
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idIngresoAlmacen", value: ingresoAlmacen.idIngresoAlmacen, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                    parameters.Add("@idLote", value: ingresoAlmacen.idLote);
                    parameters.Add("@fechaIngreso", value: ingresoAlmacen.fechaIngreso);
                    parameters.Add("@fechaModificacion", value: ingresoAlmacen.fechaModificacion);
                    parameters.Add("@tipoComprobante", value: ingresoAlmacen.tipoComprobante);
                    parameters.Add("@nroComprobante", value: ingresoAlmacen.nroComprobante);
                    parameters.Add("@precioTotal", value: ingresoAlmacen.precioTotal);
                    parameters.Add("@idUsuario", value: ingresoAlmacen.idUsuario);

                    var id = db.Execute("spuInsert_ingreso_almacen", parameters, commandType: CommandType.StoredProcedure);
                    ingresoAlmacen.idIngresoAlmacen = parameters.Get<int>("@idIngresoAlmacen");
                    //return ingresoAlmacen;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Add_detail(DetalleIngresoAlmacen detalle)
        {
            using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
            {
                //using dinamic parameter
                var parameters = new DynamicParameters();
                parameters.Add("@idDetalleProductoAlmacen", value: detalle.idDetalleIngresoAlmacen, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@idProducto", value: detalle.idProducto);
                parameters.Add("@cantidad", value: detalle.cantidad);
                parameters.Add("@fechaElaboracion", value: detalle.fechaElaboracion);
                parameters.Add("@fechaVencimiento", value: detalle.fechaVencimiento);
                parameters.Add("@idIngresoAlmacen", value: detalle.idIngresoAlmacen);
                parameters.Add("@precioCompra", value: detalle.precioCompra);
                parameters.Add("@precioVenta", value: detalle.precioVenta);
                parameters.Add("@actualizar", value: detalle.actualizar);

                var id = db.Execute("spuInsert_detalle_ingreso_almacen", parameters, commandType: CommandType.StoredProcedure);
                detalle.idDetalleIngresoAlmacen = parameters.Get<int>("@idDetalleProductoAlmacen");
                //return detalle;
            }
        }

        public static void SaveAll(IngresoAlmacen ingresoAlmacen)
        {
            Add_ingreso_almacen(ingresoAlmacen);
            foreach (var detail in ingresoAlmacen.listaIngresoAlmacen)
            {
                detail.idIngresoAlmacen = ingresoAlmacen.idIngresoAlmacen;
                Add_detail(detail);
            }
        }

        public static List<IngresoAlmacen> List_Ingresos()
        {
            List<IngresoAlmacen> listIngresos = new List<IngresoAlmacen>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    listIngresos = db.Query<IngresoAlmacen>(
                        "spuGet_list_Ingresos_almacen", commandType: CommandType.StoredProcedure).ToList();
                }
                return listIngresos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<IngresoAlmacen> List_Ingresos_fechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            List<IngresoAlmacen> listIngresos = new List<IngresoAlmacen>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@fechaInicial", value: fechaInicial);
                    parametros.Add("@fechaFinal", value: fechaFinal);

                    listIngresos = db.Query<IngresoAlmacen>(
                        "spuBuscar_ingresos_almacen_entre_fechas", parametros, commandType: CommandType.StoredProcedure).ToList();
                }
                return listIngresos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<DetalleIngresoAlmacen> List_Detalle_Ingresos(int IdIngreso)
        {
            List<DetalleIngresoAlmacen> listDetalleIngresos = new List<DetalleIngresoAlmacen>();
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@idIngresoAlmacen", value: IdIngreso);

                    listDetalleIngresos = db.Query<DetalleIngresoAlmacen>(
                        "spuGet_list_Detalle_ingreso",parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return listDetalleIngresos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //*     Actualizar detalle ingreso   *//
        public static void Update_detail(DetalleIngresoAlmacen detalle)
        {
            using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
            {
                //using dinamic parameter
                var parameters = new DynamicParameters();
                parameters.Add("@idDetalleProductoAlmacen", value: detalle.idDetalleIngresoAlmacen);
                parameters.Add("@idProducto", value: detalle.idProducto);
                parameters.Add("@cantidad", value: detalle.cantidad);
                parameters.Add("@fechaElaboracion", value: detalle.fechaElaboracion);
                parameters.Add("@fechaVencimiento", value: detalle.fechaVencimiento);
                parameters.Add("@precioCompra", value: detalle.precioCompra);
                parameters.Add("@precioVenta", value: detalle.precioVenta);
                parameters.Add("@actualizar", value: detalle.actualizar);

                var id = db.Execute("spuUpdate_detalle_ingreso_almacen", parameters, commandType: CommandType.StoredProcedure);
           
                //return detalle;
            }
        }

        //* eliminar detalle*//
        public static void Delete_detalle_ingreso(DetalleIngresoAlmacen detalle)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@idDetalleProductoAlmacen", detalle.idDetalleIngresoAlmacen);
                    parametros.Add("@idIngresoAlmacen", detalle.idIngresoAlmacen);
                    parametros.Add("@idProducto", detalle.idProducto);
                    parametros.Add("@cantidad", detalle.cantidad);

                    db.Query(
                        "spuDelete_detalle_ingreso_almacen", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}
