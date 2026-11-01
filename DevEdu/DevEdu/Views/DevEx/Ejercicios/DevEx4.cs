using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevEx4 : Form
    {
        public DevEx4()
        {
            InitializeComponent();
            AcceptButton = btnComprobar;
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTotal.Text, out int total))
            {
                MessageBox.Show("Escribe un número entero para el valor final de total.", "Respuesta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotal.Focus();
                return;
            }
            if (!int.TryParse(txtIteraciones.Text, out int iteraciones))
            {
                MessageBox.Show("Escribe cuántas veces se ejecuta el ciclo interno.", "Respuesta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIteraciones.Focus();
                return;
            }
            if (total != 36 || iteraciones != 9)
            {
                MessageBox.Show("Cada pareja fila-columna suma fila * columna. Cuenta las tres vueltas internas por cada fila.", "Inténtalo otra vez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("¡Correcto! El total es 36 y el ciclo interno se ejecuta 9 veces.", "DevEx", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            using (var explicacion = new DevEx_4_Exp()) explicacion.ShowDialog(this);
            Close();
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();
    }
}
