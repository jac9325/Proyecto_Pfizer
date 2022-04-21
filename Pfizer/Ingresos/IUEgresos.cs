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

namespace Pfizer.Ingresos
{
    public partial class IUEgresos : Form
    {
        public double MontoTotal=0;
        public int idUsuario = 0;
        public int idCajaSesion = 0;
        Egresos currentEgreso = new Egresos();
        List<Egresos> currentListEgresos = new List<Egresos>();
        public IUEgresos(double MontoActual, int idUsuario, int idCajaSesion)
        {
            InitializeComponent();
            this.MontoTotal = MontoActual;
            this.idUsuario = idUsuario;
            this.idCajaSesion = idCajaSesion;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void IUEgresos_Load(object sender, EventArgs e)
        {
            TraerEgresosbySesion();
        }
        public void TraerEgresosbySesion()
        {
            currentListEgresos = Controlador.CEgreso.List_egresos(idCajaSesion);
            EgresosBindingSource.DataSource = null;
            EgresosBindingSource.DataSource = currentListEgresos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text == String.Empty || txtMotivo.Text == String.Empty )
            {
                MessageBox.Show("Hay campos obligatorios vacios", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MontoTotal < Convert.ToDouble(txtMonto.Text))
                {
                    MessageBox.Show("No hay suficiente dinero en la caja", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                currentEgreso.motivo = txtMotivo.Text;
                currentEgreso.monto = Convert.ToDouble(txtMonto.Text);
                currentEgreso.fecha = dtpFecha.Value;
                currentEgreso.observacion = txtObservaciones.Text == String.Empty ? "" : txtObservaciones.Text;
                currentEgreso.idUsuario = idUsuario;
                currentEgreso.idCajaSesion = idCajaSesion;

                DialogResult response = MessageBox.Show("¿Esta seguro de guardar?", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (response == DialogResult.OK)
                {
                    string rpta = Controlador.CEgreso.Insert_egreso(currentEgreso);
                    MessageBox.Show(rpta, "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       
    }
}
