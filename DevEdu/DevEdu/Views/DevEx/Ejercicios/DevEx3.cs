using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevEx3 : Form
    {
        public DevEx3()
        {
            InitializeComponent();
            AcceptButton = btnComprobar;
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            if (!LeerRespuestas(out int suma, out int cantidad)) return;
            if (suma != 30 || cantidad != 5)
            {
                MessageBox.Show("Revisa qué valores cumplen numero % 2 == 0 y suma solo esos valores.", "Inténtalo otra vez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("¡Correcto! La suma de los pares es 30 y se encontraron 5 números pares.", "DevEx", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            using (var explicacion = new DevEx_3_Exp()) explicacion.ShowDialog(this);
            Close();
        }

        private bool LeerRespuestas(out int suma, out int cantidad)
        {
            suma = 0;
            cantidad = 0;
            if (!int.TryParse(txtSuma.Text, out suma))
            {
                MessageBox.Show("Escribe un número entero para el valor de suma.", "Respuesta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuma.Focus();
                return false;
            }
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Escribe un número entero para la cantidad de pares.", "Respuesta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }
            return true;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();
    }
}
