using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevTrivia_F_Ex1 : Form
    {
        public DevTrivia_F_Ex1()
        {
            InitializeComponent();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
