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

namespace Pfizer.Configuracion_productos
{
    public partial class ProductosFraccion : Form
    {
        public List<Producto> currentListProductos = new List<Producto>();
        public Producto currentProducto = new Producto();
        public int cantidad = 0;
        public ProductosFraccion()
        {
            InitializeComponent();
        }

        private void ProductosFraccion_Load(object sender, EventArgs e)
        {
            chargeProducts();
        }
        public void chargeProducts()
        {
            currentListProductos = Controlador.CProducto.List_Product();
            ProductosBindingSource.DataSource = null;
            ProductosBindingSource.DataSource = currentListProductos;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currentListProductos = null;
                currentListProductos = Controlador.CProducto.List_Product_like(txtTexto.Text);
                ProductosBindingSource.DataSource = null;
                ProductosBindingSource.DataSource = currentListProductos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            currentProducto = currentListProductos.Find(x=>x.idProducto == id);
            MessageBox.Show(currentProducto.nombre);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (currentProducto != null)
            {
                cantidad = Convert.ToInt32(txtCantidad.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay un producto seleccionado","Pfizer 1.0.0.1", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentProducto = null;
            cantidad = 0;
            this.Close();
        }
    }
}
