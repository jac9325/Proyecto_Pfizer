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

namespace Pfizer.Cajas
{
    public partial class IUArquearCaja : Form
    {
        public CajaSesion currentSesion = new CajaSesion();
        public double MontoActual = 0;
        public Arqueo currentArqueo = new Arqueo();

        public double sobrante = 0;
        public double faltante = 0;
        public double montocierre = 0;

        public IUArquearCaja(CajaSesion sesionActual, double MontoActual )
        {
            InitializeComponent();
            this.currentSesion = sesionActual;
            this.MontoActual = MontoActual;
        }

        private void IUArquearCaja_Load(object sender, EventArgs e)
        {
            lblMontoSistema.Text = MontoActual.ToString();
            this.lblMontoIncioCaja.Text = currentSesion.montoInicio.ToString();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txtMontoCajaFisica.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una cantidad correcta", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                double MontoFisico = Convert.ToDouble(txtMontoCajaFisica.Text);
                if (MontoFisico == MontoActual)
                {
                    sobrante = 0;
                    faltante = 0;
                    montocierre = MontoActual;
                }
                else
                {
                    if (MontoFisico > MontoActual)
                    {
                        sobrante = MontoFisico - MontoActual;
                        faltante = 0;
                        montocierre = MontoFisico;
                    }
                    else
                    {
                        sobrante = 0;
                        faltante = MontoActual - MontoFisico;
                        montocierre = MontoActual;
                    }
                }
                lblMontoFaltante.Text = faltante.ToString();
                lblMontoSobrante.Text = sobrante.ToString();

                
            }
        }

        private void txtMontoCajaFisica_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnArquear_Click(object sender, EventArgs e)
        {
            if (txtMontoCajaFisica.Text == String.Empty)
            {
                MessageBox.Show("Hay campos vacios", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--armar Arqueos
            currentArqueo.montoFisico = Convert.ToDouble(txtMontoCajaFisica.Text);
            currentArqueo.montoIncial = currentSesion.montoInicio;
            currentArqueo.fechaCierre = System.DateTime.Now;
            currentArqueo.montocierre = montocierre;
            currentArqueo.montoSistema = MontoActual;
            currentArqueo.idCajaSesion = currentSesion.idCajaSesion;
            currentArqueo.faltante = faltante;
            currentArqueo.sobrante = sobrante;
            currentArqueo.montoFisico = montocierre;

            DialogResult result = MessageBox.Show("Esta seguro de realizar el arqueo, esta operación es irreversible", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                string response = Controlador.CArqueos.Insert_arqueo(currentArqueo);
                MessageBox.Show(response, "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                return;
            }
        }
    }
}
