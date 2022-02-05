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

namespace Pfizer
{
    public partial class Home : Form
    {
        Usuario currentUsuario = new Usuario();
        public Home()
        {
            InitializeComponent();
        }
        public Home(Usuario user)
        {
            InitializeComponent();
            user = this.currentUsuario;
        }
    }
}
