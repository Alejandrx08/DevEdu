using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Core.Services;
using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class Login : Form, ILoginView
    {
        private readonly LoginPresenter _presenter;

        public Login()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this, new AuthService());
        }

        public string Correo => txt_username.Text.Trim();
        public string Password => txt_Password.Text;

        public void MostrarError(string mensaje) => MessageBox.Show(mensaje);
        public void MostrarBienvenida(string nombre) => MessageBox.Show("Bienvenido " + nombre);

        public void NavegarAMenuPrincipal()
        {
            this.Hide();
            FrmMainMenu Principal = new FrmMainMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void btn_Log_Click_1(object sender, EventArgs e)
        {
            _presenter.IniciarSesion();
        }

        private void Link_registro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmRegistro Principal = new FrmRegistro();
            Principal.ShowDialog();
            this.Close();
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_Log_Click_1(sender, e);
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txt_Password.Focus();
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e) { }
        private void Login_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}