using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pfizer.Clientes;

namespace Pfizer.Ventas
{
    public partial class IUVentas : Form
    {
        StockProductos currentStockPrecio = new StockProductos();
        DetalleVenta currentDetalleVenta = new DetalleVenta();
        TipoDocumento currentDocumento = new TipoDocumento();
        CajaSesion currentCajaSesion = new CajaSesion();
        Usuario currentUsuario = new Usuario();
        Entidades.Clientes currentCliente = new Entidades.Clientes();
        Venta currentVenta = new Venta();

        List<LoteProducto> currentListLoteProducto = new List<LoteProducto>();
        List<DetalleVenta> currentListDetalleVenta = new List<DetalleVenta>();
        List<StockProductos> currentListStock = new List<StockProductos>();
        List<TipoDocumento> currentListDocumento = new List<TipoDocumento>();
        Home home = new Home();

        //--Para editar

        bool IsNew = true;
        decimal Total = 0;
        decimal SubTotal = 0;
        decimal Igv = 0;
        public IUVentas(Usuario user, CajaSesion cajaSesion, Home home)
        {
            InitializeComponent();
            this.currentUsuario = user;
            this.currentCajaSesion = cajaSesion;
            this.home = home;
            this.IsNew = true;
        } 
        public IUVentas(Usuario user, CajaSesion cajaSesion, Home home, Venta venta, List<DetalleVenta> detail)
        {
            InitializeComponent();
            this.currentUsuario = user;
            this.currentCajaSesion = cajaSesion;
            this.home = home;
            this.currentListDetalleVenta = detail;
            this.currentVenta = venta;
            this.IsNew = false;

        } 


        private void IUVentas_Load(object sender, EventArgs e)
        {
            dgvProductos.RowTemplate.Height = 50;
            dgvDetalleVentas.RowTemplate.Height = 30;
            cargarDatoClienteInicial();
            cargar();
            chargeDocuments();
            cbTipoDocumento.SelectedValue = 2;
            lblVendedor.Text = currentUsuario.nombre + " " + currentUsuario.apellidos;
            if (!IsNew)
            {
                chargeFilds();
            }
        }

