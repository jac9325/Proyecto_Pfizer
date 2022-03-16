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

namespace Pfizer.Users
{
    public partial class IUUsuario : Form
    {
        public List<Usuario> currentListUsuarios = new List<Usuario>();
        public Usuario currentUsuario = new Usuario();
        public bool IsNew = true;
        public IUUsuario()
        {
            InitializeComponent();
        }
        public IUUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.currentUsuario = usuario;
        }

        public void getListUsuarios()
        {
            try
            {
                currentListUsuarios = null;
                currentListUsuarios = Controlador.CUsuario.List_usuarios();
                UsuariosBindingSource.DataSource = null;
                UsuariosBindingSource.DataSource = currentListUsuarios;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public bool validateUser(string user)
        {
            bool response = true;
            Usuario usuario = new Usuario();
            
            response = currentListUsuarios.Exists(x=>x.usuario == user);
            
            return response;
        }
        public bool validateFields()
        {
            bool response = true;
            if (txtNombres.Text == String.Empty || txtApellidos.Text == String.Empty || txtUsuarios.Text == String.Empty || txtpassword.Text == String.Empty)
            {
                response = false;
            }
            return response;
        }
        public void cleanFields()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtUsuarios.Text = String.Empty;
            txtpassword.Text = String.Empty;
        }
        public void save()
        {
            if (!validateFields())
            {
                MessageBox.Show("Hay algunos campos obligatorios que faltan ser llenados", "Pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (IsNew) //registrando un usuario nuevo
                {
                    if (!validateUser(txtUsuarios.Text.Trim()))
                    {
                        Usuario usuario = new Usuario();
                        usuario.nombre = txtNombres.Text.Trim().ToUpper();
                        usuario.apellidos = txtApellidos.Text.Trim().ToUpper();
                        usuario.usuario = txtUsuarios.Text.Trim().ToUpper();
                        usuario.password = txtpassword.Text.Trim().ToUpper();
                        DialogResult response = MessageBox.Show("Pfizer 1.0.0.0","Esta seguro de guardar?",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (response.ToString() == "OK")
                        {
                            string id = "";
                            try
                            {
                                id = CUsuario.Insert_usuario(usuario);
                                MessageBox.Show("Pfizer 1.0.0.0", "se ha guardado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getListUsuarios();
                                cleanFields();
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya existe");
                    }
                }
                else
                {
                    if (!validateUser(txtUsuarios.Text.Trim()))
                    {
                        
                        currentUsuario.nombre = txtNombres.Text.Trim().ToUpper();
                        currentUsuario.apellidos = txtApellidos.Text.Trim().ToUpper();
                        currentUsuario.usuario = txtUsuarios.Text.Trim().ToUpper();
                        currentUsuario.password = txtpassword.Text.Trim().ToUpper();
                        DialogResult response = MessageBox.Show("Pfizer 1.0.0.0", "¿Está seguro de guardar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (response.ToString() == "OK")
                        {
                            string id = "";
                            try
                            {
                                id = CUsuario.Update_usuarios(currentUsuario);
                                MessageBox.Show("Pfizer 1.0.0.0", "se ha guardado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getListUsuarios();
                                cleanFields();
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya existe");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void IUUsuario_Load(object sender, EventArgs e)
        {
            getListUsuarios();
            btnEliminar.Enabled = false;
        }

        private void txtUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNew = true;
            cleanFields();
            lblEditando.Text = "Nuevo";
            txtNombres.Focus();
        }

        private void dgvDatosUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cleanFields();
            try
            {
                if (dgvDatosUsuario.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int idUsuario = Convert.ToInt32(dgvDatosUsuario.CurrentRow.Cells[0].Value);
                    currentUsuario = currentListUsuarios.Find(x => x.idUsuario == idUsuario);
                    txtNombres.Text = currentUsuario.nombre;
                    txtApellidos.Text = currentUsuario.apellidos;
                    txtUsuarios.Text = currentUsuario.usuario;
                    txtpassword.Text = currentUsuario.password;
                    this.IsNew = false;
                    this.lblEditando.Text = "Editando "+ "usuario " + currentUsuario.nombre;
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosUsuario.Rows.Count <= 0)
                {
                    return;
                }
                else
                {
                    if (currentListUsuarios.Count <= 1)
                    {
                        MessageBox.Show("No se puede eliminar el registro porque es el unico registro de usuario", "pfizer 1.0.0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DialogResult response = MessageBox.Show("Esta seguro de eliminar el registro, esta operación es irreversible", "pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (response.ToString() == "OK")
                        {
                            Controlador.CUsuario.Delete_usuarios(currentUsuario.idUsuario);
                            MessageBox.Show("Registro eliminado", "pfizer 1.0.0.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            getListUsuarios();
                            cleanFields();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cleanFields();
            lblEditando.Text = "Nuevo";
            this.IsNew = true;
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            if (currentUsuario == null)
            {
                return;
            }

            IUPermisos formPermisos = new IUPermisos(currentUsuario);
            formPermisos.ShowDialog();
        }
    }
}
