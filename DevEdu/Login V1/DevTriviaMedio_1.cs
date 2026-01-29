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
    public partial class DevTriviaMedio_1 : Form
    {
        public DevTriviaMedio_1()
        {
            InitializeComponent();
        }

        private void message()
        {
            MessageBox.Show("Respuesta Incorrecta, intente otra vez.", "DevTrivia");
        }

        private void Btn_Cplpl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta Correcta", "DevTrivia");
            this.Hide();
            DevTrivia_M_Ex1 Principal = new DevTrivia_M_Ex1();
            Principal.ShowDialog();
            this.Close();
        }

        private void Btn_CShp_Click(object sender, EventArgs e)
        {
            message();
        }

        private void Btn_GO_Click(object sender, EventArgs e)
        {
            message();
        }

        private void Btn_Phyton_Click(object sender, EventArgs e)
        {
            message();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
