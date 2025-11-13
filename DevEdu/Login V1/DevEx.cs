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
    public partial class DevEx : Form
    {
        public DevEx()
        {
            InitializeComponent();
        }

        private void validacion_Number(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {  
                e.Handled = true;
            }
        }
        
        private void respuesta()
        {
            if ((TxtBox_a.Text == "1") && (TxtBox_b.Text == "6"))
            {
                MessageBox.Show("Correcto", "DevTrivia");
                this.Hide();
                DevEx_1_Exp Principal = new DevEx_1_Exp();
                Principal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrecto, Intente otra vez", "DevTrivia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBox_a.Text = "";
                TxtBox_b.Text = "";
                TxtBox_a.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtBox_a.Text) && string.IsNullOrEmpty(TxtBox_b.Text))
            {
                MessageBox.Show("Por favor, complete Ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(TxtBox_b.Text))
            {
                MessageBox.Show("Por favor, complete el campo B.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBox_b.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtBox_a.Text))
            {
                MessageBox.Show("Por favor, complete el campo A.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBox_a.Focus();
                return;
            }
            else
            {
                respuesta();
            }
        }

        private void TxtBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion_Number(e);
        }

        private void TxtBox_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion_Number(e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void DevEx_1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
