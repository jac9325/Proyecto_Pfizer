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
using Pfizer.Users;
using Pfizer.Category;
using Pfizer.Configuracion_productos;
using Pfizer.Almacen;
using Pfizer.stock;
using Pfizer.Ingresos;
using Pfizer.Cajas;
using Pfizer.Ventas;

namespace Pfizer
{
    public partial class Home : Form
    {
        Usuario currentUsuario = new Usuario();
        Permisos currentPermisos = new Permisos();
        public CajaSesion currentCajaSesion = new CajaSesion();
        public List<CajaSesion> currentListCajaSesion = new List<CajaSesion>();
        Entidades.Caja currentCaja = new Entidades.Caja();
        public List<Entidades.Ingresos> currentListIngresos = new List<Entidades.Ingresos>();
        public List<Egresos> currentListEgresos = new List<Egresos>();
        public double MontoInicial = 0;
        public double MontoIngresos = 0;
        public double MontoEgresos = 0;
        public double TotalGeneral = 0;


        public int admin = 0;
        public int almacen = 0;
        public int ventas = 0;

              
        public void cargarPermisos()
        {
            //try
            {
                //--comprobamos los permisos del usuario
                if (currentPermisos.administrador == 1)
                {
                    admin = 1;
                    almacen = 1;
                    ventas = 1;
                }
                else
                {
                    admin = 0;
                    //--no es administrador
                    ventas = currentPermisos.venta;
                    almacen = currentPermisos.almacen;
                    pAdministracion.Visible = false;
                    pAlmacen.Visible = almacen == 1 ? true : false;
                    pVentas.Visible = ventas == 1 ? true : false;
                }
                //cargamos caja sesion si es que tiene permisos de ventas

                if (admin == 1 || ventas == 1)
                {
                    //comprobar si hay una una sesion de caja activa referente al usuario
                    currentCaja = Controlador.CCaja.getCajaUser(currentUsuario.idUsuario);

                    currentListCajaSesion = Controlador.CCaja.list_caja_sesion(currentCaja.idCaja);
                    if (currentListCajaSesion.Count > 0)
                    {
                        //si hay una sesion iniciada
                        currentCajaSesion = currentListCajaSesion[0];
                    }
                    else
                    {
                        currentCajaSesion = null;
                    }
                }
                else
                {
                    currentCajaSesion = null;
                }
                //-- Si hay la caja esta iniciada cargar valores
                if (currentCajaSesion != null)
                {
                    //--cargar el icono
                    pxListVentas.Visible = true;
                    lblEstadoCaja.Text = "Caja Iniciada";
                    lblEstadoCaja.ForeColor = Color.Green;
                    //--Si hay una caja iniciada cargamos los ingresos y egresos
                    currentListEgresos = Controlador.CEgreso.List_egresos(currentCajaSesion.idCajaSesion);
                    currentListIngresos = Controlador.CIngresos.getListIngresosbyCaja(currentCajaSesion.idCajaSesion);

                    //--Recalcular valores
                    MontoEgresos = 0;
                    MontoIngresos = 0;
                    
                    if (currentListEgresos == null)
                    {
                        MontoEgresos = 0;
                    }
                    else
                    {
                        foreach (var egreso in currentListEgresos)
                        {
                            MontoEgresos += egreso.monto;
                        }
                    }

                    if (currentListIngresos == null)
                    {
                        MontoIngresos = 0;
                    }
                    else
                    {
                        foreach (var ingreso in currentListIngresos)
                        {
                            MontoIngresos += ingreso.monto;
                        }
                    }

                    //-- Establecer datos iniciales en el Home
                    lblTotalEgresos.Text = MontoEgresos.ToString();
                    lblTotalIngresos.Text = MontoIngresos.ToString();
                    lblMontoInicial.Text = currentCajaSesion.montoInicio.ToString();
                    lblTotalGeneral.Text = (MontoIngresos + currentCajaSesion.montoInicio - MontoEgresos).ToString();

                }
                else
                {
                    lblEstadoCaja.Text = "Caja no Iniciada";
                    lblEstadoCaja.ForeColor = Color.Red;
                    lblTotalEgresos.Text = 0.ToString();
                    lblTotalIngresos.Text = 0.ToString();
                    lblMontoInicial.Text = 0.ToString();
                    lblTotalGeneral.Text = 0.ToString();
                }


            }
            /*catch (Exception)
            {

                throw;
            }*/
        }
        public void darFoco(Control uno, Control dos)
        {
            if (uno.Focus())
            {
                dos.Focus();
            }
        }
        public Home()
        {
            InitializeComponent();
        }
        public Home(Usuario user, Permisos permisos)
        {
            InitializeComponent();
            this.currentUsuario = user;
            this.currentPermisos = permisos;
        }
        #region Metodos necesarios para cargar paneles
        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.pContainer.Controls.Count > 0)
                this.pContainer.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(fh);
            this.pContainer.Tag = fh;
            fh.Show();
        }
        #endregion

        private void pxImagenCerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta seguro de salir?", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog.ToString() == "OK")
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            IUUsuario formCompra = new IUUsuario(currentUsuario);
            AbrirFormEnPanel(formCompra);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            cargarPermisos();
            if (currentPermisos.administrador == 1)
            {
                lblName.Text = "Administrador" + currentUsuario.nombre;
                cargarPanel();
            }
            else
            {
                lblName.Text = currentUsuario.nombre;
                lblSurname.Text = currentUsuario.apellidos;
            }
                
            
            
        }
        public void cargarPanel()
        {
            if (currentPermisos.venta == 1)
            {
                IUHomeProductos iUHomeProductos = new IUHomeProductos(currentUsuario);
                AbrirFormEnPanel(iUHomeProductos);
            }
        }
        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            IUIngresoAlmacen formAlmacen = new IUIngresoAlmacen(currentUsuario);
            AbrirFormEnPanel(formAlmacen);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IUStockProducto form = new IUStockProducto();
            AbrirFormEnPanel(form);
        }

        private void btnIngresosAlmacen_Click(object sender, EventArgs e)
        {
            IUIngresosAlmacen formAlmacen = new IUIngresosAlmacen(currentUsuario);
            AbrirFormEnPanel(formAlmacen);
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            if (currentUsuario == null)
            {
                MessageBox.Show("No existe usuario o usted no tiene permisos");
                return;
            }
            if (currentPermisos!= null && currentPermisos.venta == 1)
            {
                IUCaja formCaja = new IUCaja(currentUsuario, this);
                AbrirFormEnPanel(formCaja);
                cargarPermisos();
            }
            else
            {
                MessageBox.Show("Usted no tine permisos para ingresar", "Pfizer - Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            IUConfiguracion formCconfiguracion = new IUConfiguracion();
            AbrirFormEnPanel(formCconfiguracion);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            IUUsuario formCompra = new IUUsuario(currentUsuario);
            AbrirFormEnPanel(formCompra);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cargarPanel();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            cargarPanel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //comprobar si hay una una sesion de caja activa referente al usuario
                currentCaja = Controlador.CCaja.getCajaUser(currentUsuario.idUsuario);

                currentListCajaSesion = Controlador.CCaja.list_caja_sesion(currentCaja.idCaja);
                if (currentListCajaSesion.Count > 0)
                {
                    //si hay una sesion iniciada
                    currentCajaSesion = currentListCajaSesion[0];
                    IUVentas form = new IUVentas(currentUsuario, currentCajaSesion,this);
                    AbrirFormEnPanel(form);
                }
                else
                {
                    MessageBox.Show("La caja no esta iniciada", "Caja Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Pfizer 1.0.0.0", MessageBoxButtons.OK);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnVentaEspecial_Click(object sender, EventArgs e)
        {

        }

        private void pxListVentas_Click(object sender, EventArgs e)
        {
            List<Venta> list = new List<Venta>();
            if (currentCajaSesion.idCajaSesion != 0)
            {
                list = Controlador.CVenta.getListVentabySesion(currentCajaSesion.idCajaSesion);
                IUListVentasSesion form = new IUListVentasSesion(list, this, currentCajaSesion, currentUsuario);
                AbrirFormEnPanel(form);

            }
        }
    }
}
