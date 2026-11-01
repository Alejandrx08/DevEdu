using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class Welcome_Splash : Form
    {
        public Welcome_Splash()
        {
            InitializeComponent();
        }

        private void Welcome_Splash_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value = Math.Min(progressBar1.Value + 2, progressBar1.Maximum);

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();
                Hide();
                using (Login login = new Login())
                    login.ShowDialog();
                Close();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
    }
}
