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
    public partial class formIniciarCaja : Form
    {
        Entidades.Caja currentCaja = new Entidades.Caja();
        CajaSesion currentSesion = new CajaSesion();
        public bool Iniciar = true;
        public formIniciarCaja(Entidades.Caja caja)
        {
            this.currentCaja = caja;
            this.Iniciar = true;
            InitializeComponent();
        }

        public formIniciarCaja(Entidades.Caja caja, CajaSesion sesion)
        {
            this.currentSesion = sesion;
            this.currentCaja = caja;
            this.Iniciar = true;
            InitializeComponent();
        }

        private void formIniciarCaja_Load(object sender, EventArgs e)
        {
            if (Iniciar)
            {
                lblmontofecha.Hide();
                txtMontoFinal.Hide();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            currentSesion.idCaja = currentCaja.idCaja;
            currentSesion.fechaCierre = dtpCierre.Value;
            currentSesion.fechaInicio = dtpInicio.Value;
            currentSesion.montoInicio = Convert.ToDouble(txtMontoInicio.Text);

            string id = Controlador.CCaja.IniciarCaja(currentSesion);
            MessageBox.Show("caja iniciada correctamente");
            this.Hide();
        }
    }
}
