using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private bool ValidacionVacio()
        {
            if (string.IsNullOrWhiteSpace(txtbx_nombre.Text) ||
                string.IsNullOrWhiteSpace(txtbx_apellido.Text) ||
                string.IsNullOrWhiteSpace(txtbx_correo.Text) ||
                string.IsNullOrWhiteSpace(txtbx_contrasena.Text) ||
                string.IsNullOrWhiteSpace(txtbx_confirmacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return true;
            }
            return false;
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            string nombre = txtbx_nombre.Text.Trim();
            string apellido = txtbx_apellido.Text.Trim();
            string correo = txtbx_correo.Text.Trim();  
            string pass = txtbx_contrasena.Text;


            ValidacionVacio();

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Correo inválido.");
                return;
            }
            if (pass.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                return;
            }
            if (pass != txtbx_confirmacion.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }
            string conexion = "Server=localhost;Database=baseusuarios;Uid=root;password=123456;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion))
                {
                    conn.Open();

                    using (MySqlCommand checkCmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM usuarios WHERE correo=@correo;", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@correo", correo);

                        long existe = (long)checkCmd.ExecuteScalar();
                        if (existe > 0)
                        {
                            MessageBox.Show("Ese correo ya está registrado.");
                            return;
                        }
                    }

                    string query = @"INSERT INTO usuarios (nombre, apellido, correo, contrasena, rango, tipo, activo)
                           VALUES (@nombre, @apellido, @correo, @pass, 'Regular', NULL, 1);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Registro exitoso. Ya puedes iniciar sesión.");

                            txtbx_nombre.Clear();
                            txtbx_apellido.Clear();
                            txtbx_correo.Clear();
                            txtbx_contrasena.Clear();
                            txtbx_confirmacion.Clear();
                            txtbx_nombre.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar. Intenta de nuevo.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar))
                return;

            if(!char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        private void txtbx_nombre_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int SelectionStart = tb.SelectionStart;
            string cleaned = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsControl(c)).ToArray());

            if (tb.Text != cleaned)
            {
                tb.Text = cleaned;
                tb.SelectionStart = Math.Min(SelectionStart, tb.Text.Length);
            }
        }

        private void txtbx_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtbx_correo.Focus();
            }

            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtbx_apellido_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int SelectionStart = tb.SelectionStart;
            string cleaned = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsControl(c)).ToArray());

            if (tb.Text != cleaned)
            {
                tb.Text = cleaned;
                tb.SelectionStart = Math.Min(SelectionStart, tb.Text.Length);
            }
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
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtbx_apellido.Focus();
            }
        }

        private void txtbx_correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtbx_contrasena.Focus();
            }
        }

        private void txtbx_contrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtbx_confirmacion.Focus();
            }
        }

        private void txtbx_confirmacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_Registrar_Click(sender, e);
            }
        }

        private void txtbx_correo_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
