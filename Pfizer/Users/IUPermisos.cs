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

namespace Pfizer.Users
{
    public partial class IUPermisos : Form
    {
        public Usuario currentUsuario = new Usuario();
        public Permisos currentPermisos = new Permisos();
        public IUPermisos(Usuario user)
        {
            InitializeComponent();
            this.currentUsuario = user;
        }

        private void chkCompra_OnChange(object sender, EventArgs e)
        {

        }

        private void IUPermisos_Load(object sender, EventArgs e)
        {
            chargeData();

        }
        public void chargeData()
        {
            currentPermisos = Controlador.CUsuario.getPermisos(currentUsuario.idUsuario);
            if (currentPermisos == null)
            {
                MessageBox.Show("No hay un usuario");
            }
            else
            {
                if (currentPermisos.caja == 0)
                    chkCaja.Checked = false;
                else
                    chkCaja.Checked = true;

                if (currentPermisos.compra == 0)
                    chkCompra.Checked = false;
                else
                    chkCompra.Checked = true;

                if (currentPermisos.venta == 0)
                    chkVenta.Checked = false;
                else
                    chkVenta.Checked = true;

                if (currentPermisos.almacen == 0)
                    chkAlmacen.Checked = false;
                else
                    chkAlmacen.Checked = true;

                if (currentPermisos.administrador == 0)
                    chkAdmin.Checked = false;
                else
                    chkAdmin.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(currentUsuario == null)
            {
                return;
            }
            Permisos permisos = new Permisos();
            if(chkAdmin.Checked == true)
            {
                permisos.idUsuario = currentUsuario.idUsuario;
                permisos.compra = 1;
                permisos.venta = 1;
                permisos.caja = 1;
                permisos.almacen = 1;
                permisos.administrador = 1;
            }
            else
            {
                permisos.idUsuario = currentUsuario.idUsuario;
                permisos.compra = chkCompra.Checked == true ? 1 : 0;
                permisos.venta = chkVenta.Checked == true ? 1 : 0;
                permisos.caja = chkCaja.Checked == true ? 1 : 0;
                permisos.almacen = chkAlmacen.Checked == true ? 1 : 0;
            }
            

            string id = Controlador.CUsuario.Update_permisos(permisos);
            MessageBox.Show("se a guardado con exito","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void chkAdmin_OnChange(object sender, EventArgs e)
        {
            if (chkAdmin.Checked == true)
            {
                chkVenta.Enabled = false;
                chkCompra.Enabled = false;
                chkCaja.Enabled = false;
                chkAlmacen.Enabled = false;

                chkCaja.Checked = true;
                chkVenta.Checked = true;
                chkCompra.Checked = true;
                chkAlmacen.Checked = true;
            }
            else
            {
                chkVenta.Enabled = true;
                chkCompra.Enabled = true;
                chkCaja.Enabled = true;
                chkAlmacen.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
