namespace DevEdu
{
    partial class DevEx4
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelEjercicio = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPrimeraRespuesta = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSegundaRespuesta = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelEjercicio.SuspendLayout();
            this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.panelHeader.Controls.Add(this.lblMarca);
            this.panelHeader.Controls.Add(this.btnVolver);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(1040, 78);
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(32, 14);
            this.lblMarca.Text = "DevEx";
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(20, 52, 101);
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(845, 18);
            this.btnVolver.Size = new System.Drawing.Size(165, 40);
            this.btnVolver.Text = "← Volver a ejercicios";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.panelEjercicio.BackColor = System.Drawing.Color.White;
            this.panelEjercicio.Controls.Add(this.lblTitulo);
            this.panelEjercicio.Controls.Add(this.lblInstruccion);
            this.panelEjercicio.Controls.Add(this.lblCodigo);
            this.panelEjercicio.Controls.Add(this.lblPrimeraRespuesta);
            this.panelEjercicio.Controls.Add(this.txtTotal);
            this.panelEjercicio.Controls.Add(this.lblSegundaRespuesta);
            this.panelEjercicio.Controls.Add(this.txtIteraciones);
            this.panelEjercicio.Controls.Add(this.btnComprobar);
            this.panelEjercicio.Location = new System.Drawing.Point(60, 112);
            this.panelEjercicio.Size = new System.Drawing.Size(920, 570);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblTitulo.Location = new System.Drawing.Point(32, 20);
            this.lblTitulo.Size = new System.Drawing.Size(856, 42);
            this.lblTitulo.Text = "Ejercicio 4 · Ciclos anidados";
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInstruccion.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblInstruccion.Location = new System.Drawing.Point(32, 72);
            this.lblInstruccion.Size = new System.Drawing.Size(856, 48);
            this.lblInstruccion.Text = "¿Cuál es el valor final de total y cuántas veces se ejecuta el ciclo interno?";
            this.lblCodigo.BackColor = System.Drawing.Color.FromArgb(18, 37, 66);
            this.lblCodigo.Font = new System.Drawing.Font("Consolas", 15F);
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(32, 130);
            this.lblCodigo.Padding = new System.Windows.Forms.Padding(22);
            this.lblCodigo.Size = new System.Drawing.Size(856, 174);
            this.lblCodigo.Text = "total = 0\r\nfor fila in range(1, 4):\r\n    for columna in range(1, 4):\r\n        total += fila * columna\r\nprint(total)";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimeraRespuesta.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrimeraRespuesta.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblPrimeraRespuesta.Location = new System.Drawing.Point(80, 330);
            this.lblPrimeraRespuesta.Size = new System.Drawing.Size(280, 30);
            this.lblPrimeraRespuesta.Text = "Valor final de total:";
            this.lblPrimeraRespuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtTotal.Location = new System.Drawing.Point(370, 330);
            this.txtTotal.Size = new System.Drawing.Size(420, 31);
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            this.lblSegundaRespuesta.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSegundaRespuesta.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblSegundaRespuesta.Location = new System.Drawing.Point(80, 385);
            this.lblSegundaRespuesta.Size = new System.Drawing.Size(280, 30);
            this.lblSegundaRespuesta.Text = "Vueltas del ciclo interno:";
            this.lblSegundaRespuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtIteraciones.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.txtIteraciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIteraciones.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtIteraciones.Location = new System.Drawing.Point(370, 385);
            this.txtIteraciones.Size = new System.Drawing.Size(420, 31);
            this.txtIteraciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            this.btnComprobar.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnComprobar.ForeColor = System.Drawing.Color.White;
            this.btnComprobar.Location = new System.Drawing.Point(350, 475);
            this.btnComprobar.Size = new System.Drawing.Size(220, 50);
            this.btnComprobar.Text = "Comprobar respuesta";
            this.btnComprobar.Click += new System.EventHandler(this.btnComprobar_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.panelEjercicio);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1040, 720);
            this.Name = "DevEx4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEx | Ejercicio 4";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelEjercicio.ResumeLayout(false);
            this.panelEjercicio.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelEjercicio;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPrimeraRespuesta;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSegundaRespuesta;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.Button btnComprobar;
    }
}