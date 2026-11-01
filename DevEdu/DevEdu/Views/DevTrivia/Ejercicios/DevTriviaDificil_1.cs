using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu.UI.Forms.DevTrivia
{
    public partial class DevTriviaDificil_1 : Form
    {
        public DevTriviaDificil_1()
        {
            InitializeComponent();
        }

        private void Btn_GO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta incorrecta.", "DevEdu");
        }

        private void Btn_Phyton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Felicidades, respuesta correcta.", "DevEdu");
            using (var explicacion = new DevTrivia_D_Ex1())
                explicacion.ShowDialog(this);
            Close();
        }

        private void Btn_Cplpl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta incorrecta.", "DevEdu");
        }

        private void Btn_CShp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta incorrecta.", "DevEdu");
        }
        private void button2_Click(object sender, EventArgs e) => Close();

    }
}