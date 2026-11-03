using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Core.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class Login : Form, ILoginView
    {
        private readonly LoginPresenter _presenter;
        private bool _iniciandoSesion;

        public Login()
        {
            InitializeComponent();
            // La vista entrega eventos y datos al presenter; el servicio gestiona el acceso.
            _presenter = new LoginPresenter(this, new AuthService());

            var linkRecuperar = new LinkLabel
            {
                Text = "¿Olvidaste tu contraseña?",
                AutoSize = true,
                Location = new Point(55, 392),
                Font = new Font("Segoe UI", 9F),
                LinkColor = Color.Navy,
                ActiveLinkColor = Color.FromArgb(0, 31, 84),
                VisitedLinkColor = Color.Navy
            };
            linkRecuperar.LinkClicked += LinkRecuperar_LinkClicked;
            groupBox1.Controls.Add(linkRecuperar);
        }

        public string Correo => txt_username.Text.Trim();
        public string Password => txt_Password.Text;

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Inicio de sesión",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void MostrarBienvenida(string nombre)
        {
            MessageBox.Show("Bienvenido " + nombre);
        }

        public void NavegarAMenuPrincipal()
        {
            Hide();
            using (FrmMainMenu principal = new FrmMainMenu())
                principal.ShowDialog();
            Close();
        }

        private async void btn_Log_Click_1(object sender, EventArgs e)
        {
            await EjecutarInicioSesionAsync();
        }

        private async Task EjecutarInicioSesionAsync()
        {
            if (_iniciandoSesion)
                return;

            _iniciandoSesion = true;
            btn_Login.Enabled = false;
            try
            {
                await _presenter.IniciarSesionAsync();
            }
            finally
            {
                _iniciandoSesion = false;
                if (!IsDisposed && !Disposing)
                    btn_Login.Enabled = true;
            }
        }

        private void Link_registro_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            using (FrmRegistro principal = new FrmRegistro())
                principal.ShowDialog();
            Close();
        }

        private void LinkRecuperar_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var recuperar = new Views.Auth.FrmRecuperarContrasena())
                recuperar.ShowDialog(this);
        }

        private async void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await EjecutarInicioSesionAsync();
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



