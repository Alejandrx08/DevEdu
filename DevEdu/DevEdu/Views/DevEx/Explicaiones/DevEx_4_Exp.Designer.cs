namespace DevEdu
{
    partial class DevEx_4_Exp
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
            this.lblTitle.Text = "¿Cómo se recorren los ciclos anidados?";
            this.lblBody.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBody.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblBody.Location = new System.Drawing.Point(28, 90);
            this.lblBody.Size = new System.Drawing.Size(864, 385);
            this.lblBody.Text = "El ciclo externo usa range(1, 4), por eso fila toma 1, 2 y 3. Para cada valor de fila, el ciclo interno vuelve a recorrer columna = 1, 2 y 3.\r\n\r\nCada pareja agrega fila * columna a total:\r\n• fila 1: 1×1 + 1×2 + 1×3 = 6.\r\n• fila 2: 2×1 + 2×2 + 2×3 = 12.\r\n• fila 3: 3×1 + 3×2 + 3×3 = 18.\r\n\r\nEl total es 6 + 12 + 18 = 36. El ciclo interno recorre 3 columnas por cada una de las 3 filas, así que se ejecuta 3 × 3 = 9 veces. print(total) muestra 36.";
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
            this.Name = "DevEx_4_Exp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevEx | Explicación del ejercicio 4";
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