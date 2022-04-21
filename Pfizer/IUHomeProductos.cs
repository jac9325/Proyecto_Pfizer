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
using Pfizer.Ventas;

namespace Pfizer
{
    public partial class IUHomeProductos : Form
    {
        List<StockProductos> currentListStock = new List<StockProductos>();
        Usuario currentUsuario = new Usuario();
        Entidades.Caja currentCaja = new Entidades.Caja();
        List<CajaSesion> currentListCajaSesion = new List<CajaSesion>();
        CajaSesion currentCajaSesion = new CajaSesion();
        StockProductos currentStockProducto = new StockProductos();
        public IUHomeProductos(Usuario usuario)
        {
            InitializeComponent();
            this.currentUsuario = usuario;
        }

        private void IUHomeProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.RowTemplate.Height = 45;
            dgvProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cargar();
        }
        public void cargar()
        {
            currentListStock = null;
            currentListStock = Controlador.CStockProducto.List_stock();
            ProductosStockBindingSource.DataSource = null;
            ProductosStockBindingSource.DataSource = currentListStock;
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //comprobar si hay una una sesion de caja activa referente al usuario
                currentCaja = Controlador.CCaja.getCajaUser(currentUsuario.idUsuario);

                currentListCajaSesion = Controlador.CCaja.list_caja_sesion(currentCaja.idCaja);
                if (currentListCajaSesion.Count >= 0)
                {
                    //si hay una sesion iniciada
                    currentCajaSesion = currentListCajaSesion[0];

                    //identificamos el producto que va a utilizar
                    int idStockProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                    currentStockProducto = currentListStock.Find(x=>x.idStockPrecio == idStockProducto);
                    if (currentStockProducto.StockActual <=0)
                    {
                        MessageBox.Show("No hay stock disponible");
                        return;
                    }
                    IUVentaRapida form = new IUVentaRapida(currentUsuario, currentCajaSesion, currentStockProducto);
                    form.ShowDialog();
                    cargar();
                }
                else
                {
                    MessageBox.Show("No hay una sesión iniciada", "Caja Sesión",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtProductos_TextChanged(object sender, EventArgs e)
        {
            currentListStock = null;
            currentListStock = Controlador.CStockProducto.stockProductos_like(txtProductos.Text.ToString());
            ProductosStockBindingSource.DataSource = null;
            ProductosStockBindingSource.DataSource = currentListStock;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
