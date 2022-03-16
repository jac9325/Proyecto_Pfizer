using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Entidades;

namespace Pfizer
{
    public partial class Login : Form
    {
        Usuario currentUsuario = new Usuario();
        Permisos currentpermisos= new Permisos();
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                currentUsuario = CUsuario.Login(txtUsuario.Text, txtPassword.Text);
                if (currentUsuario != null)
                {
                    currentpermisos = Controlador.CUsuario.getPermisos(currentUsuario.idUsuario);
                    this.Hide();
                    Home home = new Home(currentUsuario, currentpermisos);
                    home.Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Usted no tiene permiso para ingresar");
            }                     
        }
    }
}
