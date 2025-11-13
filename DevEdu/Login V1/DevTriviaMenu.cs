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
    public partial class DevTriviaMenu : Form
    {
        public DevTriviaMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }
        private void btn_Facil_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevTriviaFacil_1 Principal = new DevTriviaFacil_1();
            Principal.ShowDialog();
            this.Close();
        }
        private void btn_Medio_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevTriviaMedio Principal = new DevTriviaMedio();
            Principal.ShowDialog();
            this.Close();
        }

        private void DevTriviaMenu_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void btn_Dificil_Click(object sender, EventArgs e)
        {

        }
    }
}
