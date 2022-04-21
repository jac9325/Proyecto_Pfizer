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
using Pfizer.Ingresos;

namespace Pfizer.Cajas
{
    public partial class IUCaja : Form
    {
        Usuario currentUsuario = new Usuario();
        Permisos currentPermisos = new Permisos();
        Home home = new Home(); 
        Entidades.Caja currentCaja = new Entidades.Caja();
        CajaSesion currentCajaSesion = new CajaSesion();
        public double TotalGeneral = 0;
        public double TotalIngresos = 0;
        public double TotalEgresos = 0;

        public List<CajaSesion> listCajaSesion;
        public List<Entidades.Ingresos> currentListIngresos = new List<Entidades.Ingresos>();
        public List<Egresos> currentListEgresos = new List<Egresos>();
        public IUCaja(Usuario user, Home home)
        {
            this.currentUsuario = user;
            InitializeComponent();
            this.home=home;
        }
        public void cargarDatos()
        {
            currentCaja = Controlador.CCaja.getCajaUser(currentUsuario.idUsuario);
            this.lblNombreCaja.Text = currentCaja.nombre;
        }
        public void cargarCajas()
        {
            listCajaSesion = new List<CajaSesion>();
            listCajaSesion = Controlador.CCaja.list_caja_sesion(currentCaja.idCaja);
            if (listCajaSesion.Count > 0)
            {
                lblcajasesion.Text = "Caja Iniciada";
                lblcajasesion.ForeColor = Color.Green;
                btnIniciarCaja.Text = "Arquear Caja";
                btnIniciarCaja.ForeColor = Color.White;
                btnIniciarCaja.BackColor = Color.OrangeRed;
                

                currentCajaSesion = listCajaSesion[0];
                dtpFechaInicio.Value = currentCajaSesion.fechaInicio;
                lblMontoInicial.Text = currentCajaSesion.montoInicio.ToString();
            }
            else
            {
                lblcajasesion.Text = "Caja No Iniciada";
                lblcajasesion.ForeColor = Color.Red;
                btnIniciarCaja.Text = "Iniciar Caja";
                btnIniciarCaja.ForeColor = Color.White;
                btnIniciarCaja.BackColor = Color.Green;
            }
        }
        public void cargarIngresos()
        {
            try
            {
                if (currentCajaSesion != null)
                {
                    currentListIngresos = Controlador.CIngresos.getListIngresosbyCaja(currentCajaSesion.idCajaSesion);
                    IngresosBindingSource.DataSource = null;
                    IngresosBindingSource.DataSource = currentListIngresos;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Pfizer 1.0.0.0");
            }
        }
        private void IUCaja_Load(object sender, EventArgs e)
        {
            dgvIngresos.RowTemplate.Height = 30;
            reload();
            
        }
        public void reload()
        {
            cargarDatos();
            cargarCajas();
            cargarIngresos();
            cargarEgresos();
            calcularMontos();
        }
        public void calcularMontos()
        {
            foreach (var ingreso in currentListIngresos)
            {
                TotalIngresos += ingreso.monto;
            }
            foreach (var egreso in currentListEgresos)
            {
                TotalEgresos += egreso.monto;
            }

            TotalGeneral = TotalIngresos - TotalEgresos;
            lblMontoIngresos.Text = TotalIngresos.ToString();
            lblMontoEgresos.Text = TotalEgresos.ToString();
            lblMontoTotal.Text = (currentCajaSesion.montoInicio + TotalGeneral).ToString();
        }
        public void cargarEgresos()
        {
            currentListEgresos = Controlador.CEgreso.List_egresos(currentCajaSesion.idCajaSesion);
        }
        private void btnIniciarCaja_Click(object sender, EventArgs e)
        {
            if (listCajaSesion.Count > 0)
            {
                //--Arquear Caja
                IUArquearCaja formCaja = new IUArquearCaja(currentCajaSesion,TotalGeneral );
                formCaja.ShowDialog();
                reload();
                home.cargarPermisos();

            }
            else
            {
                formIniciarCaja caja = new formIniciarCaja(currentCaja);
                caja.ShowDialog();
                cargarCajas();
                home.cargarPermisos();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnEgresos_Click(object sender, EventArgs e)
        {
            try
            {
                IUEgresos formEgreso = new IUEgresos(TotalGeneral, currentUsuario.idUsuario, currentCajaSesion.idCajaSesion);
                formEgreso.ShowDialog();
                calcularMontos();
                home.cargarPermisos();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
