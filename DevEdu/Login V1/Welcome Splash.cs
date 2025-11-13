using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_V1
{
    public partial class Welcome_Splash : Form
    {
        public Welcome_Splash()
        {
            InitializeComponent();
        }

        private void Welcome_Splash_Load(object sender, EventArgs e)
        {
         
            Timer timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2;

            if (progressBar1.Value >= 100)
            {

                ((Timer)sender).Stop();

                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
