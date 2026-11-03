namespace DevEdu
{
    partial class DevEx2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevEx2));
            panelEncabezado = new System.Windows.Forms.Panel();
            lblMarca = new System.Windows.Forms.Label();
            btnVolver = new System.Windows.Forms.Button();
            panelEjercicio = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblInstruccion = new System.Windows.Forms.Label();
            lblCodigo = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();
            txtTotal = new System.Windows.Forms.TextBox();
            lblIteraciones = new System.Windows.Forms.Label();
            txtIteraciones = new System.Windows.Forms.TextBox();
            btnComprobar = new System.Windows.Forms.Button();
            panelEncabezado.SuspendLayout();
            panelEjercicio.SuspendLayout();
            SuspendLayout();
            // 
            // panelEncabezado
            // 
            panelEncabezado.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            panelEncabezado.Controls.Add(lblMarca);
            panelEncabezado.Controls.Add(btnVolver);
            panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            panelEncabezado.Location = new System.Drawing.Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new System.Drawing.Size(1040, 78);
            panelEncabezado.TabIndex = 0;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            lblMarca.ForeColor = System.Drawing.Color.White;
            lblMarca.Location = new System.Drawing.Point(32, 14);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new System.Drawing.Size(102, 41);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "DevEx";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = System.Drawing.Color.FromArgb(20, 52, 101);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVolver.ForeColor = System.Drawing.Color.White;
            btnVolver.Location = new System.Drawing.Point(845, 18);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new System.Drawing.Size(165, 40);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "← Volver a ejercicios";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // panelEjercicio
            // 
            panelEjercicio.BackColor = System.Drawing.Color.White;
            panelEjercicio.Controls.Add(lblTitulo);
            panelEjercicio.Controls.Add(lblInstruccion);
            panelEjercicio.Controls.Add(lblCodigo);
            panelEjercicio.Controls.Add(lblTotal);
            panelEjercicio.Controls.Add(txtTotal);
            panelEjercicio.Controls.Add(lblIteraciones);
            panelEjercicio.Controls.Add(txtIteraciones);
            panelEjercicio.Controls.Add(btnComprobar);
            panelEjercicio.Location = new System.Drawing.Point(60, 112);
            panelEjercicio.Name = "panelEjercicio";
            panelEjercicio.Size = new System.Drawing.Size(920, 570);
            panelEjercicio.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTitulo.Location = new System.Drawing.Point(32, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(856, 42);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ejercicio 2 · Sigue el acumulador";
            // 
            // lblInstruccion
            // 
            lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblInstruccion.Location = new System.Drawing.Point(32, 72);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new System.Drawing.Size(856, 48);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Analiza el código. Indica el valor final de total y cuántas veces se ejecuta el ciclo.";
            // 
            // lblCodigo
            // 
            lblCodigo.BackColor = System.Drawing.Color.FromArgb(18, 37, 66);
            lblCodigo.Font = new System.Drawing.Font("Consolas", 17F);
            lblCodigo.ForeColor = System.Drawing.Color.White;
            lblCodigo.Location = new System.Drawing.Point(32, 130);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Padding = new System.Windows.Forms.Padding(24);
            lblCodigo.Size = new System.Drawing.Size(856, 174);
            lblCodigo.TabIndex = 2;
            lblCodigo.Text = "total = 0\r\nfor numero in range(1, 6):\r\n    total = total + numero\r\nprint(total)";
            lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTotal.Location = new System.Drawing.Point(80, 330);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(280, 30);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Valor final de total:";
            lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            txtTotal.Location = new System.Drawing.Point(370, 330);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new System.Drawing.Size(420, 31);
            txtTotal.TabIndex = 4;
            txtTotal.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblIteraciones
            // 
            lblIteraciones.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblIteraciones.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblIteraciones.Location = new System.Drawing.Point(80, 385);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new System.Drawing.Size(280, 30);
            lblIteraciones.TabIndex = 5;
            lblIteraciones.Text = "Número de iteraciones:";
            lblIteraciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIteraciones
            // 
            txtIteraciones.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            txtIteraciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtIteraciones.Font = new System.Drawing.Font("Segoe UI", 13F);
            txtIteraciones.Location = new System.Drawing.Point(370, 385);
            txtIteraciones.Name = "txtIteraciones";
            txtIteraciones.Size = new System.Drawing.Size(420, 31);
            txtIteraciones.TabIndex = 6;
            txtIteraciones.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnComprobar
            // 
            btnComprobar.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            btnComprobar.FlatAppearance.BorderSize = 0;
            btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnComprobar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            btnComprobar.ForeColor = System.Drawing.Color.White;
            btnComprobar.Location = new System.Drawing.Point(350, 475);
            btnComprobar.Name = "btnComprobar";
            btnComprobar.Size = new System.Drawing.Size(220, 50);
            btnComprobar.TabIndex = 7;
            btnComprobar.Text = "Comprobar respuesta";
            btnComprobar.UseVisualStyleBackColor = false;
            btnComprobar.Click += btnComprobar_Click;
            // 
            // DevEx2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(1040, 720);
            Controls.Add(panelEjercicio);
            Controls.Add(panelEncabezado);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1040, 720);
            Name = "DevEx2";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEx | Ejercicio 2";
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelEjercicio.ResumeLayout(false);
            panelEjercicio.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelEjercicio;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblIteraciones;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.Button btnComprobar;
    }
}