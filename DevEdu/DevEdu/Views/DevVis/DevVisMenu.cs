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
    public partial class DevVisMenu : Form
    {
        public DevVisMenu()
        {
            InitializeComponent();
        }

        //Programacion modular para llamar al formulario de Bucles
        private void Bucles()
        {
            this.Hide();
            DevVis_Bucles_Ej1 principal = new DevVis_Bucles_Ej1();
            principal.ShowDialog();
            this.Close();
        }

        private void estructurasDTS()
        {
            this.Hide();
            DevVis_ESTDTS_ej1 principal = new DevVis_ESTDTS_ej1 ();
            principal.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }

        //Llamar al formulario de Bucles
        private void btn_bucles_Click(object sender, EventArgs e)
        {
            Bucles();
        }

        private void picbx_bucles_Click(object sender, EventArgs e)
        {
            Bucles();
        }
        private void btn_estructurasDTS_Click(object sender, EventArgs e)
        {
            estructurasDTS();
        }
        private void picbx_EstDts_Click(object sender, EventArgs e)
        {
            estructurasDTS();
        }
        private void DevVisMenu_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btn_DevTrivia_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
