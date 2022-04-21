namespace Pfizer.Cajas
{
    partial class IUArquearCaja
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoCajaFisica = new System.Windows.Forms.TextBox();
            this.lblMontoSistema = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMontoFaltante = new System.Windows.Forms.Label();
            this.lblMontoSobrante = new System.Windows.Forms.Label();
            this.btnArquear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMontoIncioCaja = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(207, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARQUEO DE CAJA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto Generado en el Sistema:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Monto Total Caja Fisica:";
            // 
            // txtMontoCajaFisica
            // 
            this.txtMontoCajaFisica.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCajaFisica.Location = new System.Drawing.Point(362, 213);
            this.txtMontoCajaFisica.Multiline = true;
            this.txtMontoCajaFisica.Name = "txtMontoCajaFisica";
            this.txtMontoCajaFisica.Size = new System.Drawing.Size(189, 37);
            this.txtMontoCajaFisica.TabIndex = 2;
            this.txtMontoCajaFisica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCajaFisica_KeyPress);
            // 
            // lblMontoSistema
            // 
            this.lblMontoSistema.AutoSize = true;
            this.lblMontoSistema.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSistema.Location = new System.Drawing.Point(535, 96);
            this.lblMontoSistema.Name = "lblMontoSistema";
            this.lblMontoSistema.Size = new System.Drawing.Size(105, 34);
            this.lblMontoSistema.TabIndex = 3;
            this.lblMontoSistema.Text = "00.00";
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.DarkRed;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(577, 213);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(123, 37);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Faltante:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sobrante:";
            // 
            // lblMontoFaltante
            // 
            this.lblMontoFaltante.AutoSize = true;
            this.lblMontoFaltante.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoFaltante.Location = new System.Drawing.Point(520, 302);
            this.lblMontoFaltante.Name = "lblMontoFaltante";
            this.lblMontoFaltante.Size = new System.Drawing.Size(105, 34);
            this.lblMontoFaltante.TabIndex = 3;
            this.lblMontoFaltante.Text = "00.00";
            // 
            // lblMontoSobrante
            // 
            this.lblMontoSobrante.AutoSize = true;
            this.lblMontoSobrante.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSobrante.Location = new System.Drawing.Point(520, 369);
            this.lblMontoSobrante.Name = "lblMontoSobrante";
            this.lblMontoSobrante.Size = new System.Drawing.Size(105, 34);
            this.lblMontoSobrante.TabIndex = 3;
            this.lblMontoSobrante.Text = "00.00";
            // 
            // btnArquear
            // 
            this.btnArquear.BackColor = System.Drawing.Color.Red;
            this.btnArquear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArquear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArquear.ForeColor = System.Drawing.Color.White;
            this.btnArquear.Location = new System.Drawing.Point(257, 450);
            this.btnArquear.Name = "btnArquear";
            this.btnArquear.Size = new System.Drawing.Size(171, 67);
            this.btnArquear.TabIndex = 5;
            this.btnArquear.Text = "Arquear";
            this.btnArquear.UseVisualStyleBackColor = false;
            this.btnArquear.Click += new System.EventHandler(this.btnArquear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(450, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 34);
            this.label6.TabIndex = 3;
            this.label6.Text = "S/.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(450, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 34);
            this.label7.TabIndex = 3;
            this.label7.Text = "S/.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(450, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 34);
            this.label8.TabIndex = 3;
            this.label8.Text = "S/.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(285, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Monto de Inicio en Caja:";
            // 
            // lblMontoIncioCaja
            // 
            this.lblMontoIncioCaja.AutoSize = true;
            this.lblMontoIncioCaja.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoIncioCaja.Location = new System.Drawing.Point(535, 153);
            this.lblMontoIncioCaja.Name = "lblMontoIncioCaja";
            this.lblMontoIncioCaja.Size = new System.Drawing.Size(105, 34);
            this.lblMontoIncioCaja.TabIndex = 3;
            this.lblMontoIncioCaja.Text = "00.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(450, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 34);
            this.label10.TabIndex = 3;
            this.label10.Text = "S/.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(57, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "(Sin el Monto Inicial)";
            // 
            // IUArquearCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 529);
            this.Controls.Add(this.btnArquear);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblMontoSobrante);
            this.Controls.Add(this.lblMontoFaltante);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMontoIncioCaja);
            this.Controls.Add(this.lblMontoSistema);
            this.Controls.Add(this.txtMontoCajaFisica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IUArquearCaja";
            this.Load += new System.EventHandler(this.IUArquearCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoCajaFisica;
        private System.Windows.Forms.Label lblMontoSistema;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMontoFaltante;
        private System.Windows.Forms.Label lblMontoSobrante;
        private System.Windows.Forms.Button btnArquear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMontoIncioCaja;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}