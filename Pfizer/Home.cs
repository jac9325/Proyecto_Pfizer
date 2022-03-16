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

namespace Pfizer
{
    public partial class Home : Form
    {
        Usuario currentUsuario = new Usuario();
        Permisos currentPermisos = new Permisos();
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
            IUConfiguracion formCconfiguracion = new IUConfiguracion();
            AbrirFormEnPanel(formCconfiguracion);
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            if(currentPermisos.administrador == 1)
                lblName.Text = "Administrador" +currentUsuario.nombre;
            else 
                lblName.Text = currentUsuario.nombre;
            lblSurname.Text = currentUsuario.apellidos;
            
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
                MessageBox.Show("No existe usuaario o usted no tiene permisos");
                return;
            }
            if (currentPermisos!= null && currentPermisos.caja == 1)
            {
                if(currentPermisos.administrador == 0)
                {
                    IUCaja formCaja = new IUCaja(currentUsuario);
                    AbrirFormEnPanel(formCaja);
                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
