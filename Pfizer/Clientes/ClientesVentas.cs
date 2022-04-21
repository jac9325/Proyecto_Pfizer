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

namespace Pfizer.Clientes
{
    public partial class ClientesVentas : Form
    {
        public List<Entidades.Clientes> currentListClientes;
        public Entidades.Clientes currentCliente = new Entidades.Clientes();
        public ClientesVentas()
        {
            InitializeComponent();
        }

        private void ClientesVentas_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            cargarClientes();
        }
        public void cargarClientes()
        {
            try
            {
                currentListClientes = new List<Entidades.Clientes>();
                currentListClientes = Controlador.CCliente.List_Clientes();
                ClientesBindingSource.DataSource = null;
                ClientesBindingSource.DataSource = currentListClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SearchByName(string texto)
        {
            currentListClientes = new List<Entidades.Clientes>();
            currentListClientes = Controlador.CCliente.List_Clientes_like_nombre(texto);
            ClientesBindingSource.DataSource = null;
            ClientesBindingSource.DataSource = currentListClientes;
        }
        public void SearchByDocument(string texto)
        {
            currentListClientes = new List<Entidades.Clientes>();
            currentListClientes = Controlador.CCliente.List_Clientes_like_documento(texto);
            ClientesBindingSource.DataSource = null;
            ClientesBindingSource.DataSource = currentListClientes;
        }

        private void cbDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbDatos.Text == "Nombres")
            {
                SearchByName(txtBuscar.Text);
            }
            else
            {
                SearchByDocument(txtBuscar.Text);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.RowCount <= 0)
                return;
            int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            currentCliente = currentListClientes.Find(x=>x.idCliente == idCliente);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (currentCliente != null)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (currentCliente != null)
            {
                currentCliente = null;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
