using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pfizer.Category
{
    public partial class IUCategoria : Form
    {
        public IUCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        //metodos de proceso
        public void botones(bool value)
        {
                btnGuardar.Enabled = !value;
                btnEditar.Enabled = !value;
                btnCancelar.Enabled = !value;
                btnNuevo.Enabled = value;

                txtName.Enabled = !value;
                txtDescription.Enabled = !value;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IUCategoria_Load(object sender, EventArgs e)
        {
            botones(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            botones(false);
        }
    }
}
