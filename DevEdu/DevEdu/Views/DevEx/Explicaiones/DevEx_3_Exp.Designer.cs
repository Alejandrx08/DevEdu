namespace DevEdu
{
    partial class DevEx_3_Exp
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.panelHeader.Controls.Add(this.lblMarca);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(1040, 78);
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(32, 14);
            this.lblMarca.Text = "DevEx";
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Controls.Add(this.lblBody);
            this.panelContent.Location = new System.Drawing.Point(60, 112);
            this.panelContent.Size = new System.Drawing.Size(920, 500);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.lblTitle.Location = new System.Drawing.Point(28, 24);
            this.lblTitle.Size = new System.Drawing.Size(864, 52);
            this.lblTitle.Text = "¿Cómo funcionan la condición y los acumuladores?";
            this.lblBody.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBody.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblBody.Location = new System.Drawing.Point(28, 90);
            this.lblBody.Size = new System.Drawing.Size(864, 385);
            this.lblBody.Text = "El ciclo range(1, 11) visita los enteros del 1 al 10: empieza en 1 y se detiene antes de 11. Por eso hace 10 vueltas.\r\n\r\nLa condición numero % 2 == 0 pregunta si el residuo de dividir numero entre 2 es cero. Se cumple con 2, 4, 6, 8 y 10.\r\n\r\nSolo para esos cinco valores se ejecuta el bloque indentado:\r\n• suma agrega el valor: 2 + 4 + 6 + 8 + 10 = 30.\r\n• cantidad aumenta una unidad por cada par y termina en 5.\r\n\r\nAsí, print(suma, cantidad) muestra 30 y 5. El ciclo revisa diez números, pero la condición selecciona cinco pares.";
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(780, 640);
            this.btnVolver.Size = new System.Drawing.Size(200, 48);
            this.btnVolver.Text = "Volver a ejercicios";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1040, 720);
            this.Name = "DevEx_3_Exp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEx | Explicación del ejercicio 3";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Button btnVolver;
    }
}