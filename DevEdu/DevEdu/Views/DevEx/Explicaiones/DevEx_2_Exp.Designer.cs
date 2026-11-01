namespace DevEdu
{
    partial class DevEx_2_Exp
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblExplicacion = new System.Windows.Forms.Label();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.panelEncabezado.Controls.Add(this.lblMarca);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1040, 78);
            this.panelEncabezado.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(32, 14);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(102, 41);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "DevEx";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.lblTitulo);
            this.panelContenido.Controls.Add(this.lblExplicacion);
            this.panelContenido.Location = new System.Drawing.Point(60, 112);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(920, 500);
            this.panelContenido.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblTitulo.Location = new System.Drawing.Point(28, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(864, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "¿Cómo funciona el acumulador?";
            // 
            // lblExplicacion
            // 
            this.lblExplicacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblExplicacion.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblExplicacion.Location = new System.Drawing.Point(28, 82);
            this.lblExplicacion.Name = "lblExplicacion";
            this.lblExplicacion.Size = new System.Drawing.Size(864, 390);
            this.lblExplicacion.TabIndex = 1;
            this.lblExplicacion.Text = "Inicialización: total empieza en 0.\r\n\r\nrange(1, 6) produce los valores 1, 2, 3, 4 y 5. El límite superior, 6, no se incluye.\r\n\r\nEn cada vuelta, numero toma el siguiente valor y se suma a total:\r\n• numero = 1: total = 0 + 1 = 1\r\n• numero = 2: total = 1 + 2 = 3\r\n• numero = 3: total = 3 + 3 = 6\r\n• numero = 4: total = 6 + 4 = 10\r\n• numero = 5: total = 10 + 5 = 15\r\n\r\nPor eso el ciclo se ejecuta 5 veces y el valor final de total es 15. print(total) muestra 15.";
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.btnVolverMenu.FlatAppearance.BorderSize = 0;
            this.btnVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnVolverMenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverMenu.Location = new System.Drawing.Point(780, 640);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(200, 48);
            this.btnVolverMenu.TabIndex = 2;
            this.btnVolverMenu.Text = "Volver a ejercicios";
            this.btnVolverMenu.UseVisualStyleBackColor = false;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // DevEx_2_Exp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelEncabezado);
            this.MinimumSize = new System.Drawing.Size(1040, 720);
            this.Name = "DevEx_2_Exp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEx | Explicación del ejercicio 2";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblExplicacion;
        private System.Windows.Forms.Button btnVolverMenu;
    }
}