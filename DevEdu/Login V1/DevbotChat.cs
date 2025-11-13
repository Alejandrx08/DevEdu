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
    public partial class DevbotChat : Form
    {
        public DevbotChat()
        {
            InitializeComponent();
            TxtBox_DevBot.Focus();
        }

        private void Enviar()
        {
            if (TxtBox_DevBot.Text == "")
            {
                MessageBox.Show("El Campo no puede estar vacio.");
            }
            else
            {
                string userMessage = TxtBox_DevBot.Text;
                TxtBox_DevBot.Clear();
                TxtBox_DevBot.Focus();

                string botResponse = "Estamos Procesando: " + userMessage;
                MessageBox.Show(botResponse);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu principal = new FrmMainMenu();
            principal.ShowDialog();
            this.Close();
        }

        private void Btn_Enviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }

        private void DevbotChat_Load(object sender, EventArgs e)
        {

        }
    }
}