        public void recargarForm()
        {
            txtCantidad.Text = String.Empty;
            cargar();         
            chargeDocuments();
            currentListDetalleVenta.Clear();
            dgvDetalleVentas.Refresh();
            Total = 0;
            SubTotal = 0;
            Igv = 0;
            lblTotal.Text = "0.00";
            cargarDatoClienteInicial();
            currentDocumento = currentListDocumento.Find(x=>x.idTipoDocumento ==2);
            cbTipoDocumento.SelectedValue = 2;
        }
        public void chargeFilds()
        {
            DetalleVentaBindingSource.DataSource = null;
            DetalleVentaBindingSource.DataSource = currentDetalleVenta;
        }
        public void cargar()
        {
            currentListStock = null;
            currentListStock = Controlador.CStockProducto.List_stock();
            ProductosStockBindingSource.DataSource = null;
            ProductosStockBindingSource.DataSource = currentListStock;
        }
        public void cargarDatoClienteInicial()
        {
            currentCliente = new Entidades.Clientes();
            currentCliente.idCliente = 1;
            currentCliente.nombres = "Cliente";
            currentCliente.apellidos = "eventual";
            currentCliente.NroDocumento = "11111111";
            currentCliente.tipoDocumento = "DNI";
            
            txtNroDocumentoIdentificacion.Text = currentCliente.NroDocumento;
            txtNombre.Text = currentCliente.nombres;
            txtApellidos.Text = currentCliente.apellidos;

        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            currentListStock = null;
            currentListStock = Controlador.CStockProducto.stockProductos_like(txtBuscarProducto.Text.ToString());
            ProductosStockBindingSource.DataSource = null;
            ProductosStockBindingSource.DataSource = currentListStock;
        }
        public void chargeDocuments()
        {
            try
            {
                currentListDocumento.Clear();
                currentListDocumento = Controlador.CTipoDocumento.List_documentos();
                TIpoDocumentoBindingSource.DataSource = null;
                TIpoDocumentoBindingSource.DataSource = currentListDocumento;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows.Count <= 0)
            {
                MessageBox.Show("NO hay productos disponibles");
                return;
            }

            int idStockProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            currentStockPrecio = currentListStock.Find(x=>x.idStockPrecio == idStockProducto);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (txtCantidad.Text == string.Empty || txtDescuento.Text == string.Empty)
                {
                    return;
                }
                
               //-- validaremos que no este vacio y que no este mandando valores mayores al stock actual
               if (Convert.ToInt32(txtCantidad.Text) > currentStockPrecio.StockActual)
                {
                    MessageBox.Show("La cantidad es mayor al stock actual", "pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //--validamos que el producto no este agreado
                DetalleVenta auxDetail = new DetalleVenta();
                auxDetail = currentListDetalleVenta.Find(x=>x.idProducto == currentStockPrecio.idProducto);

                if (auxDetail ==null)
                {
                    //--construimos el detalle de venta
                    DetalleVenta aux = new DetalleVenta();
                    aux.nombreProducto = currentStockPrecio.nombreProducto;
                    aux.idProducto = currentStockPrecio.idProducto;
                    aux.cantidad = Convert.ToInt32(txtCantidad.Text);
                    aux.precioUnitario = currentStockPrecio.precioVenta;
                    aux.descuento = txtDescuento.Text != string.Empty ? Convert.ToDouble(txtDescuento.Text) : 0;
                    calcularValores();
                    aux.total = Convert.ToDouble(Total);
                    aux.subtotal = Convert.ToDouble(SubTotal);
                    aux.igv = Convert.ToDouble(Igv);
                    cargarLotesProducto(currentStockPrecio.idProducto);
                    aux.loteProducto = descontarLotes(Convert.ToInt32(txtCantidad.Text), currentStockPrecio.idProducto);

                    /* agregar detalle de venta */
                    currentListDetalleVenta.Add(aux);
                    DetalleVentaBindingSource.DataSource = null;
                    DetalleVentaBindingSource.DataSource = currentListDetalleVenta;

                    txtBuscarProducto.Text = string.Empty;
                    txtCantidad.Text = 1.ToString();
                    txtDescuento.Text = 0.ToString();
                    txtBuscarProducto.Focus();
                    calcularValoresVenta();
                }
                else
                {
                    MessageBox.Show("El producto ya fue agregado", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarProducto.Text = string.Empty;
                    txtCantidad.Text = 1.ToString();
                    txtDescuento.Text = 0.ToString();
                    txtBuscarProducto.Focus();
                    return;
                }


               
            }
        }
        public void cargarLotesProducto(int id)
        {
            try
            {
                currentListLoteProducto = Controlador.CLote.getLoteProducto(id);
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
            int contador = 0;
            while (cantidadNecesaria > 0)
            {
                LoteProducto aux = new LoteProducto();
                LoteProducto aux2 = new LoteProducto();
                aux = currentListLoteProducto[contador];//--este uno de los lotes  del producto
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
        public void calcularValores()
        {
            double totalAux = currentStockPrecio.precioVenta * Convert.ToDouble(txtCantidad.Text) - Convert.ToDouble(txtDescuento.Text);
            Total = Math.Round(Convert.ToDecimal(totalAux), 2);
            SubTotal = Math.Round((Total * 100) / 118, 2);
            Igv = Total - SubTotal;
        }
        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:

                    dgvProductos.Focus();
                    break;
                case Keys.Up:
                   
                    break;
            }
        }

        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                
                int idStockProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                currentStockPrecio = currentListStock.Find(x => x.idStockPrecio == idStockProducto); //-- capturamos el valor

                //-- llenamos la informacion al dar enter o click
                txtStockActualProducto.Text = currentStockPrecio.StockActual.ToString();
                txtBuscarProducto.Text = currentStockPrecio.nombreProducto.ToString();

                //--dar turno focus al siguiente controlador que es cantidad
                txtCantidad.Focus();

                e.SuppressKeyPress = true;

            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (currentDocumento != null)
            {
                currentDocumento = currentListDocumento.Find(x => x.idTipoDocumento == Convert.ToInt32(cbTipoDocumento.SelectedValue));
                /*Siempre va a ser 1,2,3- 1: Fatura, 2: Boleta, 3: Otros*/
                int valor = Convert.ToInt32(currentDocumento.correlativoActual) + 1;
                txtNroDocumento.Text = valor.ToString();
                txtSerie.Text = currentDocumento.serie;
            }
        }

        private void IUVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentDocumento = null;
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
        
        private void dgvDetalleVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                /*capturamos el detalle*/
                int idProducto = Convert.ToInt32(dgvDetalleVentas.CurrentRow.Cells[2].Value);
                DetalleVenta auxDetalle = new DetalleVenta();
                auxDetalle = currentListDetalleVenta.Find(x=>x.idProducto == idProducto);

                /*ralizamos operaciones*/
                if (auxDetalle != null)
                {
                    currentListDetalleVenta.Remove(auxDetalle);
                    DetalleVentaBindingSource.DataSource = null;
                    DetalleVentaBindingSource.DataSource = currentListDetalleVenta;
                    calcularValoresVenta();
                }

                e.Handled = true;
            }
        }
        public void calcularValoresVenta()
        {
            
            if (currentListDetalleVenta.Count <=0)
            {
                lblTotal.Text = "00.00";
            }
            else
            {
                double total = 0;
                foreach (var detalle in currentListDetalleVenta)
                {
                    total += detalle.total;
                }
                lblTotal.Text = total.ToString("N2");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDocumento.Text == "DNI")
            {
                lblNombre.Text = "Nombre";
                lblApellidos.Visible = true;
                txtApellidos.Visible = true;
            }
            else
            {
                if (cbDocumento.Text == "RUC")
                {
                    lblNombre.Text = "Razón Social";
                    lblApellidos.Visible = false;
                    txtApellidos.Visible = false;
                }
                else
                {
                    lblNombre.Text = "Nombre";
                    lblApellidos.Visible = true;
                    txtApellidos.Visible = true;

                }
            }
        }

