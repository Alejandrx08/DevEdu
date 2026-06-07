using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Log_Click_1(object sender, EventArgs e)
        {
            string correo = txt_username.Text.Trim();
            string pass = txt_Password.Text;

            if (correo == "" || pass == "")
            {
                MessageBox.Show("Ingresa correo y contraseña");
                return;
            }

            try
            {
                string query = @"SELECT id, nombre, rango, tipo
                                 FROM usuarios
                                 WHERE correo = @correo
                                   AND contrasena = @pass
                                   AND activo = 1";

                SqlParameter[] parametros =
                {
                    new SqlParameter("@correo", correo),
                    new SqlParameter("@pass", pass)
                };

                using (SELECT select = new SELECT())
                {
                    DataTable result = select.ExecuteSelect(query, parametros);

                    if (result.Rows.Count > 0)
                    {
                        DataRow row = result.Rows[0];

                        Sesion.IdUsuario = Convert.ToInt32(row["id"]);
                        Sesion.Nombre = row["nombre"].ToString();
                        Sesion.Rango = row["rango"].ToString();
                        Sesion.Tipo = row["tipo"] == DBNull.Value
                                        ? null
                                        : row["tipo"].ToString();

                        MessageBox.Show("Bienvenido " + Sesion.Nombre);

                        this.Hide();
                        FrmMainMenu Principal = new FrmMainMenu();
                        Principal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Correo o contraseña incorrectos");
                    }
                }
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