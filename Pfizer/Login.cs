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
            if (txtUsuario.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Hay campos vacios", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pbLogin.Visible = true;
            pbLogin.Maximum = 100000;
            pbLogin.Minimum = 0;
            pbLogin.Value = 100;
            pbLogin.Step = 1;
            try
            {
                
                currentUsuario = CUsuario.Login(txtUsuario.Text, txtPassword.Text);
                if (currentUsuario != null)
                { 
                    int i = 0;
                    for ( i = pbLogin.Minimum; i <= pbLogin.Maximum; i = i + pbLogin.Step)
                    {
                        pbLogin.PerformStep();
                    }
                    if (i >= pbLogin.Maximum)
                    {
                        currentpermisos = Controlador.CUsuario.getPermisos(currentUsuario.idUsuario);
                        this.Hide();
                        Home home = new Home(currentUsuario, currentpermisos);
                        home.Show();
                    }
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Usted no tiene permiso para ingresar");
            }                  
        }

        private void pxImagenCerrar_Click(object sender, EventArgs e)
        {

        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
