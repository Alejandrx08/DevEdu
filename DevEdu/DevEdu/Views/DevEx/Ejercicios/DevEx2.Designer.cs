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
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelEjercicio = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblIteraciones = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelEjercicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.panelEncabezado.Controls.Add(this.lblMarca);
            this.panelEncabezado.Controls.Add(this.btnVolver);
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
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(20, 52, 101);
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(845, 18);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(165, 40);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "← Volver a ejercicios";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panelEjercicio
            // 
            this.panelEjercicio.BackColor = System.Drawing.Color.White;
            this.panelEjercicio.Controls.Add(this.lblTitulo);
            this.panelEjercicio.Controls.Add(this.lblInstruccion);
            this.panelEjercicio.Controls.Add(this.lblCodigo);
            this.panelEjercicio.Controls.Add(this.lblTotal);
            this.panelEjercicio.Controls.Add(this.txtTotal);
            this.panelEjercicio.Controls.Add(this.lblIteraciones);
            this.panelEjercicio.Controls.Add(this.txtIteraciones);
            this.panelEjercicio.Controls.Add(this.btnComprobar);
            this.panelEjercicio.Location = new System.Drawing.Point(60, 112);
            this.panelEjercicio.Name = "panelEjercicio";
            this.panelEjercicio.Size = new System.Drawing.Size(920, 570);
            this.panelEjercicio.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblTitulo.Location = new System.Drawing.Point(32, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(856, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Ejercicio 2 · Sigue el acumulador";
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblInstruccion.Location = new System.Drawing.Point(32, 72);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(856, 48);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Analiza el código. Indica el valor final de total y cuántas veces se ejecuta el ciclo.";
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.Color.FromArgb(18, 37, 66);
            this.lblCodigo.Font = new System.Drawing.Font("Consolas", 17F);
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(32, 130);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Padding = new System.Windows.Forms.Padding(24);
            this.lblCodigo.Size = new System.Drawing.Size(856, 174);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "total = 0\r\nfor numero in range(1, 6):\r\n    total = total + numero\r\nprint(total)";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblTotal.Location = new System.Drawing.Point(80, 330);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(280, 30);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Valor final de total:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtTotal.Location = new System.Drawing.Point(370, 330);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(420, 31);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // lblIteraciones
            // 
            this.lblIteraciones.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblIteraciones.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblIteraciones.Location = new System.Drawing.Point(80, 385);
            this.lblIteraciones.Name = "lblIteraciones";
            this.lblIteraciones.Size = new System.Drawing.Size(280, 30);
            this.lblIteraciones.TabIndex = 5;
            this.lblIteraciones.Text = "Número de iteraciones:";
            this.lblIteraciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.txtIteraciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIteraciones.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtIteraciones.Location = new System.Drawing.Point(370, 385);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(420, 31);
            this.txtIteraciones.TabIndex = 6;
            this.txtIteraciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // btnComprobar
            // 
            this.btnComprobar.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.btnComprobar.FlatAppearance.BorderSize = 0;
            this.btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnComprobar.ForeColor = System.Drawing.Color.White;
            this.btnComprobar.Location = new System.Drawing.Point(350, 475);
            this.btnComprobar.Name = "btnComprobar";
            this.btnComprobar.Size = new System.Drawing.Size(220, 50);
            this.btnComprobar.TabIndex = 7;
            this.btnComprobar.Text = "Comprobar respuesta";
            this.btnComprobar.UseVisualStyleBackColor = false;
            this.btnComprobar.Click += new System.EventHandler(this.btnComprobar_Click);
            // 
            // DevEx2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.panelEjercicio);
            this.Controls.Add(this.panelEncabezado);
            this.MinimumSize = new System.Drawing.Size(1040, 720);
            this.Name = "DevEx2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEx | Ejercicio 2";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelEjercicio.ResumeLayout(false);
            this.panelEjercicio.PerformLayout();
            this.ResumeLayout(false);
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