using DevEdu.Core.Models;
using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class Login : Form
    {
        private readonly AuthService _authService = new AuthService();

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Log_Click_1(object sender, EventArgs e)
        {
            string correo = txt_username.Text.Trim();
            string pass = txt_Password.Text;

            if (!LoginValidator.EsValido(correo, pass, out string mensajeError))
            {
                MessageBox.Show(mensajeError);
                return;
            }

            try
            {
                UsuarioAutenticado usuario = _authService.IniciarSesion(correo, pass);

                if (usuario == null)
                {
                    MessageBox.Show("Correo o contraseña incorrectos");
                    return;
                }

                Sesion.IdUsuario = usuario.Id;
                Sesion.Nombre = usuario.Nombre;
                Sesion.Rango = usuario.Rango;
                Sesion.Tipo = usuario.Tipo;

                MessageBox.Show("Bienvenido " + Sesion.Nombre);

                this.Hide();
                FrmMainMenu Principal = new FrmMainMenu();
                Principal.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
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