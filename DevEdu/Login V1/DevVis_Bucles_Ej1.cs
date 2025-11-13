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
    public partial class DevVis_Bucles_Ej1 : Form
    {
        private Timer timer;
        private int Actual = 0;

        public DevVis_Bucles_Ej1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
        }

        private void limpiar()
        {
            TxtBox0_DevVis.Clear();
            TxtBox1_DevVis.Clear();
            TxtBox2_DevVis.Clear();
            TxtBox3_DevVis.Clear();
            TxtBox4_DevVis.Clear();
            TxtBox5_DevVis.Clear();
        }

        private void Btn_Iniciar_DevVis_Click(object sender, EventArgs e)
        {
            Actual = 0;
            limpiar();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Actual == 0)
            {
                TxtBox0_DevVis.Text = "0";
            }
            else if (Actual == 1)
            {
                TxtBox1_DevVis.Text = "2";
            }
            else if (Actual == 2)
            {
                TxtBox2_DevVis.Text = "4";
            }
            else if (Actual == 3)
            {
                TxtBox3_DevVis.Text = "6";
            }
            else if (Actual == 4)
            {
                TxtBox4_DevVis.Text = "8";
            }
            else if (Actual == 5)
            {
                TxtBox5_DevVis.Text = "10";
            }

            Actual++;

            if (Actual > 5) 
            {
                timer.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevVisMenu principal = new DevVisMenu();
            principal.ShowDialog();
            this.Close();
        }

        private void DevVis_Bucles_Ej1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void TxtBox5_DevVis_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
