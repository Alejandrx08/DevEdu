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

namespace Login_V1
{
    public partial class DgvGeneralAdd : Form
    {
        public DgvGeneralAdd()
        {
            InitializeComponent();
        }

        string conexion = "Server=localhost;Database=baseusuarios;Uid=root;password=123456;";

        private void DgvGeneralAdd_Load(object sender, EventArgs e)
        {
        }

        private bool ValidacionVacio()
        {
            if (string.IsNullOrWhiteSpace(txtbx_nombre.Text) ||
                string.IsNullOrWhiteSpace(txtbx_apellido.Text) ||
                string.IsNullOrWhiteSpace(txtbx_correo.Text) ||
                string.IsNullOrWhiteSpace(txtbx_contrasena.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return true;
            }
            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ValidacionVacio();

            if (int.TryParse(txtbx_nombre.Text, out _))
            {
                MessageBox.Show("El nombre no puede ser un número.");
                return;
            }
            if (int.TryParse(txtbx_apellido.Text, out _))
            {
                MessageBox.Show("El apellido no puede ser un número.");
                return;
            }

            string nombre = txtbx_nombre.Text.Trim();
            string apellido = txtbx_apellido.Text.Trim();
            string correo = txtbx_correo.Text.Trim();
            string pass = txtbx_contrasena.Text;

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Correo inválido.");
                txtbx_correo.Focus();
                return;
            }
            if (pass.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                return;
            }

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
                            MessageBox.Show("Usuario agregado con exito.");

                            txtbx_nombre.Clear();
                            txtbx_apellido.Clear();
                            txtbx_correo.Clear();
                            txtbx_contrasena.Clear();
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
    }
}
