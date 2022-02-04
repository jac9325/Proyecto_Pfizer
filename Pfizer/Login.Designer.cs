
namespace Pfizer
{
    partial class Login
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(140, 142);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(141, 22);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(384, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(173, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(269, 309);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "button1";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.Button btnIngresar;
    }
}