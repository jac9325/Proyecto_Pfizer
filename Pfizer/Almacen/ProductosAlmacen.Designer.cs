
namespace Pfizer.Almacen
{
    partial class ProductosAlmacen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProductosAlmacen = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ProductosbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPresentacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.composicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLaboratorioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fraccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recomendacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.informacionAdicionalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarTexto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductosAlmacen
            // 
            this.dgvProductosAlmacen.AllowUserToAddRows = false;
            this.dgvProductosAlmacen.AllowUserToDeleteRows = false;
            this.dgvProductosAlmacen.AutoGenerateColumns = false;
            this.dgvProductosAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProductoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.idPresentacionDataGridViewTextBoxColumn,
            this.idCategoriaDataGridViewTextBoxColumn,
            this.composicionDataGridViewTextBoxColumn,
            this.idLaboratorioDataGridViewTextBoxColumn,
            this.idMarcaDataGridViewTextBoxColumn,
            this.fraccionDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.recomendacionDataGridViewTextBoxColumn,
            this.ubicacionDataGridViewTextBoxColumn,
            this.informacionAdicionalDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn});
            this.dgvProductosAlmacen.DataSource = this.ProductosbindingSource;
            this.dgvProductosAlmacen.Location = new System.Drawing.Point(12, 117);
            this.dgvProductosAlmacen.Name = "dgvProductosAlmacen";
            this.dgvProductosAlmacen.ReadOnly = true;
            this.dgvProductosAlmacen.RowHeadersWidth = 51;
            this.dgvProductosAlmacen.RowTemplate.Height = 24;
            this.dgvProductosAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosAlmacen.Size = new System.Drawing.Size(994, 499);
            this.dgvProductosAlmacen.TabIndex = 0;
            this.dgvProductosAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductosAlmacen_CellClick);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(901, 626);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 46);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Blue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(747, 626);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 46);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ProductosbindingSource
            // 
            this.ProductosbindingSource.DataSource = typeof(Entidades.Producto);
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProductoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPresentacionDataGridViewTextBoxColumn
            // 
            this.idPresentacionDataGridViewTextBoxColumn.DataPropertyName = "idPresentacion";
            this.idPresentacionDataGridViewTextBoxColumn.HeaderText = "idPresentacion";
            this.idPresentacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idPresentacionDataGridViewTextBoxColumn.Name = "idPresentacionDataGridViewTextBoxColumn";
            this.idPresentacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPresentacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // idCategoriaDataGridViewTextBoxColumn
            // 
            this.idCategoriaDataGridViewTextBoxColumn.DataPropertyName = "idCategoria";
            this.idCategoriaDataGridViewTextBoxColumn.HeaderText = "idCategoria";
            this.idCategoriaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idCategoriaDataGridViewTextBoxColumn.Name = "idCategoriaDataGridViewTextBoxColumn";
            this.idCategoriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCategoriaDataGridViewTextBoxColumn.Visible = false;
            // 
            // composicionDataGridViewTextBoxColumn
            // 
            this.composicionDataGridViewTextBoxColumn.DataPropertyName = "composicion";
            this.composicionDataGridViewTextBoxColumn.HeaderText = "composicion";
            this.composicionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.composicionDataGridViewTextBoxColumn.Name = "composicionDataGridViewTextBoxColumn";
            this.composicionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idLaboratorioDataGridViewTextBoxColumn
            // 
            this.idLaboratorioDataGridViewTextBoxColumn.DataPropertyName = "idLaboratorio";
            this.idLaboratorioDataGridViewTextBoxColumn.HeaderText = "idLaboratorio";
            this.idLaboratorioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idLaboratorioDataGridViewTextBoxColumn.Name = "idLaboratorioDataGridViewTextBoxColumn";
            this.idLaboratorioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLaboratorioDataGridViewTextBoxColumn.Visible = false;
            // 
            // idMarcaDataGridViewTextBoxColumn
            // 
            this.idMarcaDataGridViewTextBoxColumn.DataPropertyName = "idMarca";
            this.idMarcaDataGridViewTextBoxColumn.HeaderText = "idMarca";
            this.idMarcaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idMarcaDataGridViewTextBoxColumn.Name = "idMarcaDataGridViewTextBoxColumn";
            this.idMarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMarcaDataGridViewTextBoxColumn.Visible = false;
            // 
            // fraccionDataGridViewTextBoxColumn
            // 
            this.fraccionDataGridViewTextBoxColumn.DataPropertyName = "fraccion";
            this.fraccionDataGridViewTextBoxColumn.HeaderText = "fraccion";
            this.fraccionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fraccionDataGridViewTextBoxColumn.Name = "fraccionDataGridViewTextBoxColumn";
            this.fraccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "codigo";
            this.codigoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recomendacionDataGridViewTextBoxColumn
            // 
            this.recomendacionDataGridViewTextBoxColumn.DataPropertyName = "recomendacion";
            this.recomendacionDataGridViewTextBoxColumn.HeaderText = "recomendacion";
            this.recomendacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.recomendacionDataGridViewTextBoxColumn.Name = "recomendacionDataGridViewTextBoxColumn";
            this.recomendacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.recomendacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // ubicacionDataGridViewTextBoxColumn
            // 
            this.ubicacionDataGridViewTextBoxColumn.DataPropertyName = "ubicacion";
            this.ubicacionDataGridViewTextBoxColumn.HeaderText = "ubicacion";
            this.ubicacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ubicacionDataGridViewTextBoxColumn.Name = "ubicacionDataGridViewTextBoxColumn";
            this.ubicacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.ubicacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // informacionAdicionalDataGridViewTextBoxColumn
            // 
            this.informacionAdicionalDataGridViewTextBoxColumn.DataPropertyName = "informacionAdicional";
            this.informacionAdicionalDataGridViewTextBoxColumn.HeaderText = "informacionAdicional";
            this.informacionAdicionalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.informacionAdicionalDataGridViewTextBoxColumn.Name = "informacionAdicionalDataGridViewTextBoxColumn";
            this.informacionAdicionalDataGridViewTextBoxColumn.ReadOnly = true;
            this.informacionAdicionalDataGridViewTextBoxColumn.Visible = false;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // txtBuscarTexto
            // 
            this.txtBuscarTexto.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarTexto.Location = new System.Drawing.Point(12, 75);
            this.txtBuscarTexto.Name = "txtBuscarTexto";
            this.txtBuscarTexto.Size = new System.Drawing.Size(994, 28);
            this.txtBuscarTexto.TabIndex = 3;
            this.txtBuscarTexto.TextChanged += new System.EventHandler(this.txtBuscarTexto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Productos";
            // 
            // ProductosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 684);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarTexto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvProductosAlmacen);
            this.Name = "ProductosAlmacen";
            this.Text = "ProductosAlmacen";
            this.Load += new System.EventHandler(this.ProductosAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductosAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresentacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn composicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLaboratorioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fraccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recomendacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubicacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn informacionAdicionalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ProductosbindingSource;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBuscarTexto;
        private System.Windows.Forms.Label label1;
    }
}