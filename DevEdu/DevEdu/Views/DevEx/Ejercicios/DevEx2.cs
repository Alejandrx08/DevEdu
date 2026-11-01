using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevEx2 : Form
    {
        public DevEx2()
        {
            InitializeComponent();
            AcceptButton = btnComprobar;
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show(
                    "Escribe el valor final de total.",
                    "Respuesta incompleta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTotal.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIteraciones.Text))
            {
                MessageBox.Show(
                    "Escribe cuántas veces se ejecuta el ciclo.",
                    "Respuesta incompleta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtIteraciones.Focus();
                return;
            }

            bool totalValido = int.TryParse(txtTotal.Text, out int total);
            bool iteracionesValidas =
                int.TryParse(txtIteraciones.Text, out int iteraciones);

            if (totalValido && iteracionesValidas
                && total == 15 && iteraciones == 5)
            {
                MessageBox.Show(
                    "¡Correcto! Identificaste las cinco iteraciones y el valor acumulado.",
                    "DevEx",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Hide();
                using (var explicacion = new DevEx_2_Exp())
                {
                    explicacion.ShowDialog(this);
                }
                Close();
                return;
            }

            MessageBox.Show(
                "Todavía no coincide. Recuerda que total empieza en 0 y que range(1, 6) produce 1, 2, 3, 4 y 5. Vuelve a sumar esos valores.",
                "Revisa el ciclo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}