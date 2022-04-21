using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Pfizer.Ventas
{
    public partial class IUVentaRapida : Form
    {
        Usuario currentUsuario = new Usuario();
        CajaSesion currentCajaSesion = new CajaSesion();
        StockProductos currentStockProducto = new StockProductos();
        Venta currentVenta = new Venta();
        DetalleVenta currentDetalleVenta = new DetalleVenta();
        List<DetalleVenta> currentListVenta = new List<DetalleVenta>();
        List<LoteProducto> currentLoteProducto = new List<LoteProducto>();
        List<LoteProducto> LotesDiscount = new List<LoteProducto>();
        decimal Total = 0;
        decimal SubTotal = 0;
        decimal Igv = 0;

        public IUVentaRapida()
        {
            InitializeComponent();
        }

        public IUVentaRapida(Usuario usuario, CajaSesion cajasesion, StockProductos stock)
        {
            InitializeComponent();
            this.currentUsuario = usuario;
            this.currentCajaSesion = cajasesion;
            this.currentStockProducto = stock;
        }

        private void IUVentaRapida_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargarLotesProducto();
        }
        public void cargarLotesProducto()
        {
            try
            {
                currentLoteProducto = Controlador.CLote.getLoteProducto(currentStockProducto.idProducto);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<LoteProducto> descontarLotes(int cantidad, int idProducto)
        {
            List<LoteProducto> auxLoteEnviar = new List<LoteProducto>();
            int cantidadNecesaria = cantidad;
            int contador=0;
            while (cantidadNecesaria >0)
            {
                LoteProducto aux = new LoteProducto();
                LoteProducto aux2 = new LoteProducto();
                aux = currentLoteProducto[contador];//--este uno de los lotes  del producto
                if (aux.cantidad >= cantidadNecesaria)
                {
                    aux2.idProducto = idProducto;
                    aux2.cantidad = cantidadNecesaria;
                    aux2.idLote = aux.idLote;
                    auxLoteEnviar.Add(aux2);
                    cantidadNecesaria = 0;
                    contador++;
                }
                else
                {
                    aux2.cantidad = aux.cantidad;
                    aux2.idProducto = idProducto;
                    aux2.idLote = aux.idLote;
                    auxLoteEnviar.Add(aux2);
                    cantidadNecesaria -= aux.cantidad;
                    contador++;
                }
            }
            return auxLoteEnviar;
        }

        public void cargarDatos()
        {
            // cargar datos usuario
            this.lblNombreUsuario.Text = currentUsuario.nombre + " " + currentUsuario.apellidos;

            // cargar datos venta
            this.lblTotal.Text = currentStockProducto.precioVenta.ToString();
            decimal igv = decimal.Round((Convert.ToDecimal(currentStockProducto.precioVenta) * 100) / 118,2);
            lblIgv.Text = igv.ToString();

            decimal subtotal = Convert.ToDecimal(currentStockProducto.precioVenta) - igv;
            lblSubtotal.Text = subtotal.ToString();

            txtNombreProducto.Text = currentStockProducto.nombreProducto;
            txtPrecioUnitario.Text = currentStockProducto.precioVenta.ToString();
            txtCantidad.Text = "1";
            txtCantidadMax.Text = currentStockProducto.StockActual.ToString();
            txtDescuento.Text = 0.ToString();

            txtNombreProducto.Enabled = false;
            txtPrecioUnitario.Enabled = false;
            txtCantidadMax.Enabled = false;


        }
        public void calcularValores()
        {
            double totalAux = currentStockProducto.precioVenta * Convert.ToDouble(txtCantidad.Text);
            Total = Math.Round(Convert.ToDecimal(totalAux),2);
            SubTotal = Math.Round((Total * 100) / 118,2);
            Igv = Total - SubTotal;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("¿Esta seguro de realizar la venta?", "Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (response.ToString() == "OK")
            {
                calcularValores();
                //preparar datos de la venta
                currentVenta.idVenta = 0;
                currentVenta.fechaVenta = dtpFechaVenta.Value;
                currentVenta.subTotal = Convert.ToDouble(SubTotal); ;
                currentVenta.igv = Convert.ToDouble(Igv);
                currentVenta.total = Convert.ToDouble(Total);
                currentVenta.descuento = Convert.ToDouble(txtDescuento.Text);
                currentVenta.idUsuario = currentUsuario.idUsuario;
                currentVenta.idCliente = 1;

                currentDetalleVenta.idProducto = currentStockProducto.idProducto;
                currentDetalleVenta.cantidad = Convert.ToInt32(txtCantidad.Text);
                currentDetalleVenta.precioUnitario = currentStockProducto.precioVenta;
                currentDetalleVenta.descuento = Convert.ToDouble(txtDescuento.Text);
                currentDetalleVenta.subtotal = Convert.ToDouble(SubTotal);
                currentDetalleVenta.igv = Convert.ToDouble(Igv);
                currentDetalleVenta.total = Convert.ToDouble(Total);
                currentListVenta.Add(currentDetalleVenta);
                currentVenta.detalleVenta = currentListVenta;
                currentDetalleVenta.loteProducto =  descontarLotes(currentDetalleVenta.cantidad,currentDetalleVenta.idProducto);

                Controlador.CVenta.SaveAll(currentVenta, currentCajaSesion.idCajaSesion);
                MessageBox.Show("se ha guardado correctamente");
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if(txtCantidad.Text == string.Empty)
            {
                txtCantidad.Text = 0.ToString();
            }
            establecerValores();
        }
        public void establecerValores()
        {
            if (Convert.ToDouble(txtCantidad.Text) > currentStockProducto.StockActual)
            {
                MessageBox.Show("Se excede en el stock maximo existente","Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Text = 1.ToString();
                return;
            }
            decimal subtotal = decimal.Round((Convert.ToDecimal(currentStockProducto.precioVenta * Convert.ToDouble(txtCantidad.Text)) * 100) / 118, 2);
            lblIgv.Text = subtotal.ToString();

            decimal igv = Convert.ToDecimal(currentStockProducto.precioVenta * Convert.ToDouble(txtCantidad.Text) - Convert.ToDouble(subtotal));
            lblSubtotal.Text = igv.ToString();
            lblTotal.Text = Convert.ToDecimal(currentStockProducto.precioVenta * Convert.ToDouble(txtCantidad.Text)).ToString();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
