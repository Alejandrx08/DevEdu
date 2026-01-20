using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_V1
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            if (!Sesion.EsAdmin){ 
                menuStrip1.Visible = false;
                menuStrip1.Enabled = false;
                maestrosToolStripMenuItem.Enabled = false;
                alumnosToolStripMenuItem.Enabled=false;
                arraysToolStripMenuItem.Enabled = false;
            }
        }

        private void devtrivia()
        {
            this.Hide();
            DevTriviaMenu Principal = new DevTriviaMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void devvis()
        {
            this.Hide();
            DevVisMenu Principal = new DevVisMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void devex()
        {
            this.Hide();
            DevEx Principal = new DevEx();
            Principal.ShowDialog();
            this.Close();
        }

        private void devbot()
        {
            this.Hide();
            DevbotChat Principal = new DevbotChat();
            Principal.ShowDialog();
            this.Close();
        }

        private void devhub()
        {
            this.Hide();
            DevHubMenu Principal = new DevHubMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void btn_DevTrivia_Click(object sender, EventArgs e)
        {
            devtrivia();
        }

        private void btn_DevVis_Click(object sender, EventArgs e)
        {
            devvis();
        }

        private void btn_DevEx_Click(object sender, EventArgs e)
        {
            devex();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            devbot();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            devtrivia();
        }

        private void Exp_Ex_Click(object sender, EventArgs e)
        {
           devex();
        }

        private void Exp_Vis_Click(object sender, EventArgs e)
        {
            devvis();
        }

        private void btn_DevBot_Click(object sender, EventArgs e)
        {
           devbot();
        }

        private void Exp_Hub_Click(object sender, EventArgs e)
        {
            devhub();
        }

        private void btn_DevHub_Click(object sender, EventArgs e)
        {
            devhub();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void arraysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Arrays Principal = new Arrays();
            Principal.ShowDialog();
            this.Close();
        }
        private void alumnosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DatagridAlumnos Principal = new DatagridAlumnos();
            Principal.ShowDialog();
        }
        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatagridMaestros Principal = new DatagridMaestros();
            Principal.ShowDialog();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void txt_username_menu_Click(object sender, EventArgs e)
        {

        }
    }
}
