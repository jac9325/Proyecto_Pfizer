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
        public bool isNewEgreso = true;
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

                if (isNewEgreso)
                {
                    if (MontoTotal < Convert.ToDouble(txtMonto.Text))
                    {
                        MessageBox.Show("No hay suficiente dinero en la caja", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Egresos newEgreso = new Egresos();
                    newEgreso.motivo = txtMotivo.Text;
                    newEgreso.monto = Convert.ToDouble(txtMonto.Text);
                    newEgreso.fecha = dtpFecha.Value;
                    newEgreso.observacion = txtObservaciones.Text == String.Empty ? "" : txtObservaciones.Text;
                    newEgreso.idUsuario = idUsuario;
                    newEgreso.idCajaSesion = idCajaSesion;

                    DialogResult response = MessageBox.Show("¿Esta seguro de guardar?", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (response == DialogResult.OK)
                    {
                        string rpta = Controlador.CEgreso.Insert_egreso(newEgreso);
                        MessageBox.Show(rpta, "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TraerEgresosbySesion();
                        isNewEgreso = true;
                    }
                }
                else
                {
                    currentEgreso.monto = Convert.ToDouble(txtMonto.Text);
                    currentEgreso.motivo = txtMotivo.Text;
                    currentEgreso.observacion = txtObservaciones.Text;
                    DialogResult response = MessageBox.Show("¿Esta seguro de modificar?", "Pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (response == DialogResult.OK)
                    {
                        string rpta = Controlador.CEgreso.Insert_egreso(currentEgreso);
                        MessageBox.Show(rpta, "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TraerEgresosbySesion();
                        isNewEgreso = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (currentListEgresos.Count <= 0)
            {
                MessageBox.Show("No se ha seleccionado ningun egreso", "Pfizer - Egreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("¿Esta seguro de eliminar?", "Pfizer - Egreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string response = Controlador.CEgreso.Delete_egreso(currentEgreso);
                MessageBox.Show(response, "Pfizer - Egreso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                TraerEgresosbySesion();
                txtMonto.Text = String.Empty;
                txtMotivo.Text = String.Empty; 
                txtObservaciones.Text = String.Empty;
                isNewEgreso = true;
            }

        }

        private void dgvEgresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEgresos.RowCount <= 0)
                {
                    MessageBox.Show("No hay registros", "Pfizer - Egreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idEgreso = Convert.ToInt32(dgvEgresos.CurrentRow.Cells[0].Value);

                currentEgreso = currentListEgresos.Find(x=>x.idEgreso == idEgreso);
                txtMonto.Text = currentEgreso.monto.ToString();
                txtMotivo.Text = currentEgreso.motivo.ToString();
                txtObservaciones.Text = currentEgreso.observacion;
                isNewEgreso = false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
