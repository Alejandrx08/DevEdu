namespace DevEdu
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            this.txtbx_nombre = new System.Windows.Forms.TextBox();
            this.txtbx_apellido = new System.Windows.Forms.TextBox();
            this.txtbx_correo = new System.Windows.Forms.TextBox();
            this.txtbx_contrasena = new System.Windows.Forms.TextBox();
            this.txtbx_confirmacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Registrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Link_Login = new System.Windows.Forms.LinkLabel();
            this.pic_profile = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbx_nombre
            // 
            this.txtbx_nombre.Location = new System.Drawing.Point(230, 41);
            this.txtbx_nombre.Name = "txtbx_nombre";
            this.txtbx_nombre.Size = new System.Drawing.Size(221, 22);
            this.txtbx_nombre.TabIndex = 0;
            this.txtbx_nombre.TextChanged += new System.EventHandler(this.txtbx_nombre_TextChanged);
            this.txtbx_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_nombre_KeyPress);
            // 
            // txtbx_apellido
            // 
            this.txtbx_apellido.Location = new System.Drawing.Point(230, 73);
            this.txtbx_apellido.Name = "txtbx_apellido";
            this.txtbx_apellido.Size = new System.Drawing.Size(221, 22);
            this.txtbx_apellido.TabIndex = 1;
            this.txtbx_apellido.TextChanged += new System.EventHandler(this.txtbx_apellido_TextChanged);
            this.txtbx_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_apellido_KeyPress);
            // 
            // txtbx_correo
            // 
            this.txtbx_correo.Location = new System.Drawing.Point(230, 104);
            this.txtbx_correo.Name = "txtbx_correo";
            this.txtbx_correo.Size = new System.Drawing.Size(221, 22);
            this.txtbx_correo.TabIndex = 2;
            this.txtbx_correo.TextChanged += new System.EventHandler(this.txtbx_correo_TextChanged);
            this.txtbx_correo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_correo_KeyPress);
            // 
            // txtbx_contrasena
            // 
            this.txtbx_contrasena.Location = new System.Drawing.Point(230, 137);
            this.txtbx_contrasena.Name = "txtbx_contrasena";
            this.txtbx_contrasena.Size = new System.Drawing.Size(221, 22);
            this.txtbx_contrasena.TabIndex = 3;
            this.txtbx_contrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_contrasena_KeyPress);
            // 
            // txtbx_confirmacion
            // 
            this.txtbx_confirmacion.Location = new System.Drawing.Point(230, 167);
            this.txtbx_confirmacion.Name = "txtbx_confirmacion";
            this.txtbx_confirmacion.Size = new System.Drawing.Size(221, 22);
            this.txtbx_confirmacion.TabIndex = 4;
            this.txtbx_confirmacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_confirmacion_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Correo Electronico";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(7, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Confirmacion ";
            // 
            // btn_Registrar
            // 
            this.btn_Registrar.BackColor = System.Drawing.Color.Navy;
            this.btn_Registrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Registrar.ForeColor = System.Drawing.Color.White;
            this.btn_Registrar.Location = new System.Drawing.Point(174, 203);
            this.btn_Registrar.Name = "btn_Registrar";
            this.btn_Registrar.Size = new System.Drawing.Size(100, 41);
            this.btn_Registrar.TabIndex = 10;
            this.btn_Registrar.Text = "Registrar";
            this.btn_Registrar.UseVisualStyleBackColor = false;
            this.btn_Registrar.Click += new System.EventHandler(this.btn_Registrar_Click);
            this.btn_Registrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_Registrar_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Registrar);
            this.groupBox1.Controls.Add(this.txtbx_confirmacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbx_nombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbx_contrasena);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbx_apellido);
            this.groupBox1.Controls.Add(this.txtbx_correo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(301, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 250);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 42);
            this.label6.TabIndex = 12;
            this.label6.Text = "¿Ya posees una cuenta?,\r\n\r\n";
            // 
            // Link_Login
            // 
            this.Link_Login.AutoSize = true;
            this.Link_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Link_Login.Location = new System.Drawing.Point(489, 359);
            this.Link_Login.Name = "Link_Login";
            this.Link_Login.Size = new System.Drawing.Size(150, 21);
            this.Link_Login.TabIndex = 14;
            this.Link_Login.TabStop = true;
            this.Link_Login.Text = "Inicia session ahora!";
            this.Link_Login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_Login_LinkClicked);
            // 
            // pic_profile
            // 
            this.pic_profile.Image = global::DevEdu.Properties.Resources.profilepicgray;
            this.pic_profile.Location = new System.Drawing.Point(12, 94);
            this.pic_profile.Name = "pic_profile";
            this.pic_profile.Size = new System.Drawing.Size(250, 250);
            this.pic_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_profile.TabIndex = 15;
            this.pic_profile.TabStop = false;
            // 
            // FrmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pic_profile);
            this.Controls.Add(this.Link_Login);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEdu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel Link_Login;
        private System.Windows.Forms.PictureBox pic_profile;
    }
}