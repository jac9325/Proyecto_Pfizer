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
using Pfizer.Almacen;

namespace Pfizer.Ingresos
{
    public partial class IUIngresosAlmacen : Form
    {
        public Usuario currentUser = new Usuario();
        public List<IngresoAlmacen> currentListIngresosAlmacen = new List<IngresoAlmacen>();
        public IngresoAlmacen currentIngresoAlmacen = new IngresoAlmacen(); 
        public IUIngresosAlmacen(Usuario user)
        {
            InitializeComponent();
            this.currentUser = user;
        }

        private void IUIngresosAlmacen_Load(object sender, EventArgs e)
        {
            cargarDatos();

        }
        public void cargarDatos()
        {
            currentListIngresosAlmacen = Controlador.CIngresoAlmacen.List_Ingresos();
            IngresosBindingSource.DataSource = null;
            IngresosBindingSource.DataSource = currentListIngresosAlmacen;
        }

        private void dgvIngresosAlmacen_DoubleClick(object sender, EventArgs e)
        {
            IUIngresoAlmacen form = new IUIngresoAlmacen(currentUser, currentIngresoAlmacen);
            form.ShowDialog();
        }

        private void dgvIngresosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIngresosAlmacen.Rows.Count <= 0)
            {
                return;
            }
            int id = Convert.ToInt32(dgvIngresosAlmacen.CurrentRow.Cells[0].Value);
            currentIngresoAlmacen = currentListIngresosAlmacen.Find(x=>x.idIngresoAlmacen == id);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            currentListIngresosAlmacen = null;
            currentListIngresosAlmacen = Controlador.CIngresoAlmacen.List_Ingresos_fechas(dtpFechaInicio.Value, dtpFechaFinal.Value);
            IngresosBindingSource.DataSource = null;
            IngresosBindingSource.DataSource = currentListIngresosAlmacen;
        }
    }
}
