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
    public partial class IUConfiguracion : Form
    {

        //Necesarios para guardar o editar
        public bool isNew = true;
        public bool isNewPresentacion = true;
        public bool isNewMarca = true;
        public bool isNewLaboratorio = true;
        public bool isNewLote = true;
        public bool isNewProducts = true;

        /* para crear nuevas categorias*/
        public Categoria currentCategoria = new Categoria();
        public Presentacion currentPresentacion = new Presentacion();
        public Marca currentMarca = new Marca();
        public Laboratorio currentLaboratorio = new Laboratorio();
        public Lote currentLote = new Lote();
        public Producto currentProducto = new Producto();

        public List<Categoria> listCategory = new List<Categoria>();
        public List<Presentacion> listPresentacion = new List<Presentacion>();
        public List<Marca> listMarca = new List<Marca>();
        public List<Lote> listCLote = new List<Lote>();
        public List<Laboratorio> listLaboratorio = new List<Laboratorio>();
        public List<Producto> listProducto = new List<Producto>();

        public IUConfiguracion()
        {
            InitializeComponent();
        }

        private void IUConfiguracion_Load(object sender, EventArgs e)
        {
            botones(true);
            ChargeElements();
            
        }

        public void botones(bool value)
        {
            btnGuardar.Enabled = !value;
            btnEditar.Enabled = !value;
            btnCancelar.Enabled = !value;
            btnNuevo.Enabled = value;

            txtName.Enabled = !value;
            txtDescription.Enabled= !value;
        }
        public void limpiar()
        {
            txtName.Text = String.Empty;
            txtDescription.Text = string.Empty;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            isNew = true;
            botones(false);
            limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            botones(true);
            limpiar();
        }

        /*Para las  Categorias*/
        public bool validateFilds()
        {
            bool isValue;
            if (txtDescription.Text == string.Empty || txtName.Text == string.Empty)
            {
                isValue = false;
            }
            else
            {
                isValue = true;
            }
            return isValue;
        }
        public bool validateFildsPresentacion()
        {
            bool isValue;
            if (txtDescriptionPresentacion.Text == string.Empty || txtNamePresentacion.Text == string.Empty)
            {
                isValue = false;
            }
            else
            {
                isValue = true;
            }
            return isValue;
        }
        public bool validateFildsProducts()
        {
            bool isValue;
            if (txtNombreProducto.Text == String.Empty || txtComposicionProducto.Text == String.Empty || txtUbicacionProducto.Text == String.Empty
                || txtRecomendacionProducto.Text == String.Empty || txtInformacionProducto.Text == String.Empty)
            {
                isValue = false;
            }
            else
            {
                isValue = true;
            }
            return isValue;
        }
        public bool validateFildsMarca()
        {
            bool isValue;
            if (txtDescriptionMarca.Text == string.Empty || txtNameMarca.Text == string.Empty)
            {
                isValue = false;
            }
            else
            {
                isValue = true;
            }
            return isValue;
        }
        public void ChargeElements()
        {
            GetListCatergory();
            GetListPresentacion();
            GetListMarca();
            GetListLaboratorio();
            GetListProducts();
        }
        public void GetListCatergory()
        {
            try
            {
                listCategory = Controlador.CCategoria.List_Categories();
                categoryBindingSource.DataSource = null;
                categoryBindingSource.DataSource = listCategory;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetListPresentacion()
        {
            try
            {
                listPresentacion = Controlador.CPresentacion.List_Presentacion();
                PresentacionBindingSource.DataSource = null;
                PresentacionBindingSource.DataSource = listPresentacion;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetListMarca()
        {
            try
            {
                listMarca = Controlador.CMarca.List_marca();
                MarcasBindingSource.DataSource = null;
                MarcasBindingSource.DataSource = listMarca;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetListLaboratorio()
        {
            try
            {
                listLaboratorio = Controlador.CLaboratorio.List_Laboratories();
                LaboratorioBindingSource.DataSource = null;
                LaboratorioBindingSource.DataSource = listLaboratorio;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetListProducts()
        {
            try
            {
                listProducto = Controlador.CProducto.List_Product();
                ProductoBindingSource.DataSource = null;
                ProductoBindingSource.DataSource = listProducto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SaveCategory()
        {
            if (!validateFilds())
            {
                MessageBox.Show("hay campos sin llenar que son obligatorios");
                return;
            }
            Categoria categoria = new Categoria();
            categoria.nombre = txtName.Text.Trim().ToUpper();
            categoria.descripcion = txtDescription.Text.Trim().ToString();
            try
            {
                if (isNew)
                {
                    //se esta guardando
                    string id = Controlador.CCategoria.Insert_category(categoria);
                    MessageBox.Show("se ha guardado correctamente");
                    GetListCatergory();
                }
                else
                {
                    currentCategoria.nombre = txtName.Text.ToUpper();
                    currentCategoria.descripcion = txtDescription.Text;
                    string id = Controlador.CCategoria.Update_Category(currentCategoria);
                    MessageBox.Show("se ha actualizado correctamente");
                    GetListCatergory();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString()); 
            }
            
            
        }
        /***    ****************    ***/
        /*  presentacion    */
        public void SavePresentacion()
        {
            if (!validateFildsPresentacion())
            {
                MessageBox.Show("hay campos sin llenar que son obligatorios");
                return;
            }
            Presentacion presentacion = new Presentacion();
            presentacion.nombre = txtNamePresentacion.Text.Trim().ToUpper();
            presentacion.descripcion = txtDescriptionPresentacion.Text.Trim().ToString();
            try
            {
                if (isNewPresentacion)
                {
                    //se esta guardando
                    string id = Controlador.CPresentacion.Insert_presentacion(presentacion);
                    MessageBox.Show("se ha guardado correctamente");
                    GetListPresentacion();
                }
                else
                {
                    currentPresentacion.nombre = txtNamePresentacion.Text.ToUpper();
                    currentPresentacion.descripcion = txtDescriptionPresentacion.Text;
                    string id = Controlador.CPresentacion.Update_Presentacion(currentPresentacion);
                    MessageBox.Show("se ha actualizado correctamente");
                    GetListPresentacion();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        public void SaveMarca()
        {
            if (!validateFildsMarca())
            {
                MessageBox.Show("hay campos sin llenar que son obligatorios");
                return;
            }
            Marca marca = new Marca();
            marca.nombre = txtNameMarca.Text.Trim().ToUpper();
            marca.descripcion = txtDescriptionMarca.Text.Trim().ToString();
            try
            {
                if (isNewMarca)
                {
                    //se esta guardando
                    string id = Controlador.CMarca.Insert_marca(marca);
                    MessageBox.Show("se ha guardado correctamente");
                    GetListMarca();
                }
                else
                {
                    currentMarca.nombre = txtNameMarca.Text.ToUpper();
                    currentMarca.descripcion = txtDescriptionMarca.Text;
                    string id = Controlador.CMarca.Update_Marca(currentMarca);
                    MessageBox.Show("se ha actualizado correctamente");
                    GetListMarca();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        /**/
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCategorias.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idCategory = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);
                    currentCategoria = listCategory.Find(x=>x.idCategoria == idCategory);
                    txtName.Text = currentCategoria.nombre;
                    txtDescription.Text = currentCategoria.descripcion;
                    btnEditar.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveCategory();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentCategoria != null)
            {
                botones(false);
                isNew = false;
            }
            else
            {
                return;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPresentacion_Click(object sender, EventArgs e)
        {
            SavePresentacion();
        }

        private void btnEliminarPresentacion_Click(object sender, EventArgs e)
        {

        }

        private void dgvPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPresentacion.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idPresentacion = Convert.ToInt32(dgvPresentacion.CurrentRow.Cells[0].Value);
                    currentPresentacion = listPresentacion.Find(x => x.idPresentacion == idPresentacion);
                    txtNamePresentacion.Text = currentPresentacion.nombre;
                    txtDescriptionPresentacion.Text = currentPresentacion.descripcion;
                    btnEditar.Enabled = true;
                    isNewPresentacion = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            SaveMarca();
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idMarca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells[0].Value);
                    currentMarca = listMarca.Find(x => x.idMarca == idMarca);
                    txtNameMarca.Text = currentMarca.nombre;
                    txtDescriptionMarca.Text = currentMarca.descripcion;
                    btnEditar.Enabled = true;
                    isNewMarca = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
        public void cleanFieldsProducts()
        {
            txtNombreProducto.Text = String.Empty;
            txtUbicacionProducto.Text = String.Empty;
            txtInformacionProducto.Text = String.Empty;
            txtComposicionProducto.Text = String.Empty;
            txtRecomendacionProducto.Text = String.Empty;
            txtCodigoProducto.Text = String.Empty;
        }
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFildsProducts())
                {
                    if (isNewProducts)
                    {
                        try
                        {
                            Producto product = new Producto();
                            product.nombre = txtNombreProducto.Text.Trim();
                            product.idPresentacion = Convert.ToInt32(cbPresentacion.SelectedValue);
                            product.idCategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                            product.composicion = txtComposicionProducto.Text.Trim();
                            product.idLaboratorio = Convert.ToInt32(cbLaboratorio.SelectedValue);
                            product.idMarca = Convert.ToInt32(cbMarca.SelectedValue);
                            product.fraccion = chkFraccion.Checked ? 1 : 0;
                            product.codigo = txtCodigoProducto.Text.Trim();
                            product.recomendacion = txtRecomendacionProducto.Text;
                            product.ubicacion = txtUbicacionProducto.Text;
                            product.informacionAdicional = txtInformacionProducto.Text;

                            string id = Controlador.CProducto.Insert_producto(product);
                            MessageBox.Show("Se ha guardado correctamente");
                            cleanFieldsProducts();
                            GetListProducts();


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            
                            currentProducto.nombre = txtNombreProducto.Text.Trim();
                            currentProducto.idPresentacion = Convert.ToInt32(cbPresentacion.SelectedValue);
                            currentProducto.idCategoria = Convert.ToInt32(cbCategoria.SelectedValue);
                            currentProducto.composicion = txtComposicionProducto.Text.Trim();
                            currentProducto.idLaboratorio = Convert.ToInt32(cbLaboratorio.SelectedValue);
                            currentProducto.idMarca = Convert.ToInt32(cbMarca.SelectedValue);
                            currentProducto.fraccion = chkFraccion.Checked ? 1 : 0;
                            currentProducto.codigo = txtCodigoProducto.Text.Trim();
                            currentProducto.recomendacion = txtRecomendacionProducto.Text;
                            currentProducto.ubicacion = txtUbicacionProducto.Text;
                            currentProducto.informacionAdicional = txtInformacionProducto.Text;

                            string id = Controlador.CProducto.Update_Producto(currentProducto);
                            MessageBox.Show("Se ha editado correctamente");
                            cleanFieldsProducts();
                            GetListProducts();




                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hay algunos campos vacios que son obligatorios");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("idPresentacion =="+ cbPresentacion.SelectedValue.ToString());
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                    currentProducto = listProducto.Find(x => x.idProducto == idProducto);
                    txtNombreProducto.Text = currentProducto.nombre;
                    cbPresentacion.SelectedValue = currentProducto.idPresentacion;
                    cbCategoria.SelectedValue = currentProducto.idCategoria;
                    txtComposicionProducto.Text = currentProducto.composicion;
                    cbLaboratorio.SelectedValue = currentProducto.idLaboratorio;
                    cbMarca.SelectedValue = currentProducto.idMarca;
                    chkFraccion.Checked = currentProducto.fraccion == 1 ? true : false;
                    txtCodigoProducto.Text = currentProducto.codigo;
                    txtRecomendacionProducto.Text = currentProducto.recomendacion;
                    txtUbicacionProducto.Text = currentProducto.ubicacion;
                    txtInformacionProducto.Text = currentProducto.informacionAdicional;
                    lblEncabezado.Text = "(Editando producto " + currentProducto.idProducto.ToString()+")"; 
                    isNewProducts = false;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            cleanFieldsProducts();
            isNewProducts = true;
            lblEncabezado.Text = "Nuevo Producto";
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarProducto_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                DialogResult response = MessageBox.Show("Sistema Pfizer","Esta seguro que desea Eliminar este producto?",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                if (response.ToString() == "OK")
                {
                    Controlador.CProducto.Delete_producto(idProducto);
                    MessageBox.Show("Sistema Pfizer", "se a eliminado el producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    cleanFieldsProducts();
                    GetListProducts();
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
