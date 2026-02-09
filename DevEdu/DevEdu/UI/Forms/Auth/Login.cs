using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            string conexion = "Server=localhost;Database=baseusuarios;Uid=root;password=123456;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                conn.Open();

                string query = @"SELECT id, nombre, rango, tipo
                       FROM usuarios
                       WHERE correo = @correo
                         AND contrasena = @pass
                         AND activo = 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@pass", pass);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Sesion.IdUsuario = dr.GetInt32("id");
                    Sesion.Nombre = dr.GetString("nombre");
                    Sesion.Rango = dr.GetString("rango");
                    Sesion.Tipo = dr.IsDBNull(dr.GetOrdinal("tipo"))
                                    ? null
                                    : dr.GetString("tipo");

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

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
