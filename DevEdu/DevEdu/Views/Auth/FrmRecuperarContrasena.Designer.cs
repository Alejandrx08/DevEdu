namespace DevEdu.Views.Auth
{
    partial class FrmRecuperarContrasena
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNuevaContrasena;
        private System.Windows.Forms.Label lblConfirmacion;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.TextBox txtConfirmacion;
        private System.Windows.Forms.Button btnSolicitarCodigo;
        private System.Windows.Forms.Button btnRestablecer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecuperarContrasena));
            pnlCard = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblDescripcion = new System.Windows.Forms.Label();
            lblCorreo = new System.Windows.Forms.Label();
            txtCorreo = new System.Windows.Forms.TextBox();
            lblCodigo = new System.Windows.Forms.Label();
            txtCodigo = new System.Windows.Forms.TextBox();
            lblNuevaContrasena = new System.Windows.Forms.Label();
            txtNuevaContrasena = new System.Windows.Forms.TextBox();
            lblConfirmacion = new System.Windows.Forms.Label();
            txtConfirmacion = new System.Windows.Forms.TextBox();
            btnSolicitarCodigo = new System.Windows.Forms.Button();
            btnRestablecer = new System.Windows.Forms.Button();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = System.Drawing.Color.White;
            pnlCard.Controls.Add(lblTitulo);
            pnlCard.Controls.Add(lblDescripcion);
            pnlCard.Controls.Add(lblCorreo);
            pnlCard.Controls.Add(txtCorreo);
            pnlCard.Controls.Add(lblCodigo);
            pnlCard.Controls.Add(txtCodigo);
            pnlCard.Controls.Add(lblNuevaContrasena);
            pnlCard.Controls.Add(txtNuevaContrasena);
            pnlCard.Controls.Add(lblConfirmacion);
            pnlCard.Controls.Add(txtConfirmacion);
            pnlCard.Controls.Add(btnSolicitarCodigo);
            pnlCard.Controls.Add(btnRestablecer);
            pnlCard.Location = new System.Drawing.Point(28, 22);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new System.Drawing.Size(464, 526);
            pnlCard.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTitulo.Location = new System.Drawing.Point(31, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(249, 36);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Recupera tu cuenta";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(98, 110, 128);
            lblDescripcion.Location = new System.Drawing.Point(34, 66);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(390, 38);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Solicita un código y úsalo para crear una nueva contraseña.";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCorreo.ForeColor = System.Drawing.Color.Navy;
            lblCorreo.Location = new System.Drawing.Point(32, 116);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new System.Drawing.Size(111, 15);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo electrónico";
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtCorreo.Location = new System.Drawing.Point(32, 141);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "nombre@ejemplo.com";
            txtCorreo.Size = new System.Drawing.Size(394, 25);
            txtCorreo.TabIndex = 3;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCodigo.ForeColor = System.Drawing.Color.Navy;
            lblCodigo.Location = new System.Drawing.Point(32, 204);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new System.Drawing.Size(138, 15);
            lblCodigo.TabIndex = 4;
            lblCodigo.Text = "Código de recuperación";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtCodigo.Location = new System.Drawing.Point(32, 229);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "6 dígitos";
            txtCodigo.Size = new System.Drawing.Size(394, 25);
            txtCodigo.TabIndex = 5;
            // 
            // lblNuevaContrasena
            // 
            lblNuevaContrasena.AutoSize = true;
            lblNuevaContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblNuevaContrasena.ForeColor = System.Drawing.Color.Navy;
            lblNuevaContrasena.Location = new System.Drawing.Point(32, 292);
            lblNuevaContrasena.Name = "lblNuevaContrasena";
            lblNuevaContrasena.Size = new System.Drawing.Size(107, 15);
            lblNuevaContrasena.TabIndex = 6;
            lblNuevaContrasena.Text = "Nueva contraseña";
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNuevaContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNuevaContrasena.Location = new System.Drawing.Point(32, 317);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.Size = new System.Drawing.Size(394, 25);
            txtNuevaContrasena.TabIndex = 7;
            txtNuevaContrasena.UseSystemPasswordChar = true;
            // 
            // lblConfirmacion
            // 
            lblConfirmacion.AutoSize = true;
            lblConfirmacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblConfirmacion.ForeColor = System.Drawing.Color.Navy;
            lblConfirmacion.Location = new System.Drawing.Point(32, 380);
            lblConfirmacion.Name = "lblConfirmacion";
            lblConfirmacion.Size = new System.Drawing.Size(164, 15);
            lblConfirmacion.TabIndex = 8;
            lblConfirmacion.Text = "Confirmar nueva contraseña";
            // 
            // txtConfirmacion
            // 
            txtConfirmacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtConfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmacion.Location = new System.Drawing.Point(32, 405);
            txtConfirmacion.Name = "txtConfirmacion";
            txtConfirmacion.Size = new System.Drawing.Size(394, 25);
            txtConfirmacion.TabIndex = 9;
            txtConfirmacion.UseSystemPasswordChar = true;
            // 
            // btnSolicitarCodigo
            // 
            btnSolicitarCodigo.BackColor = System.Drawing.Color.White;
            btnSolicitarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSolicitarCodigo.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            btnSolicitarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSolicitarCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSolicitarCodigo.ForeColor = System.Drawing.Color.Navy;
            btnSolicitarCodigo.Location = new System.Drawing.Point(32, 468);
            btnSolicitarCodigo.Name = "btnSolicitarCodigo";
            btnSolicitarCodigo.Size = new System.Drawing.Size(175, 38);
            btnSolicitarCodigo.TabIndex = 10;
            btnSolicitarCodigo.Text = "Solicitar código";
            btnSolicitarCodigo.UseVisualStyleBackColor = false;
            // 
            // btnRestablecer
            // 
            btnRestablecer.BackColor = System.Drawing.Color.Navy;
            btnRestablecer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRestablecer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnRestablecer.ForeColor = System.Drawing.Color.White;
            btnRestablecer.Location = new System.Drawing.Point(216, 468);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new System.Drawing.Size(210, 38);
            btnRestablecer.TabIndex = 11;
            btnRestablecer.Text = "Restablecer contraseña";
            btnRestablecer.UseVisualStyleBackColor = false;
            // 
            // FrmRecuperarContrasena
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            ClientSize = new System.Drawing.Size(520, 570);
            Controls.Add(pnlCard);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRecuperarContrasena";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "DevEdu";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}



