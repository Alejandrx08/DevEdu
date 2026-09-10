using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class FrmRegistro : Form, IRegistroView
    {
        private readonly RegistroPresenter _presenter;

        public FrmRegistro()
        {
            InitializeComponent();
            _presenter = new RegistroPresenter(this, new UsuarioService());
        }

        public string Nombre => txtbx_nombre.Text.Trim();
        public string Apellido => txtbx_apellido.Text.Trim();
        public string Correo => txtbx_correo.Text.Trim();
        public string Password => txtbx_contrasena.Text;
        public string Confirmacion => txtbx_confirmacion.Text;

        public void MostrarError(string mensaje) => MessageBox.Show(mensaje);
        public void MostrarExito(string mensaje) => MessageBox.Show(mensaje);

        public void LimpiarCampos()
        {
            txtbx_nombre.Clear();
            txtbx_apellido.Clear();
            txtbx_correo.Clear();
            txtbx_contrasena.Clear();
            txtbx_confirmacion.Clear();
            txtbx_nombre.Focus();
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            _presenter.Registrar();
        }

        private void btn_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsLetter(e.KeyChar)) e.Handled = true;
        }

        private void txtbx_nombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarSoloLetras((TextBox)sender);
        }

        private void txtbx_apellido_TextChanged(object sender, EventArgs e)
        {
            FiltrarSoloLetras((TextBox)sender);
        }

        private void FiltrarSoloLetras(TextBox tb)
        {
            int selectionStart = tb.SelectionStart;
            string cleaned = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsControl(c)).ToArray());
            if (tb.Text != cleaned)
            {
                tb.Text = cleaned;
                tb.SelectionStart = Math.Min(selectionStart, tb.Text.Length);
            }
        }

        private void txtbx_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtbx_correo.Focus(); return; }
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsLetter(e.KeyChar)) e.Handled = true;
        }

        private void Link_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login Principal = new Login();
            Principal.ShowDialog();
            this.Close();
        }

        private void txtbx_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtbx_apellido.Focus(); }
        }

        private void txtbx_correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtbx_contrasena.Focus(); }
        }

        private void txtbx_contrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; txtbx_confirmacion.Focus(); }
        }

        private void txtbx_confirmacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; btn_Registrar_Click(sender, e); }
        }

        private void txtbx_correo_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}