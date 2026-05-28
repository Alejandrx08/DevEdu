using DevEdu.Core.Models;
using Microsoft.Data.SqlClient;
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

            ConexionDB db = new ConexionDB();

            using (SqlConnection conn = db.ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT id, nombre, rango, tipo
                       FROM usuarios
                       WHERE correo = @correo
                         AND contrasena = @pass
                         AND activo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int colId = dr.GetOrdinal("id");
                    int colNombre = dr.GetOrdinal("nombre");
                    int colRango = dr.GetOrdinal("rango");
                    int colTipo = dr.GetOrdinal("tipo");

                    Sesion.IdUsuario = dr.GetInt32(colId);
                    Sesion.Nombre = dr.GetString(colNombre);
                    Sesion.Rango = dr.GetString(colRango);
                    Sesion.Tipo = dr.IsDBNull(colTipo)
                                        ? null
                                        : dr.GetString(colTipo);

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
