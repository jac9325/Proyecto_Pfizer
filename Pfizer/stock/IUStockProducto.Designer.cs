
namespace Pfizer.stock
{
    partial class IUStockProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatosStock = new System.Windows.Forms.DataGridView();
            this.idStockPrecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtxBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosStock
            // 
            this.dgvDatosStock.AllowUserToAddRows = false;
            this.dgvDatosStock.AllowUserToDeleteRows = false;
            this.dgvDatosStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatosStock.AutoGenerateColumns = false;
            this.dgvDatosStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatosStock.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDatosStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idStockPrecioDataGridViewTextBoxColumn,
            this.idProductoDataGridViewTextBoxColumn,
            this.nombreProductoDataGridViewTextBoxColumn,
            this.stockActualDataGridViewTextBoxColumn,
            this.precioVentaDataGridViewTextBoxColumn,
            this.stockMinimoDataGridViewTextBoxColumn});
            this.dgvDatosStock.DataSource = this.StockBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatosStock.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosStock.Location = new System.Drawing.Point(12, 97);
            this.dgvDatosStock.Name = "dgvDatosStock";
            this.dgvDatosStock.ReadOnly = true;
            this.dgvDatosStock.RowHeadersWidth = 51;
            this.dgvDatosStock.RowTemplate.Height = 24;
            this.dgvDatosStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosStock.Size = new System.Drawing.Size(1130, 423);
            this.dgvDatosStock.TabIndex = 15;
            // 
            // idStockPrecioDataGridViewTextBoxColumn
            // 
            this.idStockPrecioDataGridViewTextBoxColumn.DataPropertyName = "idStockPrecio";
            this.idStockPrecioDataGridViewTextBoxColumn.HeaderText = "idStockPrecio";
            this.idStockPrecioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idStockPrecioDataGridViewTextBoxColumn.Name = "idStockPrecioDataGridViewTextBoxColumn";
            this.idStockPrecioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idStockPrecioDataGridViewTextBoxColumn.Visible = false;
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
            // nombreProductoDataGridViewTextBoxColumn
            // 
            this.nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.HeaderText = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            this.nombreProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockActualDataGridViewTextBoxColumn
            // 
            this.stockActualDataGridViewTextBoxColumn.DataPropertyName = "StockActual";
            this.stockActualDataGridViewTextBoxColumn.HeaderText = "StockActual";
            this.stockActualDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stockActualDataGridViewTextBoxColumn.Name = "stockActualDataGridViewTextBoxColumn";
            this.stockActualDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            this.precioVentaDataGridViewTextBoxColumn.DataPropertyName = "precioVenta";
            this.precioVentaDataGridViewTextBoxColumn.HeaderText = "precioVenta";
            this.precioVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            this.precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockMinimoDataGridViewTextBoxColumn
            // 
            this.stockMinimoDataGridViewTextBoxColumn.DataPropertyName = "stockMinimo";
            this.stockMinimoDataGridViewTextBoxColumn.HeaderText = "stockMinimo";
            this.stockMinimoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stockMinimoDataGridViewTextBoxColumn.Name = "stockMinimoDataGridViewTextBoxColumn";
            this.stockMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StockBindingSource
            // 
            this.StockBindingSource.DataSource = typeof(Entidades.StockProductos);
            // 
            // txtxBuscar
            // 
            this.txtxBuscar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxBuscar.Location = new System.Drawing.Point(12, 29);
            this.txtxBuscar.Multiline = true;
            this.txtxBuscar.Name = "txtxBuscar";
            this.txtxBuscar.Size = new System.Drawing.Size(739, 53);
            this.txtxBuscar.TabIndex = 16;
            this.txtxBuscar.TextChanged += new System.EventHandler(this.txtxBuscar_TextChanged);
            // 
            // IUStockProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 545);
            this.Controls.Add(this.txtxBuscar);
            this.Controls.Add(this.dgvDatosStock);
            this.Name = "IUStockProducto";
            this.Text = "IUStockProducto";
            this.Load += new System.EventHandler(this.IUStockProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosStock;
        private System.Windows.Forms.BindingSource StockBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStockPrecioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtxBuscar;
    }
}