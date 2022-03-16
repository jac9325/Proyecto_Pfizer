
namespace Pfizer.Ingresos
{
    partial class IUIngresosAlmacen
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
            this.dgvIngresosAlmacen = new System.Windows.Forms.DataGridView();
            this.idIngresoAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngresosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngresosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngresosAlmacen
            // 
            this.dgvIngresosAlmacen.AllowUserToAddRows = false;
            this.dgvIngresosAlmacen.AllowUserToDeleteRows = false;
            this.dgvIngresosAlmacen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngresosAlmacen.AutoGenerateColumns = false;
            this.dgvIngresosAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresosAlmacen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvIngresosAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresosAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idIngresoAlmacenDataGridViewTextBoxColumn,
            this.idLoteDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.fechaModificacionDataGridViewTextBoxColumn,
            this.tipoComprobanteDataGridViewTextBoxColumn,
            this.nroComprobanteDataGridViewTextBoxColumn,
            this.precioTotalDataGridViewTextBoxColumn,
            this.idUsuarioDataGridViewTextBoxColumn});
            this.dgvIngresosAlmacen.DataSource = this.IngresosBindingSource;
            this.dgvIngresosAlmacen.Location = new System.Drawing.Point(22, 237);
            this.dgvIngresosAlmacen.Name = "dgvIngresosAlmacen";
            this.dgvIngresosAlmacen.ReadOnly = true;
            this.dgvIngresosAlmacen.RowHeadersWidth = 51;
            this.dgvIngresosAlmacen.RowTemplate.Height = 24;
            this.dgvIngresosAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresosAlmacen.Size = new System.Drawing.Size(1262, 469);
            this.dgvIngresosAlmacen.TabIndex = 16;
            this.dgvIngresosAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngresosAlmacen_CellClick);
            this.dgvIngresosAlmacen.DoubleClick += new System.EventHandler(this.dgvIngresosAlmacen_DoubleClick);
            // 
            // idIngresoAlmacenDataGridViewTextBoxColumn
            // 
            this.idIngresoAlmacenDataGridViewTextBoxColumn.DataPropertyName = "idIngresoAlmacen";
            this.idIngresoAlmacenDataGridViewTextBoxColumn.HeaderText = "idIngresoAlmacen";
            this.idIngresoAlmacenDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idIngresoAlmacenDataGridViewTextBoxColumn.Name = "idIngresoAlmacenDataGridViewTextBoxColumn";
            this.idIngresoAlmacenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idIngresoAlmacenDataGridViewTextBoxColumn.Visible = false;
            // 
            // idLoteDataGridViewTextBoxColumn
            // 
            this.idLoteDataGridViewTextBoxColumn.DataPropertyName = "idLote";
            this.idLoteDataGridViewTextBoxColumn.HeaderText = "idLote";
            this.idLoteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idLoteDataGridViewTextBoxColumn.Name = "idLoteDataGridViewTextBoxColumn";
            this.idLoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLoteDataGridViewTextBoxColumn.Visible = false;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaIngresoDataGridViewTextBoxColumn
            // 
            this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "fechaIngreso";
            this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "fechaIngreso";
            this.fechaIngresoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
            this.fechaIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "fechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "fechaModificacion";
            this.fechaModificacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
            this.fechaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoComprobanteDataGridViewTextBoxColumn
            // 
            this.tipoComprobanteDataGridViewTextBoxColumn.DataPropertyName = "tipoComprobante";
            this.tipoComprobanteDataGridViewTextBoxColumn.HeaderText = "tipoComprobante";
            this.tipoComprobanteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipoComprobanteDataGridViewTextBoxColumn.Name = "tipoComprobanteDataGridViewTextBoxColumn";
            this.tipoComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nroComprobanteDataGridViewTextBoxColumn
            // 
            this.nroComprobanteDataGridViewTextBoxColumn.DataPropertyName = "nroComprobante";
            this.nroComprobanteDataGridViewTextBoxColumn.HeaderText = "nroComprobante";
            this.nroComprobanteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nroComprobanteDataGridViewTextBoxColumn.Name = "nroComprobanteDataGridViewTextBoxColumn";
            this.nroComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioTotalDataGridViewTextBoxColumn
            // 
            this.precioTotalDataGridViewTextBoxColumn.DataPropertyName = "precioTotal";
            this.precioTotalDataGridViewTextBoxColumn.HeaderText = "precioTotal";
            this.precioTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precioTotalDataGridViewTextBoxColumn.Name = "precioTotalDataGridViewTextBoxColumn";
            this.precioTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUsuarioDataGridViewTextBoxColumn
            // 
            this.idUsuarioDataGridViewTextBoxColumn.DataPropertyName = "idUsuario";
            this.idUsuarioDataGridViewTextBoxColumn.HeaderText = "idUsuario";
            this.idUsuarioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idUsuarioDataGridViewTextBoxColumn.Name = "idUsuarioDataGridViewTextBoxColumn";
            this.idUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // IngresosBindingSource
            // 
            this.IngresosBindingSource.DataSource = typeof(Entidades.IngresoAlmacen);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 44);
            this.label1.TabIndex = 17;
            this.label1.Text = "INGRESOS DE LOTES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Solamente se mostrarán los ultimso 20 ingresos";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Location = new System.Drawing.Point(22, 191);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(307, 28);
            this.dtpFechaInicio.TabIndex = 18;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Location = new System.Drawing.Point(381, 191);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(302, 28);
            this.dtpFechaFinal.TabIndex = 19;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(725, 191);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(161, 28);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha Inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(380, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fecha Final:";
            // 
            // IUIngresosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 734);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvIngresosAlmacen);
            this.Name = "IUIngresosAlmacen";
            this.Load += new System.EventHandler(this.IUIngresosAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngresosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresosAlmacen;
        private System.Windows.Forms.BindingSource IngresosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIngresoAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}