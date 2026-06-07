using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DatagridAlumnos : Form
    {
        public DatagridAlumnos()
        {
            InitializeComponent();
            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DatagridAlumnos_Load(object sender, EventArgs e)
        {
            txtCount.Enabled = false;
            dataGridViewAlumnos.EnableHeadersVisualStyles = false;
            txtbx_ID.ReadOnly = true;
            permisos();
            CargarDatos();
            UsuariosCount();
        }

        private Alumno ObtenerUsuario()
        {
            return new Alumno
            {
                Id = int.Parse(txtbx_ID.Text),
                Nombre = txtbx_Nombre.Text.Trim(),
                Apellido = txtbx_Apellido.Text.Trim(),
                Correo = txtbx_Correo.Text.Trim()
            };
        }

        private void UsuariosCount()
        {
            try
            {
                using (SELECT select = new SELECT())
                {
                    object result = select.ExecuteScalar("SELECT COUNT(*) FROM alumnos;");
                    txtCount.Text = "Usuarios: " + Convert.ToInt32(result).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void permisos()
        {
            if (Sesion.Rango == "Regular")
            {
                MessageBox.Show("Acceso denegado.");
                Close();
                return;
            }
            if (Sesion.Rango == "Supervision")
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                txtbx_Nombre.ReadOnly = true;
                txtbx_Apellido.ReadOnly = true;
                txtbx_Correo.ReadOnly = true;
                dataGridViewAlumnos.ReadOnly = true;
            }
        }

        private void CargarDatos()
        {
            try
            {
                string query = @"SELECT 
                                u.id       AS ID,
                                u.nombre   AS Nombre,
                                u.apellido AS Apellido,
                                u.correo   AS Correo,
                                u.rango    AS Rango
                             FROM usuarios u
                             INNER JOIN alumnos a ON a.usuario_id = u.id
                             WHERE u.activo = 1";

                using (SELECT select = new SELECT())
                {
                    DataTable dt = select.ExecuteSelect(query);
                    dataGridViewAlumnos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidarCorreo()
        {
            string correo = txtbx_Correo.Text.Trim();
            if (correo == "")
            {
                MessageBox.Show("El correo es obligatorio");
                txtbx_Correo.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Correo inválido");
                txtbx_Correo.Focus();
                return false;
            }
            return true;
        }

        private bool CorreoDisponible(Persona usuario)
        {
            try
            {
                using (SELECT select = new SELECT())
                {
                    object result = select.ExecuteScalar(
                        "SELECT COUNT(*) FROM usuarios WHERE correo=@c AND id<>@id;",
                        new[]
                        {
                            new SqlParameter("@c", usuario.Correo),
                            new SqlParameter("@id", usuario.Id)
                        });
                    return Convert.ToInt32(result) == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private bool VALIDACIONES()
        {
            if (txtbx_Nombre.Text == "")
            {
                MessageBox.Show("El Campo 'Nombre' no puede estar vacio");
                return false;
            }
            else if (txtbx_Apellido.Text == "")
            {
                MessageBox.Show("El campo 'Apellido' no puede estar vacio");
                return false;
            }
            else if (!txtbx_Nombre.Text.All(char.IsLetter))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbx_Nombre.Focus();
                return false;
            }
            else if (!txtbx_Apellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El Apellido solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbx_Apellido.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarID()
        {
            if (string.IsNullOrWhiteSpace(txtbx_ID.Text))
            {
                MessageBox.Show("El ID es obligatorio");
                return false;
            }
            if (!int.TryParse(txtbx_ID.Text, out _))
            {
                MessageBox.Show("El ID debe ser numérico");
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtbx_Nombre.Clear();
            txtbx_Apellido.Clear();
            txtbx_ID.Clear();
            txtbx_Correo.Clear();
        }

        private void EliminarDato()
        {
            DialogResult r = MessageBox.Show(
                "¿Deseas quitar el rol a este usuario?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.No) return;

            try
            {
                using (DELETE delete = new DELETE())
                {
                    delete.ExecuteDelete(
                        "DELETE FROM alumnos WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", txtbx_ID.Text) });
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo=NULL WHERE id=@id;",
                        new[] { new SqlParameter("@id", txtbx_ID.Text) });
                }

                MessageBox.Show("Rol alumno removido (ahora es pendiente).");
                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void EditarDatos()
        {
            Alumno usuario = ObtenerUsuario();

            if (!ValidarCorreo()) return;

            if (!CorreoDisponible(usuario))
            {
                MessageBox.Show("Ese correo ya está registrado en otro usuario.");
                txtbx_Correo.Focus();
                return;
            }

            try
            {
                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        @"UPDATE usuarios
                          SET nombre=@nombre, apellido=@apellido, correo=@correo
                          WHERE id=@id",
                        new[]
                        {
                            new SqlParameter("@id", usuario.Id),
                            new SqlParameter("@nombre", usuario.Nombre),
                            new SqlParameter("@apellido", usuario.Apellido),
                            new SqlParameter("@correo", usuario.Correo)
                        });
                }

                MessageBox.Show("Dato actualizado correctamente");
                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnview_Click_1(object sender, EventArgs e) => CargarDatos();

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (ValidarID()) EliminarDato();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidarID() && VALIDACIONES() && ValidarCorreo()) EditarDatos();
        }

        private void dataGridViewAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtbx_ID.Text = dataGridViewAlumnos.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtbx_Nombre.Text = dataGridViewAlumnos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtbx_Apellido.Text = dataGridViewAlumnos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtbx_Correo.Text = dataGridViewAlumnos.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
            }
        }
    }
}