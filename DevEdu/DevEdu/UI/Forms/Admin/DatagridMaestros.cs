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
    public partial class DatagridMaestros : Form
    {
        public DatagridMaestros()
        {
            InitializeComponent();
        }

        private void DatagripMaestros_Load(object sender, EventArgs e)
        {
            if (!permisos()) return;

            txtCount.Enabled = false;
            txtbox_ID.ReadOnly = true;
            DataGrid.EnableHeadersVisualStyles = false;
            CargarDatos();
            UsuariosCount();
        }

        private Maestro ObtenerUsuario()
        {
            return new Maestro
            {
                Id = int.Parse(txtbox_ID.Text),
                Nombre = txtbox_Nombre.Text.Trim(),
                Apellido = txtbox_Apellido.Text.Trim(),
                Correo = txtbox_Correo.Text.Trim()
            };
        }

        private void UsuariosCount()
        {
            try
            {
                using (SELECT select = new SELECT())
                {
                    object result = select.ExecuteScalar("SELECT COUNT(*) FROM maestros;");
                    txtCount.Text = "Usuarios: " + Convert.ToInt32(result).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool permisos()
        {
            if (Sesion.Rango == "Regular")
            {
                MessageBox.Show("Acceso denegado.");
                Close();
                return false;
            }
            if (Sesion.Rango == "Supervision")
            {
                btn_Editar.Enabled = false;
                btn_eliminar.Enabled = false;
                txtbox_Nombre.ReadOnly = true;
                txtbox_Apellido.ReadOnly = true;
                txtbox_Correo.ReadOnly = true;
                DataGrid.ReadOnly = true;
            }
            return true;
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
                             INNER JOIN maestros m ON m.usuario_id = u.id
                             WHERE u.activo = 1";

                using (SELECT select = new SELECT())
                {
                    DataTable dt = select.ExecuteSelect(query);
                    DataGrid.DataSource = dt;
                    DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                UsuariosCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool VALIDACIONES()
        {
            if (txtbox_Nombre.Text == "")
            {
                MessageBox.Show("El Campo 'Nombre' no puede estar vacio");
                return false;
            }
            else if (txtbox_Apellido.Text == "")
            {
                MessageBox.Show("El campo 'Apellido' no puede estar vacio");
                return false;
            }
            else if (!txtbox_Nombre.Text.All(char.IsLetter))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Nombre.Focus();
                return false;
            }
            else if (!txtbox_Apellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El Apellido solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Apellido.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarID()
        {
            if (string.IsNullOrWhiteSpace(txtbox_ID.Text))
            {
                MessageBox.Show("El ID es obligatorio");
                return false;
            }
            if (!int.TryParse(txtbox_ID.Text, out _))
            {
                MessageBox.Show("El ID debe ser numérico");
                return false;
            }
            return true;
        }

        private bool ValidarCorreo()
        {
            string correo = txtbox_Correo.Text.Trim();
            if (correo == "")
            {
                MessageBox.Show("El correo es obligatorio");
                txtbox_Correo.Focus();
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Correo inválido");
                txtbox_Correo.Focus();
                return false;
            }
            return true;
        }

        private bool CorreoDisponible(Maestro usuario)
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

        private void LimpiarCampos()
        {
            txtbox_Nombre.Clear();
            txtbox_Apellido.Clear();
            txtbox_ID.Clear();
            txtbox_Correo.Clear();
        }

        private void EliminarDato()
        {
            DialogResult r = MessageBox.Show(
                "¿Deseas quitar el rol de maestro a este usuario?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.No) return;

            try
            {
                using (DELETE delete = new DELETE())
                {
                    delete.ExecuteDelete(
                        "DELETE FROM maestros WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", txtbox_ID.Text) });
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo=NULL WHERE id=@id;",
                        new[] { new SqlParameter("@id", txtbox_ID.Text) });
                }

                MessageBox.Show("Rol maestro removido (ahora es pendiente).");
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
            Maestro usuario = ObtenerUsuario();

            if (!ValidarCorreo()) return;

            if (!CorreoDisponible(usuario))
            {
                MessageBox.Show("Ese correo ya está registrado en otro usuario.");
                txtbox_Correo.Focus();
                return;
            }

            try
            {
                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        @"UPDATE usuarios
                          SET nombre=@nombre,
                              apellido=@apellido,
                              correo=@correo
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

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (ValidarID() && VALIDACIONES() && ValidarCorreo()) EditarDatos();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (ValidarID()) EliminarDato();
        }

        private void btn_Mostrar_Click(object sender, EventArgs e) => CargarDatos();

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtbox_ID.Text = DataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtbox_Nombre.Text = DataGrid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtbox_Apellido.Text = DataGrid.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtbox_Correo.Text = DataGrid.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtbox_ID_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}