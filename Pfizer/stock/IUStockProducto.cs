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

namespace Pfizer.stock
{
    public partial class IUStockProducto : Form
    {
        public List<StockProductos> currentStockPrecio = new List<StockProductos>();
        public IUStockProducto()
        {
            InitializeComponent();
        }

        private void IUStockProducto_Load(object sender, EventArgs e)
        {
            dgvDatosStock.RowTemplate.Height = 50;
            cargarLista();
        }
        public void cargarLista()
        {
            currentStockPrecio = Controlador.CStockProducto.List_stock();
            StockBindingSource.DataSource = null;
            StockBindingSource.DataSource = currentStockPrecio;
        }

        private void txtxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currentStockPrecio = Controlador.CStockProducto.stockProductos_like(txtxBuscar.Text);
                StockBindingSource.DataSource = null;
                StockBindingSource.DataSource = currentStockPrecio;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
