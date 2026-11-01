using System;
using System.Windows.Forms;

namespace DevEdu.UI.Forms.DevTrivia
{
    public partial class DevTriviaDificil_2 : Form
    {
        public DevTriviaDificil_2() => InitializeComponent();

        private void Btn_Cplpl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Respuesta correcta.", "DevTrivia");
            Hide();
            using (var explicacion = new DevTrivia_D_Ex2()) explicacion.ShowDialog(this);
            Close();
        }

        private void Btn_GO_Click(object sender, EventArgs e) => Incorrecta();
        private void Btn_Phyton_Click(object sender, EventArgs e) => Incorrecta();
        private void Btn_CShp_Click(object sender, EventArgs e) => Incorrecta();

        private void Incorrecta()
        {
            MessageBox.Show("Respuesta incorrecta. Piensa qué parte maneja el error y cuál permite hacer la limpieza final.", "DevTrivia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
