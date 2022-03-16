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

namespace Pfizer.Almacen
{
    public partial class IUIngresoAlmacen : Form
    {
        public double total = 0;
        public Usuario currentUsuario = new Usuario();
        public Producto currentProducto = new Producto();
        public List<Producto> currentListProducto = new List<Producto>();
        public DetalleIngresoAlmacen currentDetalle = new DetalleIngresoAlmacen();
        public List<DetalleIngresoAlmacen> currentListDetalleIngresoAlmacen = new List<DetalleIngresoAlmacen>();
        public Lote currentLote = new Lote();
        public IngresoAlmacen currentIngresoAlmacen = new IngresoAlmacen();
        public bool isNew = true;

        public IUIngresoAlmacen(Usuario user,IngresoAlmacen ingreso)
        {
            InitializeComponent();
            this.currentUsuario = user;
            this.currentIngresoAlmacen = ingreso;
            this.isNew = false;
            this.btnDeleteDetail.Visible = true;
            this.pxProductos.Enabled = false;
            this.btnAgregar.Text = "Aceptar";
            this.btnEliminar.Visible = false;
            this.btnGuardar.Text = "Actualizar";
        }
        public IUIngresoAlmacen(Usuario user)
        {
            InitializeComponent();
            this.currentUsuario = user;
            this.isNew = true;
            dgvDetalleIngreso.Columns[10].Visible = false;
            btnDeleteDetail.Visible = false;
        }
        public void chrargeProducts()
        {
            try
            {
                currentListProducto = null;
                currentListProducto = Controlador.CProducto.List_Product();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void cargarListDetalle()
        {
            currentListDetalleIngresoAlmacen = Controlador.CIngresoAlmacen.List_Detalle_Ingresos(currentIngresoAlmacen.idIngresoAlmacen);
            DetalleIngresoAlmacenBindingSource.DataSource = null;
            DetalleIngresoAlmacenBindingSource.DataSource = currentListDetalleIngresoAlmacen;
        }
        private void IUIngresoAlmacen_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = currentUsuario.nombre + " " + currentUsuario.apellidos;
            
            chrargeProducts();
            if(isNew == false)
            {
                cargarListDetalle();
                this.btnDeleteDetail.Visible = true;
                this.pxImagen.Enabled = false;
                txtComprobante.Enabled = false;
                cargarLote();
                cargarDatosIngreso();
            }
            else
            {
                this.btnDeleteDetail.Visible = false;
            }
        }

        public void cargarLote()
        {
            currentLote = Controlador.CLote.getLote(currentIngresoAlmacen.idLote);
            if (currentLote != null)
            {
                lblNombreLote.Text = currentLote.nombre;
            }
        }
        public void cargarDatosIngreso()
        {
            txtComprobante.Text = currentIngresoAlmacen.nroComprobante;
            cbTipoComprobante.Text = currentIngresoAlmacen.tipoComprobante;
            lblPrecioTotal.Text = currentIngresoAlmacen.precioTotal.ToString();
            dtpFechaIngreso.Value = currentIngresoAlmacen.fechaIngreso;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pxProductos_Click(object sender, EventArgs e)
        {
            try
            {
                if(currentListProducto.Count <= 0)
                {
                    return;
                }
                else
                {
                    ProductosAlmacen productsAlmacen = new ProductosAlmacen(currentListProducto);
                    productsAlmacen.ShowDialog();
                    if(productsAlmacen.currentProducto != null)
                    {
                       currentProducto = productsAlmacen.currentProducto;
                        lblNombreProducto.Text = currentProducto.nombre;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool validateDetalle(List<DetalleIngresoAlmacen> list, Producto producto)
        {
            bool response = false;
            DetalleIngresoAlmacen detalle = new DetalleIngresoAlmacen();
            detalle = list.Find(x=>x.idProducto == producto.idProducto);
            if (detalle != null)
            {
                response = true;
            }
            return response;
        }
        private double CuentaTotal()
        {
            double total = 0;
            foreach (var detalle in currentListDetalleIngresoAlmacen)
            {
                total = detalle.precioCompra * detalle.cantidad;
            }
            return total;
        }
        private bool validateFields()
        {
            bool response = true;
            if (currentProducto == null || txtCantidad.Text == String.Empty || txtPrecioCompra.Text == string.Empty || txtPrecioVenta.Text == string.Empty)
                response = false;
            return response;
        }
        private void cleanFields()
        {
            currentProducto = null;
            lblNombreProducto.Text = "Ningun producto seleccionado";
            txtPrecioCompra.Text = String.Empty;
            txtPrecioVenta.Text = String.Empty;
            txtCantidad.Text = String.Empty;

        }
        private double calcularTotal()
        {
            double cant = 0;
            foreach (var item in currentListDetalleIngresoAlmacen)
            {
                cant += item.cantidad * item.precioCompra;
            }
            return cant;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                if (validateFields() == false)
                {
                    MessageBox.Show("faltan llenar algunos campos");
                    return;
                }
                try
                {
                    //armamos el detalle a agregar
                    currentDetalle = new DetalleIngresoAlmacen();
                    currentDetalle.idProducto = currentProducto.idProducto;
                    currentDetalle.nombreProducto = currentProducto.nombre;
                    currentDetalle.cantidad = Convert.ToInt32(txtCantidad.Text);
                    currentDetalle.precioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                    currentDetalle.precioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                    currentDetalle.fechaElaboracion = dtpFechaElaboracion.Value;
                    currentDetalle.fechaVencimiento = dtpFechaVencimiento.Value;
                    currentDetalle.actualizar = chkActualizar.Checked == true ? 1 : 0;

                    //evaluamos si agregamos o simplemente aumentamos la cantidad
                    if (validateDetalle(currentListDetalleIngresoAlmacen, currentProducto))
                    {
                        DialogResult response = MessageBox.Show("Este producto ya fue agregado, ¿desea aumentar la cantidad?", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (response.ToString() == "OK")
                        {
                            DetalleIngresoAlmacen aux = currentListDetalleIngresoAlmacen.Find(x => x.idProducto == currentProducto.idProducto);
                            var indice = currentListDetalleIngresoAlmacen.IndexOf(aux);
                            currentDetalle.cantidad = currentDetalle.cantidad + aux.cantidad;

                            currentListDetalleIngresoAlmacen.RemoveAt(indice);
                            currentListDetalleIngresoAlmacen.Insert(indice, currentDetalle);
                            dgvDetalleIngreso.Refresh();
                            lblPrecioTotal.Text = CuentaTotal().ToString();
                            cleanFields();
                            lblPrecioTotal.Text = calcularTotal().ToString(); 

                        }
                    }
                    else
                    {
                        currentListDetalleIngresoAlmacen.Add(currentDetalle);
                        DetalleIngresoAlmacenBindingSource.DataSource = null;
                        DetalleIngresoAlmacenBindingSource.DataSource = currentListDetalleIngresoAlmacen;
                        lblPrecioTotal.Text = CuentaTotal().ToString();
                        cleanFields();
                        lblPrecioTotal.Text = calcularTotal().ToString();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                currentDetalle.cantidad = Convert.ToInt32(txtCantidad.Text);
                currentDetalle.precioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                currentDetalle.precioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                currentDetalle.fechaElaboracion = dtpFechaElaboracion.Value;
                currentDetalle.fechaVencimiento = dtpFechaVencimiento.Value;
                DetalleIngresoAlmacenBindingSource.DataSource = null;
                DetalleIngresoAlmacenBindingSource.DataSource = currentListDetalleIngresoAlmacen;
                cleanFields();
                lblPrecioTotal.Text = calcularTotal().ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (currentDetalle == null)
            {
                MessageBox.Show("No hay un detalle seleccionado");
            }
            else
            {
                currentListDetalleIngresoAlmacen.Remove(currentDetalle);
                DetalleIngresoAlmacenBindingSource.DataSource = null;
                DetalleIngresoAlmacenBindingSource.DataSource = currentListDetalleIngresoAlmacen;
                dgvDetalleIngreso.Refresh();
                cleanFields();
            }
        }

        private void pxImagen_Click(object sender, EventArgs e)
        {
            LotesBuscar lote = new LotesBuscar();
            lote.ShowDialog();
            if (lote.currentLote != null)
            {
                currentLote = lote.currentLote;
                lblNombreLote.Text = currentLote.nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                try
                {
                    if (currentListDetalleIngresoAlmacen == null || currentLote.nombre == null || txtComprobante.Text == string.Empty)
                    {
                        MessageBox.Show("Hay algunos campos que faltan llenar","Pfizer 1.0.0.2");
                        return;
                    }

                    DialogResult response = MessageBox.Show("¿Esta seguro de guardar?","Pfizer",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                    if (response.ToString() == "OK")
                    {
                        //primero se guarda el lote
                        currentLote = Controlador.CLote.Add_lote(currentLote);

                        //guardamos el ingreso de almacen
                        currentIngresoAlmacen.idLote = currentLote.idLote;
                        currentIngresoAlmacen.fechaIngreso = dtpFechaIngreso.Value;
                        currentIngresoAlmacen.fechaModificacion = dtpFechaIngreso.Value;
                        currentIngresoAlmacen.tipoComprobante = cbTipoComprobante.Text;
                        currentIngresoAlmacen.nroComprobante = txtComprobante.Text;
                        currentIngresoAlmacen.precioTotal = Convert.ToDouble(lblPrecioTotal.Text);
                        currentIngresoAlmacen.idUsuario = currentUsuario.idUsuario;
                        currentIngresoAlmacen.listaIngresoAlmacen = currentListDetalleIngresoAlmacen;

                        Controlador.CIngresoAlmacen.SaveAll(currentIngresoAlmacen);
                        MessageBox.Show("se ha guardado correctamente");
                        CleanFieldsAll();
                    }
                    else
                    {
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
               DialogResult response = MessageBox.Show("Está seguro de actualizar?", "Pfizer 1.0.0.2",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (response.ToString() == "OK")
                {
                    try
                    {
                        //actualizar los valores
                        foreach (var item in currentListDetalleIngresoAlmacen)
                        {
                            Controlador.CIngresoAlmacen.Update_detail(item);
                        }
                        MessageBox.Show("Se ha actualizado correctamente los registros ");
                        this.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        private void CleanFieldsAll()
        {
            this.currentLote = null;
            this.currentListDetalleIngresoAlmacen = null;
            txtComprobante.Text = String.Empty;
            lblPrecioTotal.Text = "00.00";
            cleanFields();
            
        }
        private void dgvDetalleIngreso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalleIngreso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleIngreso.Rows.Count <= 0)
            {
                return;
            }
            else
            {
                int rowindex = dgvDetalleIngreso.CurrentRow.Index;
                int columnIndex = dgvDetalleIngreso.CurrentCell.ColumnIndex;

                currentDetalle = null;
                int idProducto = Convert.ToInt32(dgvDetalleIngreso.CurrentRow.Cells[1].Value);
                currentDetalle = currentListDetalleIngresoAlmacen.Find(x=>x.idProducto == idProducto);
                currentDetalle.eliminar = !currentDetalle.eliminar; 
                
                if (!isNew)
                {
                    txtCantidad.Text = currentDetalle.cantidad.ToString();
                    txtPrecioCompra.Text = currentDetalle.precioCompra.ToString();
                    txtPrecioVenta.Text = currentDetalle.precioVenta.ToString();
                    dtpFechaElaboracion.Value = currentDetalle.fechaElaboracion;
                    dtpFechaVencimiento.Value = currentDetalle.fechaVencimiento;
                    chkActualizar.Checked = currentDetalle.actualizar == 1? true:false;
                }
            }    
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (currentListDetalleIngresoAlmacen.Count <= 0)
            {
                MessageBox.Show("No hay registros disponibles","Pfizer 1.0.0.2");
                return;
            }
            
            MessageBox.Show("Recuerda que la fecha limite para eliminar registros es 24 horas", "Pfizer 1.0.0.2");
                
            List<DetalleIngresoAlmacen> detalle = new List<DetalleIngresoAlmacen>();
            detalle = currentListDetalleIngresoAlmacen.FindAll(z=>z.eliminar == true);
            DialogResult response = MessageBox.Show("Esta seguro de eliminar?","Pfizer 1.0.0.2",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (response.ToString() == "OK")
            {
                try
                {
                    //eliminar 
                    foreach (var item in detalle)
                    {
                        Controlador.CIngresoAlmacen.Delete_detalle_ingreso(item);
                        currentListDetalleIngresoAlmacen.Remove(item);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                MessageBox.Show("Se a eliminado correctamente", "Pfizer");
                DetalleIngresoAlmacenBindingSource.DataSource = null;
                DetalleIngresoAlmacenBindingSource.DataSource = currentListDetalleIngresoAlmacen;
                dgvDetalleIngreso.Refresh();
                lblPrecioTotal.Text = calcularTotal().ToString();
                cleanFields();

            }
            
        }
    }
}
