namespace DevEdu
{
    partial class Welcome_Splash
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label AppName;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome_Splash));
            AppName = new System.Windows.Forms.Label();
            lblSlogan = new System.Windows.Forms.Label();
            lblLoading = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(335, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(90, 90);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AppName
            // 
            AppName.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            AppName.ForeColor = System.Drawing.Color.White;
            AppName.Location = new System.Drawing.Point(0, 151);
            AppName.Name = "AppName";
            AppName.Size = new System.Drawing.Size(760, 65);
            AppName.TabIndex = 1;
            AppName.Text = "DevEdu";
            AppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblSlogan.ForeColor = System.Drawing.Color.White;
            lblSlogan.Location = new System.Drawing.Point(0, 224);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new System.Drawing.Size(760, 28);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "Aprende, practica y comparte";
            lblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(190, 300);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(380, 16);
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 3;
            progressBar1.Click += progressBar1_Click;
            // 
            // lblLoading
            // 
            lblLoading.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLoading.ForeColor = System.Drawing.Color.FromArgb(220, 230, 245);
            lblLoading.Location = new System.Drawing.Point(0, 328);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new System.Drawing.Size(760, 22);
            lblLoading.TabIndex = 4;
            lblLoading.Text = "Preparando tu espacio de aprendizaje...";
            lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Welcome_Splash
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 31, 84);
            ClientSize = new System.Drawing.Size(760, 400);
            Controls.Add(lblLoading);
            Controls.Add(progressBar1);
            Controls.Add(lblSlogan);
            Controls.Add(AppName);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Welcome_Splash";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DevEdu";
            Load += Welcome_Splash_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
