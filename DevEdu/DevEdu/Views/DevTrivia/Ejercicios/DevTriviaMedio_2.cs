using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevTriviaMedio_2 : Form
    {
        public DevTriviaMedio_2() => InitializeComponent();

        private void Btn_GO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta correcta.", "DevTrivia");
            Hide();
            using (var explicacion = new DevTrivia_M_Ex2()) explicacion.ShowDialog(this);
            Close();
        }

        private void Btn_Phyton_Click(object sender, EventArgs e) => Incorrecta();
        private void Btn_Cplpl_Click(object sender, EventArgs e) => Incorrecta();
        private void Btn_CShp_Click(object sender, EventArgs e) => Incorrecta();
        private void label1_Click_1(object sender, EventArgs e) { }

        private void Incorrecta()
        {
            MessageBox.Show("Respuesta incorrecta. Revisa cómo se conectan los eventos con sus métodos manejadores.", "DevTrivia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
