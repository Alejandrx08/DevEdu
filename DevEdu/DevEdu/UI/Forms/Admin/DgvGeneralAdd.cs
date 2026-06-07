using DevEdu.Core.Services.Query;
using Microsoft.Data.SqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DgvGeneralAdd : Form
    {
        public DgvGeneralAdd()
        {
            InitializeComponent();
        }

        private void DgvGeneralAdd_Load(object sender, EventArgs e) { }

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
            if (ValidacionVacio()) return;

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
                using (SELECT select = new SELECT())
                {
                    object existe = select.ExecuteScalar(
                        "SELECT COUNT(*) FROM usuarios WHERE correo=@correo;",
                        new[] { new SqlParameter("@correo", correo) });

                    if (Convert.ToInt32(existe) > 0)
                    {
                        MessageBox.Show("Ese correo ya está registrado.");
                        return;
                    }
                }

                using (INSERT insert = new INSERT())
                {
                    int filas = insert.ExecuteInsert(
                        @"INSERT INTO usuarios (nombre, apellido, correo, contrasena, rango, tipo, activo)
                          VALUES (@nombre, @apellido, @correo, @pass, 'Regular', NULL, 1);",
                        new[]
                        {
                            new SqlParameter("@nombre", nombre),
                            new SqlParameter("@apellido", apellido),
                            new SqlParameter("@correo", correo),
                            new SqlParameter("@pass", pass)
                        });

                    if (filas > 0)
                    {
                        MessageBox.Show("Usuario agregado con éxito.");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}