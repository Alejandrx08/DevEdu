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
    public partial class DevHubMenu : Form
    {
        public DevHubMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu Principal = new FrmMainMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatagridMaestros Principal = new DatagridMaestros();
            Principal.ShowDialog();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatagridAlumnos Principal = new DatagridAlumnos();
            Principal.ShowDialog();
        }

        private void arrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Hide();
            Arrays Principal = new Arrays();
            Principal.ShowDialog();
            this.Close();
        }

        private void DevHubMenu_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
