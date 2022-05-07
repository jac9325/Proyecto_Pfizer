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

namespace Pfizer.Ventas
{
    public partial class IUListVentasSesion : Form
    {
        public List<Venta> currentListVentas = new List<Venta>();
        Home currentHome = new Home();
        CajaSesion currentCajaSesion = new CajaSesion();
        Usuario currentUsuario = new Usuario();
        public IUListVentasSesion(List<Venta> dataVentas, Home home, CajaSesion cajaSesion, Usuario usuario)
        {
            this.currentHome = home;
            this.currentListVentas = dataVentas;
            this.currentCajaSesion = cajaSesion;
            this.currentUsuario = usuario;
            InitializeComponent();
        }

        private void IUListVentasSesion_Load(object sender, EventArgs e)
        {
            VentasBindingSource.DataSource = currentListVentas;
            dgvVentas.RowTemplate.Height = 40;
        }

        private void dgvVentas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.RowCount < 0)
                {
                    return;
                }

                Venta currentVenta = new Venta();
                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value);
                currentVenta = currentListVentas.Find(item=>item.idVenta == idVenta);

                //-- Traer los detalles de venta
                List<DetalleVenta> listDetalleVentas = new List<DetalleVenta>();
                listDetalleVentas = Controlador.CVenta.getListDetalleVentabyVenta(idVenta);
                IUVentas formVentas = new IUVentas(currentUsuario,currentCajaSesion,currentHome, currentVenta, listDetalleVentas);
                formVentas.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
