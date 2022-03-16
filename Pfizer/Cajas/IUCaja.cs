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

namespace Pfizer.Cajas
{
    public partial class IUCaja : Form
    {
        Usuario currentUsuario = new Usuario();
        Permisos currentPermisos = new Permisos();
        Entidades.Caja currentCaja = new Entidades.Caja();
        CajaSesion currentSesion = new CajaSesion();
        List<CajaSesion> listCajaSesion;
        public IUCaja(Usuario user)
        {
            this.currentUsuario = user;
            InitializeComponent();
        }
        public void cargarDatos()
        {
            currentCaja = Controlador.CCaja.getCajaUser(currentUsuario.idUsuario);
            this.lblNombreCaja.Text = currentCaja.nombre;
        }
        public void cargarCajas()
        {
            listCajaSesion = new List<CajaSesion>();
            listCajaSesion = Controlador.CCaja.list_caja_sesion(currentCaja.idCaja);
            if (listCajaSesion.Count > 0)
            {
                lblcajasesion.Text = "Caja Iniciada";
                lblcajasesion.ForeColor = Color.Green;
            }
        }
        private void IUCaja_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargarCajas();
        }

        private void btnIniciarCaja_Click(object sender, EventArgs e)
        {
            if (listCajaSesion.Count > 0 )
            {
                MessageBox.Show("Ya hay una sesion iniciada, se mostrara la caja sesion","pfizer 1.0.0.2");
                return;
            }
            else
            {
                formIniciarCaja caja = new formIniciarCaja(currentCaja);
                caja.ShowDialog();
                cargarCajas();
            }
        }
    }
}
