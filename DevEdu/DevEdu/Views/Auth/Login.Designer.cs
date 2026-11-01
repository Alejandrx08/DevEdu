namespace DevEdu
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblMensajeMarca;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTituloLogin;
        private System.Windows.Forms.Label lblSubtituloLogin;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel Link_registro;
        private System.Windows.Forms.PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panelBrand = new System.Windows.Forms.Panel();
            lblBrand = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lblMensajeMarca = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lblTituloLogin = new System.Windows.Forms.Label();
            lblSubtituloLogin = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txt_username = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txt_Password = new System.Windows.Forms.TextBox();
            btn_Login = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            Link_registro = new System.Windows.Forms.LinkLabel();
            panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            panelBrand.Controls.Add(lblBrand);
            panelBrand.Controls.Add(pictureBox1);
            panelBrand.Controls.Add(lblMensajeMarca);
            panelBrand.Dock = System.Windows.Forms.DockStyle.Left;
            panelBrand.Location = new System.Drawing.Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new System.Drawing.Size(300, 620);
            panelBrand.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            lblBrand.ForeColor = System.Drawing.Color.White;
            lblBrand.Location = new System.Drawing.Point(75, 38);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new System.Drawing.Size(149, 48);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "DevEdu";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(25, 145);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(250, 250);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblMensajeMarca
            // 
            lblMensajeMarca.Font = new System.Drawing.Font("Segoe UI", 13F);
            lblMensajeMarca.ForeColor = System.Drawing.Color.White;
            lblMensajeMarca.Location = new System.Drawing.Point(34, 435);
            lblMensajeMarca.Name = "lblMensajeMarca";
            lblMensajeMarca.Size = new System.Drawing.Size(232, 76);
            lblMensajeMarca.TabIndex = 2;
            lblMensajeMarca.Text = "Aprende a tu ritmo.\r\nCrece con cada reto.";
            lblMensajeMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.White;
            groupBox1.Controls.Add(lblTituloLogin);
            groupBox1.Controls.Add(lblSubtituloLogin);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_username);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_Password);
            groupBox1.Controls.Add(btn_Login);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Link_registro);
            groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox1.Location = new System.Drawing.Point(340, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(580, 520);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // lblTituloLogin
            // 
            lblTituloLogin.AutoSize = true;
            lblTituloLogin.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblTituloLogin.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTituloLogin.Location = new System.Drawing.Point(50, 29);
            lblTituloLogin.Name = "lblTituloLogin";
            lblTituloLogin.Size = new System.Drawing.Size(315, 41);
            lblTituloLogin.TabIndex = 0;
            lblTituloLogin.Text = "Bienvenido a DevEdu";
            // 
            // lblSubtituloLogin
            // 
            lblSubtituloLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtituloLogin.ForeColor = System.Drawing.Color.DimGray;
            lblSubtituloLogin.Location = new System.Drawing.Point(54, 77);
            lblSubtituloLogin.Name = "lblSubtituloLogin";
            lblSubtituloLogin.Size = new System.Drawing.Size(450, 33);
            lblSubtituloLogin.TabIndex = 1;
            lblSubtituloLogin.Text = "Ingresa tus datos para continuar aprendiendo.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Navy;
            label1.Location = new System.Drawing.Point(54, 132);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(135, 19);
            label1.TabIndex = 2;
            label1.Text = "Correo electrónico";
            label1.Click += label1_Click;
            // 
            // txt_username
            // 
            txt_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_username.Font = new System.Drawing.Font("Segoe UI", 11F);
            txt_username.Location = new System.Drawing.Point(55, 160);
            txt_username.Name = "txt_username";
            txt_username.PlaceholderText = "nombre@ejemplo.com";
            txt_username.Size = new System.Drawing.Size(470, 27);
            txt_username.TabIndex = 0;
            txt_username.KeyPress += txt_username_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Navy;
            label2.Location = new System.Drawing.Point(54, 222);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 19);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            label2.Click += label2_Click;
            // 
            // txt_Password
            // 
            txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_Password.Font = new System.Drawing.Font("Segoe UI", 11F);
            txt_Password.Location = new System.Drawing.Point(55, 250);
            txt_Password.Name = "txt_Password";
            txt_Password.PlaceholderText = "Escribe tu contraseña";
            txt_Password.Size = new System.Drawing.Size(470, 27);
            txt_Password.TabIndex = 1;
            txt_Password.UseSystemPasswordChar = true;
            txt_Password.TextChanged += txt_Password_TextChanged;
            txt_Password.KeyPress += txt_Password_KeyPress;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = System.Drawing.Color.Navy;
            btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Login.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn_Login.ForeColor = System.Drawing.Color.White;
            btn_Login.Location = new System.Drawing.Point(55, 310);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new System.Drawing.Size(470, 48);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Iniciar sesión";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Log_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.ForeColor = System.Drawing.Color.DimGray;
            label3.Location = new System.Drawing.Point(55, 455);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(152, 15);
            label3.TabIndex = 7;
            label3.Text = "¿Aún no tienes una cuenta?";
            label3.Click += label3_Click;
            // 
            // Link_registro
            // 
            Link_registro.AutoSize = true;
            Link_registro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Link_registro.LinkColor = System.Drawing.Color.Navy;
            Link_registro.Location = new System.Drawing.Point(213, 455);
            Link_registro.Name = "Link_registro";
            Link_registro.Size = new System.Drawing.Size(65, 15);
            Link_registro.TabIndex = 3;
            Link_registro.TabStop = true;
            Link_registro.Text = "Regístrate";
            Link_registro.LinkClicked += Link_registro_LinkClicked;
            // 
            // Login
            // 
            AcceptButton = btn_Login;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(960, 620);
            Controls.Add(groupBox1);
            Controls.Add(panelBrand);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEdu | Iniciar sesión";
            Load += Login_Load;
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
    }
}

