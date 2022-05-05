using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pfizer.Report
{
    public partial class RerportComprobante : Form
    {
        public RerportComprobante()
        {
            InitializeComponent();
        }

        private void RerportComprobante_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
