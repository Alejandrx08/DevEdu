namespace DevEdu.Views.Admin
{
    partial class Bitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bitacora));
            txtCount = new System.Windows.Forms.TextBox();
            DgvBitacora = new System.Windows.Forms.DataGridView();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label5 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)DgvBitacora).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtCount
            // 
            txtCount.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtCount.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            txtCount.Location = new System.Drawing.Point(36, 118);
            txtCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCount.Name = "txtCount";
            txtCount.Size = new System.Drawing.Size(280, 18);
            txtCount.TabIndex = 25;
            txtCount.TextChanged += txtCount_TextChanged;
            // 
            // DgvBitacora
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            DgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvBitacora.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DgvBitacora.BackgroundColor = System.Drawing.Color.White;
            DgvBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvBitacora.EnableHeadersVisualStyles = false;
            DgvBitacora.GridColor = System.Drawing.Color.FromArgb(229, 234, 242);
            DgvBitacora.Location = new System.Drawing.Point(32, 154);
            DgvBitacora.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DgvBitacora.Name = "DgvBitacora";
            DgvBitacora.RowTemplate.Height = 34;
            DgvBitacora.Size = new System.Drawing.Size(1116, 566);
            DgvBitacora.TabIndex = 23;
            DgvBitacora.CellContentClick += DgvBitacora_CellContentClick;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.White;
            pictureBox2.Location = new System.Drawing.Point(-200, -200);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(1, 1);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(32, 20);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(304, 41);
            label5.TabIndex = 27;
            label5.Text = "Bitácora de actividad";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(1180, 92);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // Bitacora
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            ClientSize = new System.Drawing.Size(1180, 760);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(txtCount);
            Controls.Add(DgvBitacora);
            Controls.Add(pictureBox2);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1000, 650);
            Name = "Bitacora";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Bitácora de actividad | DevEdu";
            ((System.ComponentModel.ISupportInitialize)DgvBitacora).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.DataGridView DgvBitacora;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}