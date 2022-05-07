using Dapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Controlador
{
    public class CVenta
    {
        public static void Add_venta(Venta venta)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idVenta", value: venta.idVenta, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                    parameters.Add("@fechaVenta", value: venta.fechaVenta);
                    parameters.Add("@subTotal", value: venta.subTotal);
                    parameters.Add("@igv", value: venta.igv);
                    parameters.Add("@total", value: venta.total);
                    parameters.Add("@descuento", value: venta.descuento);
                    parameters.Add("@idUsuario", value: venta.idUsuario);
                    parameters.Add("@idCliente", value: venta.idCliente);
                    parameters.Add("@tipoDocumento", value: venta.tipoDocumento);
                    parameters.Add("@nroDocumento", value: venta.nroDocumento);
                    parameters.Add("@idCajaSesion", value:venta.idCajaSesion);

                    var id = db.Execute("spuInsert_venta", parameters, commandType: CommandType.StoredProcedure);
                    venta.idVenta = parameters.Get<int>("@idVenta");
                    //return ingresoAlmacen;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Add_detail(DetalleVenta detalle, int idCajaSesion, DateTime fecha, int idUsuario)
        {
            using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
            {
                //using dinamic parameter
                var parameters = new DynamicParameters();
                parameters.Add("@idVenta", value: detalle.idVenta);
                parameters.Add("@idProducto", value: detalle.idProducto);
                parameters.Add("@cantidad", value: detalle.cantidad);
                parameters.Add("@precioUnitario", value: detalle.precioUnitario);
                parameters.Add("@descuento", value: detalle.descuento);
                parameters.Add("@subtotal", value: detalle.subtotal);
                parameters.Add("@igv", value: detalle.igv);
                parameters.Add("@total", value: detalle.total);
                parameters.Add("@idCajaSesion", value: idCajaSesion);
                parameters.Add("@idUsuario", value: idUsuario);
                parameters.Add("@fecha", value: fecha);
                parameters.Add("@loteVenta", value: detalle.loteVenta);
                

                var id = db.Execute("spuInsertDetalle_venta", parameters, commandType: CommandType.StoredProcedure);
                //return detalle;
            }           
        }
        public static void Update_detail(DetalleVenta detalle)
        {
            try
            {
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idDetalleVenta", value: detalle.idDetalleVenta);
                    parameters.Add("@idProducto", value: detalle.idProducto);
                    parameters.Add("@cantidad", value: detalle.cantidad);
                    parameters.Add("@precioUnitario", value: detalle.precioUnitario);
                    parameters.Add("@descuento", value: detalle.descuento);
                    parameters.Add("@subtotal", value: detalle.subtotal);
                    parameters.Add("@igv", value: detalle.igv);
                    parameters.Add("@total", value: detalle.total);
                    parameters.Add("@loteVenta", value: detalle.loteVenta);

                    var id = db.Execute("spuUpdate_detail", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static string Add_lote(List<LoteProducto> lotes)
        {
            string datos = "";
            try
            {
                foreach (var lote in lotes)
                {
                    Controlador.CLote.descontarLote(lote.idProducto, lote.idLote,lote.cantidad);
                    datos += lote.idLote + ":" + lote.cantidad + ";";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return datos;
        }
        public static void SaveAll(Venta venta, int idCajaSesion)
        {
            Add_venta(venta);//--
            foreach (var detail in venta.detalleVenta)
            {
                detail.idVenta = venta.idVenta;
                string dato =Add_lote(detail.loteProducto);
                detail.loteVenta = dato;
                Add_detail(detail,idCajaSesion, venta.fechaVenta, venta.idUsuario );
                
            }
        }

        public static void SaveVentaAll(Clientes cliente, Venta venta, int idCajaSesion)
        {
            using (var transactionScope = new TransactionScope())
            {
                /*  Obtenemos el Id del cliente enviado */
                int idCliente = cliente.idCliente;
                if (cliente.idCliente == 0) //entonces se creará un nuevo cliente
                {
                    idCliente = Controlador.CCliente.Insert_cliente(cliente);
                    venta.idCliente = idCliente;
                }
                
                SaveAll(venta, idCajaSesion);

                transactionScope.Complete();
            }
        }
        public static List<Venta> getListVentabySesion(int idCajaSesion)
        {
            try
            {
                List<Venta> ventas = new List<Venta>();
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idCajaSesion", value: idCajaSesion);


                    ventas = db.Query<Venta>(
                       "spugetList_Ventas_bySesion", parameters, commandType: CommandType.StoredProcedure).ToList();
                    return ventas;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<DetalleVenta> getListDetalleVentabyVenta(int idVenta)
        {
            try
            {
                List<DetalleVenta> listdetail = new List<DetalleVenta>();
                using (IDbConnection db = new
                    SqlConnection(conexion.Conexion))
                {
                    //using dinamic parameter
                    var parameters = new DynamicParameters();
                    parameters.Add("@idVenta", value: idVenta);


                    listdetail = db.Query<DetalleVenta>(
                       "spuList_detail_venta", parameters, commandType: CommandType.StoredProcedure).ToList();
                    return listdetail;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