        private void btnCientes_Click(object sender, EventArgs e)
        {
            try
            {
                ClientesVentas formClientes = new ClientesVentas();
                formClientes.ShowDialog();
                if (formClientes.currentCliente != null)
                {
                    currentCliente = formClientes.currentCliente;
                    if (currentCliente.tipoDocumento == "DNI") //--Tiene DNI
                    {
                        cbDocumento.Text = "DNI";
                        txtNroDocumentoIdentificacion.Text = currentCliente.NroDocumento.ToString();
                        txtNombre.Text = currentCliente.nombres;
                        txtApellidos.Visible = true;
                        txtApellidos.Text = currentCliente.apellidos;

                    }
                    else
                    {
                        if (currentCliente.tipoDocumento == "RUC") //--Tiene DNI
                        {
                            cbDocumento.Text = "RUC";
                            txtNroDocumentoIdentificacion.Text = currentCliente.NroDocumento.ToString();
                            txtNombre.Text = currentCliente.nombres;
                            txtApellidos.Visible = false;


                        }
                        else
                        {
                            cbDocumento.Text = "OTROS";
                            txtNroDocumentoIdentificacion.Text = currentCliente.NroDocumento.ToString();
                            txtNombre.Text = currentCliente.nombres;
                            txtApellidos.Visible = true;
                            txtApellidos.Text = currentCliente.apellidos;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            /*  Validar que hay una sesion iniciada     */
            if (currentCajaSesion == null)
            {
                MessageBox.Show("Usted no tiene permiso para esta operación","Pfizer 1.0.0.0");
                return;
            } 
            //-- Primero Validamos cliente
            if (currentCliente.idCliente == 0)
            {
                // Crearemos un nuevo cliente
                // Validamos que tengamos los datos para crear el cliente
                if (txtNombre.Text == string.Empty || txtNroDocumentoIdentificacion.Text == string.Empty)
                {
                    MessageBox.Show("Hay campos del Cliente Vacios", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //armar cliente
                    currentCliente.idCliente = 0;
                    currentCliente.tipoDocumento = cbDocumento.Text;
                    currentCliente.nombres = txtNombre.Text;
                    currentCliente.apellidos = txtApellidos.Text == string.Empty ? "" : txtApellidos.Text;
                    currentCliente.NroDocumento = txtNroDocumentoIdentificacion.Text;
                }
            }

            //armamos el combo de venta
            currentVenta.fechaVenta = dtpFecha.Value;
            double total = 0;
            double subtotal = 0;
            double igv = 0;
            double descuento = 0;
            foreach (var detail in currentListDetalleVenta)
            {
                total += detail.total;
                subtotal += detail.subtotal;
                igv += detail.igv;
                descuento += detail.descuento;
            }
            currentVenta.total = total;
            currentVenta.subTotal = subtotal;
            currentVenta.igv = igv;
            currentVenta.descuento = descuento;
            currentVenta.idUsuario = currentUsuario.idUsuario;
            currentVenta.idCliente = currentCliente.idCliente;
            currentVenta.tipoDocumento = cbTipoDocumento.Text;
            currentVenta.nroDocumento = txtNroDocumento.Text;
            currentVenta.detalleVenta = currentListDetalleVenta;
            currentVenta.idCajaSesion = currentCajaSesion.idCajaSesion;

            DialogResult response = MessageBox.Show("¿Está seguro de vender?","Pfizer 1.0.0.0",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (response == DialogResult.OK) 
            {
                try
                {
                    Controlador.CVenta.SaveVentaAll(currentCliente,currentVenta, currentCajaSesion.idCajaSesion);
                    MessageBox.Show("La venta se realizó correctamente", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    currentDocumento = null;
                    TIpoDocumentoBindingSource.DataSource = null;
                    DetalleVentaBindingSource.DataSource = null;
                    recargarForm();
                    home.cargarPermisos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
            
        }

        public  void editDetail(DetalleVenta detail, int cantidad)
        {
            bool result = true;
            List<LoteProducto> auxListLoteUtilizados = new List<LoteProducto>();
            //-- estraemos el lote vendido estructura idLote:cantidad;
            string lote = detail.loteVenta;
            int idProducto = detail.idProducto;
            //--separamos primeramente por ;
            string[] sLote = lote.Split(';');

            foreach (var item in sLote)
            {
                string[] Lote2 = item.Split(':');
                foreach (var item2 in Lote2)
                {
                    LoteProducto aux = new LoteProducto();
                    LoteProducto aux2 = new LoteProducto();
                    aux = Controlador.CLote.GetLoteProductobyIdProductoandLote(Convert.ToInt32(Lote2[0]), idProducto);

                    aux2.idLote = aux.idLoteProducto;
                    aux2.cantidad = Convert.ToInt32(Lote2[1]);

                    auxListLoteUtilizados.Add(aux2);
                }
            }
            // Ahora traemos la cantidad existente para el lote

            StockProductos auxStock = new StockProductos();
            auxStock = Controlador.CStockProducto.Stock_by_producto(idProducto);

            //--Comprobar que existe la cantidad necesaria
            if (cantidad <= (detail.cantidad + auxStock.StockActual))
            {
                MessageBox.Show("No hay cantidad Necesaria en uno de los Stocks", "Stcok-Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //restaurar cantidad en los lotes stock
            foreach (var loteDetail in auxListLoteUtilizados)
            {
                Controlador.CLote.Restore_lote(loteDetail);
            }

            //-- Ahora si realizar la venta nuevamente en base a la nueva cantidad 
            List<LoteProducto> loteProductosDiscount = new List<LoteProducto>();
            loteProductosDiscount = descontarLotes(cantidad, idProducto);

            Controlador.CVenta.Add_lote(loteProductosDiscount);

            //-- Actualizar el detalle de venta
            string lotesVenta = "";
            foreach (var item in loteProductosDiscount)
            {
                lotesVenta = item.idLote + ":" + item.cantidad + ";";
            }
            detail.loteVenta = lotesVenta;

            Controlador.CVenta.Update_detail(detail);

        }
        
    }
}
