namespace DevEdu
{
    partial class DevEx3
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblMarca = new System.Windows.Forms.Label();
            btnVolver = new System.Windows.Forms.Button();
            panelEjercicio = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblInstruccion = new System.Windows.Forms.Label();
            lblCodigo = new System.Windows.Forms.Label();
            lblPrimeraRespuesta = new System.Windows.Forms.Label();
            txtSuma = new System.Windows.Forms.TextBox();
            lblSegundaRespuesta = new System.Windows.Forms.Label();
            txtCantidad = new System.Windows.Forms.TextBox();
            btnComprobar = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            panelEjercicio.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            panelHeader.Controls.Add(lblMarca);
            panelHeader.Controls.Add(btnVolver);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1040, 78);
            panelHeader.TabIndex = 1;
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
            panelEjercicio.Controls.Add(lblPrimeraRespuesta);
            panelEjercicio.Controls.Add(txtSuma);
            panelEjercicio.Controls.Add(lblSegundaRespuesta);
            panelEjercicio.Controls.Add(txtCantidad);
            panelEjercicio.Controls.Add(btnComprobar);
            panelEjercicio.Location = new System.Drawing.Point(60, 112);
            panelEjercicio.Name = "panelEjercicio";
            panelEjercicio.Size = new System.Drawing.Size(920, 570);
            panelEjercicio.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblTitulo.Location = new System.Drawing.Point(32, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(856, 42);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ejercicio 3 · Filtra y acumula";
            // 
            // lblInstruccion
            // 
            lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblInstruccion.Location = new System.Drawing.Point(32, 72);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new System.Drawing.Size(856, 48);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "¿Qué valores finales muestran suma y cantidad? El ciclo revisa los números del 1 al 10.";
            // 
            // lblCodigo
            // 
            lblCodigo.BackColor = System.Drawing.Color.FromArgb(18, 37, 66);
            lblCodigo.Font = new System.Drawing.Font("Consolas", 15F);
            lblCodigo.ForeColor = System.Drawing.Color.White;
            lblCodigo.Location = new System.Drawing.Point(32, 130);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Padding = new System.Windows.Forms.Padding(22);
            lblCodigo.Size = new System.Drawing.Size(856, 181);
            lblCodigo.TabIndex = 2;
            lblCodigo.Text = "suma = 0\r\ncantidad = 0\r\nfor numero in range(1, 11):\r\n    if numero % 2 == 0:\r\n        suma += numero\r\n        cantidad += 1\r\nprint(suma, cantidad)";
            lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrimeraRespuesta
            // 
            lblPrimeraRespuesta.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblPrimeraRespuesta.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblPrimeraRespuesta.Location = new System.Drawing.Point(80, 330);
            lblPrimeraRespuesta.Name = "lblPrimeraRespuesta";
            lblPrimeraRespuesta.Size = new System.Drawing.Size(280, 30);
            lblPrimeraRespuesta.TabIndex = 3;
            lblPrimeraRespuesta.Text = "Valor final de suma:";
            lblPrimeraRespuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSuma
            // 
            txtSuma.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            txtSuma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSuma.Font = new System.Drawing.Font("Segoe UI", 13F);
            txtSuma.Location = new System.Drawing.Point(370, 330);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new System.Drawing.Size(420, 31);
            txtSuma.TabIndex = 4;
            txtSuma.KeyPress += SoloNumeros_KeyPress;
            // 
            // lblSegundaRespuesta
            // 
            lblSegundaRespuesta.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            lblSegundaRespuesta.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            lblSegundaRespuesta.Location = new System.Drawing.Point(80, 385);
            lblSegundaRespuesta.Name = "lblSegundaRespuesta";
            lblSegundaRespuesta.Size = new System.Drawing.Size(280, 30);
            lblSegundaRespuesta.TabIndex = 5;
            lblSegundaRespuesta.Text = "Cantidad de pares:";
            lblSegundaRespuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCantidad
            // 
            txtCantidad.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCantidad.Font = new System.Drawing.Font("Segoe UI", 13F);
            txtCantidad.Location = new System.Drawing.Point(370, 385);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new System.Drawing.Size(420, 31);
            txtCantidad.TabIndex = 6;
            txtCantidad.KeyPress += SoloNumeros_KeyPress;
            // 
            // btnComprobar
            // 
            btnComprobar.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
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
            // DevEx3
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(1040, 720);
            Controls.Add(panelEjercicio);
            Controls.Add(panelHeader);
            MinimumSize = new System.Drawing.Size(1040, 720);
            Name = "DevEx3";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEx | Ejercicio 3";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelEjercicio.ResumeLayout(false);
            panelEjercicio.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelEjercicio;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPrimeraRespuesta;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.Label lblSegundaRespuesta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnComprobar;
    }
}