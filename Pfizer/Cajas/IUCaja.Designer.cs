
namespace Pfizer.Cajas
{
    partial class IUCaja
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
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.lblNombreCaja = new System.Windows.Forms.Label();
            this.btnIniciarCaja = new System.Windows.Forms.Button();
            this.lblcajasesion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCaja
            // 
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaja.Location = new System.Drawing.Point(12, 277);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.RowHeadersWidth = 51;
            this.dgvCaja.RowTemplate.Height = 24;
            this.dgvCaja.Size = new System.Drawing.Size(1075, 224);
            this.dgvCaja.TabIndex = 0;
            // 
            // lblNombreCaja
            // 
            this.lblNombreCaja.AutoSize = true;
            this.lblNombreCaja.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblNombreCaja.Location = new System.Drawing.Point(52, 43);
            this.lblNombreCaja.Name = "lblNombreCaja";
            this.lblNombreCaja.Size = new System.Drawing.Size(140, 28);
            this.lblNombreCaja.TabIndex = 1;
            this.lblNombreCaja.Text = "setNombre";
            // 
            // btnIniciarCaja
            // 
            this.btnIniciarCaja.Location = new System.Drawing.Point(275, 43);
            this.btnIniciarCaja.Name = "btnIniciarCaja";
            this.btnIniciarCaja.Size = new System.Drawing.Size(186, 35);
            this.btnIniciarCaja.TabIndex = 2;
            this.btnIniciarCaja.Text = "Iniciar Caja";
            this.btnIniciarCaja.UseVisualStyleBackColor = true;
            this.btnIniciarCaja.Click += new System.EventHandler(this.btnIniciarCaja_Click);
            // 
            // lblcajasesion
            // 
            this.lblcajasesion.AutoSize = true;
            this.lblcajasesion.BackColor = System.Drawing.SystemColors.Control;
            this.lblcajasesion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcajasesion.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblcajasesion.Location = new System.Drawing.Point(54, 112);
            this.lblcajasesion.Name = "lblcajasesion";
            this.lblcajasesion.Size = new System.Drawing.Size(151, 24);
            this.lblcajasesion.TabIndex = 3;
            this.lblcajasesion.Text = "Caja NO INICIADA";
            // 
            // IUCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 549);
            this.Controls.Add(this.lblcajasesion);
            this.Controls.Add(this.btnIniciarCaja);
            this.Controls.Add(this.lblNombreCaja);
            this.Controls.Add(this.dgvCaja);
            this.Name = "IUCaja";
            this.Text = "IUCaja";
            this.Load += new System.EventHandler(this.IUCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Label lblNombreCaja;
        private System.Windows.Forms.Button btnIniciarCaja;
        private System.Windows.Forms.Label lblcajasesion;
    }
}