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

namespace Pfizer.Almacen
{
    public partial class ProductosAlmacen : Form
    {
        public List<Producto> currentListProducto = new List<Producto>();
        public Producto currentProducto = new Producto();
        public ProductosAlmacen(List<Producto> list)
        {
            InitializeComponent();
            this.currentListProducto = list;
        }

        private void ProductosAlmacen_Load(object sender, EventArgs e)
        {
            chargeProducts();
        }
        public void chargeProducts()
        {
            try
            {
                ProductosbindingSource.DataSource = null;
                ProductosbindingSource.DataSource = currentListProducto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            //try
            {
                ProductosbindingSource.DataSource = null;
                List<Producto> listAux = Controlador.CProducto.List_Product_like(txtBuscarTexto.Text.ToString());
                ProductosbindingSource.DataSource = listAux;
                dgvProductosAlmacen.Refresh();
            }/*
            catch (Exception)
            {

                throw;
            }*/
        }

        private void dgvProductosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductosAlmacen.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idProducto = Convert.ToInt32(dgvProductosAlmacen.CurrentRow.Cells[0].Value);
                    currentProducto = currentListProducto.Find(x => x.idProducto == idProducto);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (currentProducto == null)
            {
                MessageBox.Show("No se ha seleccionado ningun producto");
                this.Close();
            }
            else
            {
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentProducto = null;
            this.Close();
        }
    }
}
