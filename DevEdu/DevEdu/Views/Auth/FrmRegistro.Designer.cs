namespace DevEdu
{
    partial class FrmRegistro
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblMensajeMarca;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTituloRegistro;
        private System.Windows.Forms.Label lblSubtituloRegistro;
        private System.Windows.Forms.TextBox txtbx_nombre;
        private System.Windows.Forms.TextBox txtbx_apellido;
        private System.Windows.Forms.TextBox txtbx_correo;
        private System.Windows.Forms.TextBox txtbx_contrasena;
        private System.Windows.Forms.TextBox txtbx_confirmacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Registrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel Link_Login;
        private System.Windows.Forms.PictureBox pic_profile;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            panelBrand = new System.Windows.Forms.Panel();
            lblBrand = new System.Windows.Forms.Label();
            pic_profile = new System.Windows.Forms.PictureBox();
            lblMensajeMarca = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lblTituloRegistro = new System.Windows.Forms.Label();
            lblSubtituloRegistro = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtbx_nombre = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtbx_apellido = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtbx_correo = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtbx_contrasena = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtbx_confirmacion = new System.Windows.Forms.TextBox();
            btn_Registrar = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            Link_Login = new System.Windows.Forms.LinkLabel();
            panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_profile).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            panelBrand.Controls.Add(lblBrand);
            panelBrand.Controls.Add(pic_profile);
            panelBrand.Controls.Add(lblMensajeMarca);
            panelBrand.Dock = System.Windows.Forms.DockStyle.Left;
            panelBrand.Location = new System.Drawing.Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new System.Drawing.Size(300, 720);
            panelBrand.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            lblBrand.ForeColor = System.Drawing.Color.White;
            lblBrand.Location = new System.Drawing.Point(74, 48);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new System.Drawing.Size(149, 48);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "DevEdu";
            // 
            // pic_profile
            // 
            pic_profile.BackColor = System.Drawing.Color.Transparent;
            pic_profile.Image = Properties.Resources.profilepicgray;
            pic_profile.Location = new System.Drawing.Point(25, 188);
            pic_profile.Name = "pic_profile";
            pic_profile.Size = new System.Drawing.Size(250, 250);
            pic_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic_profile.TabIndex = 1;
            pic_profile.TabStop = false;
            // 
            // lblMensajeMarca
            // 
            lblMensajeMarca.Font = new System.Drawing.Font("Segoe UI", 13F);
            lblMensajeMarca.ForeColor = System.Drawing.Color.White;
            lblMensajeMarca.Location = new System.Drawing.Point(34, 490);
            lblMensajeMarca.Name = "lblMensajeMarca";
            lblMensajeMarca.Size = new System.Drawing.Size(232, 76);
            lblMensajeMarca.TabIndex = 2;
            lblMensajeMarca.Text = "Tu próximo reto\ncomienza aquí.";
            lblMensajeMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.White;
            groupBox1.Controls.Add(lblTituloRegistro);
            groupBox1.Controls.Add(lblSubtituloRegistro);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtbx_nombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtbx_apellido);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtbx_correo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtbx_contrasena);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtbx_confirmacion);
            groupBox1.Controls.Add(btn_Registrar);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Link_Login);
            groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox1.Location = new System.Drawing.Point(340, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(580, 665);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // lblTituloRegistro
            // 
            lblTituloRegistro.AutoSize = true;
            lblTituloRegistro.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblTituloRegistro.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTituloRegistro.Location = new System.Drawing.Point(50, 22);
            lblTituloRegistro.Name = "lblTituloRegistro";
            lblTituloRegistro.Size = new System.Drawing.Size(221, 41);
            lblTituloRegistro.TabIndex = 0;
            lblTituloRegistro.Text = "Crea tu cuenta";
            // 
            // lblSubtituloRegistro
            // 
            lblSubtituloRegistro.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtituloRegistro.ForeColor = System.Drawing.Color.DimGray;
            lblSubtituloRegistro.Location = new System.Drawing.Point(54, 69);
            lblSubtituloRegistro.Name = "lblSubtituloRegistro";
            lblSubtituloRegistro.Size = new System.Drawing.Size(450, 30);
            lblSubtituloRegistro.TabIndex = 1;
            lblSubtituloRegistro.Text = "Completa tus datos para comenzar a aprender.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Navy;
            label1.Location = new System.Drawing.Point(54, 112);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // txtbx_nombre
            // 
            txtbx_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx_nombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbx_nombre.Location = new System.Drawing.Point(55, 134);
            txtbx_nombre.Name = "txtbx_nombre";
            txtbx_nombre.PlaceholderText = "Tu nombre";
            txtbx_nombre.Size = new System.Drawing.Size(470, 25);
            txtbx_nombre.TabIndex = 0;
            txtbx_nombre.TextChanged += txtbx_nombre_TextChanged;
            txtbx_nombre.KeyPress += txtbx_nombre_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Navy;
            label2.Location = new System.Drawing.Point(54, 192);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Apellido";
            // 
            // txtbx_apellido
            // 
            txtbx_apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx_apellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbx_apellido.Location = new System.Drawing.Point(55, 214);
            txtbx_apellido.Name = "txtbx_apellido";
            txtbx_apellido.PlaceholderText = "Tu apellido";
            txtbx_apellido.Size = new System.Drawing.Size(470, 25);
            txtbx_apellido.TabIndex = 1;
            txtbx_apellido.TextChanged += txtbx_apellido_TextChanged;
            txtbx_apellido.KeyPress += txtbx_apellido_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.Navy;
            label3.Location = new System.Drawing.Point(54, 272);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 15);
            label3.TabIndex = 6;
            label3.Text = "Correo electrónico";
            label3.Click += label3_Click;
            // 
            // txtbx_correo
            // 
            txtbx_correo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx_correo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbx_correo.Location = new System.Drawing.Point(55, 294);
            txtbx_correo.Name = "txtbx_correo";
            txtbx_correo.PlaceholderText = "nombre@ejemplo.com";
            txtbx_correo.Size = new System.Drawing.Size(470, 25);
            txtbx_correo.TabIndex = 2;
            txtbx_correo.TextChanged += txtbx_correo_TextChanged;
            txtbx_correo.KeyPress += txtbx_correo_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.Navy;
            label4.Location = new System.Drawing.Point(54, 352);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(69, 15);
            label4.TabIndex = 8;
            label4.Text = "Contraseña";
            // 
            // txtbx_contrasena
            // 
            txtbx_contrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx_contrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbx_contrasena.Location = new System.Drawing.Point(55, 374);
            txtbx_contrasena.Name = "txtbx_contrasena";
            txtbx_contrasena.PlaceholderText = "Crea una contraseña";
            txtbx_contrasena.Size = new System.Drawing.Size(470, 25);
            txtbx_contrasena.TabIndex = 3;
            txtbx_contrasena.UseSystemPasswordChar = true;
            txtbx_contrasena.KeyPress += txtbx_contrasena_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.Navy;
            label5.Location = new System.Drawing.Point(54, 432);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(127, 15);
            label5.TabIndex = 10;
            label5.Text = "Confirmar contraseña";
            // 
            // txtbx_confirmacion
            // 
            txtbx_confirmacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtbx_confirmacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtbx_confirmacion.Location = new System.Drawing.Point(55, 454);
            txtbx_confirmacion.Name = "txtbx_confirmacion";
            txtbx_confirmacion.PlaceholderText = "Repite la contraseña";
            txtbx_confirmacion.Size = new System.Drawing.Size(470, 25);
            txtbx_confirmacion.TabIndex = 4;
            txtbx_confirmacion.UseSystemPasswordChar = true;
            txtbx_confirmacion.KeyPress += txtbx_confirmacion_KeyPress;
            // 
            // btn_Registrar
            // 
            btn_Registrar.BackColor = System.Drawing.Color.Navy;
            btn_Registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Registrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Registrar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn_Registrar.ForeColor = System.Drawing.Color.White;
            btn_Registrar.Location = new System.Drawing.Point(55, 515);
            btn_Registrar.Name = "btn_Registrar";
            btn_Registrar.Size = new System.Drawing.Size(470, 48);
            btn_Registrar.TabIndex = 5;
            btn_Registrar.Text = "Crear cuenta";
            btn_Registrar.UseVisualStyleBackColor = false;
            btn_Registrar.Click += btn_Registrar_Click;
            btn_Registrar.KeyPress += btn_Registrar_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            label6.ForeColor = System.Drawing.Color.DimGray;
            label6.Location = new System.Drawing.Point(55, 612);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(125, 15);
            label6.TabIndex = 12;
            label6.Text = "¿Ya tienes una cuenta?";
            // 
            // Link_Login
            // 
            Link_Login.AutoSize = true;
            Link_Login.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Link_Login.LinkColor = System.Drawing.Color.Navy;
            Link_Login.Location = new System.Drawing.Point(215, 610);
            Link_Login.Name = "Link_Login";
            Link_Login.Size = new System.Drawing.Size(73, 15);
            Link_Login.TabIndex = 6;
            Link_Login.TabStop = true;
            Link_Login.Text = "Inicia sesión";
            Link_Login.LinkClicked += Link_Login_LinkClicked;
            // 
            // FrmRegistro
            // 
            AcceptButton = btn_Registrar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(960, 720);
            Controls.Add(groupBox1);
            Controls.Add(panelBrand);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmRegistro";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEdu | Crear cuenta";
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_profile).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
