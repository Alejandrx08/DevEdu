namespace DevEdu
{
    partial class Welcome_Splash
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome_Splash));
            AppName = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AppName
            // 
            AppName.AutoSize = true;
            AppName.BackColor = System.Drawing.Color.Transparent;
            AppName.Font = new System.Drawing.Font("Segoe UI Semibold", 49.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            AppName.ForeColor = System.Drawing.Color.White;
            AppName.Location = new System.Drawing.Point(243, 78);
            AppName.Name = "AppName";
            AppName.Size = new System.Drawing.Size(270, 89);
            AppName.TabIndex = 0;
            AppName.Text = "DevEdu";
            AppName.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(116, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(110, 110);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = System.Drawing.Color.Aqua;
            progressBar1.Cursor = System.Windows.Forms.Cursors.No;
            progressBar1.Location = new System.Drawing.Point(171, 200);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(287, 30);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Welcome_Splash
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            ClientSize = new System.Drawing.Size(617, 302);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(AppName);
            Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Welcome_Splash";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEdu";
            Load += Welcome_Splash_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}