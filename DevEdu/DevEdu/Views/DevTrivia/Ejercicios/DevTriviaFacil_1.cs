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
    public partial class DevTriviaFacil_1 : Form
    {
        public DevTriviaFacil_1()
        {
            InitializeComponent();
        }

        private void Btn_BucleFor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta Correcta", "DevTrivia");
            this.Hide();
            DevTrivia_F_Ex1 Principal = new DevTrivia_F_Ex1();
            Principal.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }

        private void message()
        {
            MessageBox.Show("Respuesta Incorrecta, intente otra vez.", "DevTrivia");
        }

        private void Btn_Matriz_Click(object sender, EventArgs e)
        {
            message();
        }

        private void Btn_BucleWhile_Click(object sender, EventArgs e)
        {
            message();
        }

        private void Btn_Algoritmo_Click(object sender, EventArgs e)
        {
           message();
        }

        private void DevTriviaDificil_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
