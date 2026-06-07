using DevEdu.Core.Models;
using DevEdu.Core.Services.Query;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DataGridGeneral : Form
    {
        public DataGridGeneral()
        {
            InitializeComponent();
        }

        private void DataDridGeneral_Load(object sender, EventArgs e)
        {
            if (Sesion.Rango != "SuperSU")
            {
                MessageBox.Show("Acceso denegado.");
                Close();
                return;
            }

            DgvGeneral.EnableHeadersVisualStyles = false;
            txtCount.Enabled = false;
            UsuariosCount();
            CargarUsuariosGeneral();
        }

        private DataTable dtUsuarios;

        private Persona ObtenerUsuarioSeleccionado()
        {
            Persona usuario = new Persona();

            usuario.Id = Convert.ToInt32(
                DgvGeneral.CurrentRow.Cells["id"].Value);

            usuario.Nombre =
                DgvGeneral.CurrentRow.Cells["nombre"].Value?.ToString() ?? "";

            usuario.Apellido =
                DgvGeneral.CurrentRow.Cells["apellido"].Value?.ToString() ?? "";

            usuario.Correo =
                DgvGeneral.CurrentRow.Cells["correo"].Value?.ToString() ?? "";

            usuario.Rango =
                DgvGeneral.CurrentRow.Cells["rango"].Value?.ToString() ?? "";

            usuario.Estado =
                DgvGeneral.CurrentRow.Cells["estado"].Value?.ToString() ?? "";

            usuario.Activo = Convert.ToBoolean(
                DgvGeneral.CurrentRow.Cells["activo"].Value);

            return usuario;
        }

        private void UsuariosCount()
        {
            using (SELECT select = new SELECT())
            {
                object result = select.ExecuteScalar("SELECT COUNT(*) FROM usuarios;");
                txtCount.Text = "Usuarios: " + Convert.ToInt32(result).ToString();
            }
        }

        private void CargarUsuariosGeneral()
        {
            string query = @"SELECT 
                      u.id,
                      u.nombre,
                      u.apellido,
                      u.correo,
                      u.rango,
                      ISNULL(u.tipo, 'pendiente') AS estado,
                      u.activo
                   FROM usuarios u";

            using (SELECT select = new SELECT())
            {
                dtUsuarios = select.ExecuteSelect(query);
                DgvGeneral.DataSource = dtUsuarios;
            }

            DgvGeneral.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvGeneral.MultiSelect = false;
            DgvGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvGeneral.Columns["estado"].ReadOnly = true;
            DgvGeneral.Columns["id"].ReadOnly = true;
        }

        private void EliminarDato()
        {
            if (DgvGeneral.CurrentRow == null || DgvGeneral.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Debe seleccionar un usuario válido.");
                return;
            }

            Persona usuario = ObtenerUsuarioSeleccionado();

            var r = MessageBox.Show(
                $"¿Deseas ELIMINAR el usuario {usuario.ObtenerNombreCompleto()} con ID {usuario.Id}?\n\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                using (DELETE delete = new DELETE())
                {
                    delete.ExecuteDelete(
                        "DELETE FROM alumnos WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                using (DELETE delete = new DELETE())
                {
                    delete.ExecuteDelete(
                        "DELETE FROM maestros WHERE usuario_id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                using (DELETE delete = new DELETE())
                {
                    delete.ExecuteDelete(
                        "DELETE FROM usuarios WHERE id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                MessageBox.Show("Usuario eliminado con éxito.");
                UsuariosCount();
                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            try
            {
                using (SELECT select = new SELECT())
                {
                    object result = select.ExecuteScalar(
                        "SELECT COUNT(*) FROM usuarios WHERE correo=@correo AND id<>@id;",
                        new[]
                        {
                            new SqlParameter("@correo", usuario.Correo),
                            new SqlParameter("@id", usuario.Id)
                        });

                    if (Convert.ToInt32(result) > 0)
                    {
                        MessageBox.Show("Ese correo ya existe en otro usuario.");
                        return;
                    }
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        @"UPDATE usuarios 
                          SET nombre=@nombre,
                              apellido=@apellido,
                              correo=@correo,
                              rango=@rango,
                              activo=@activo
                          WHERE id=@id",
                        new[]
                        {
                            new SqlParameter("@nombre", usuario.Nombre),
                            new SqlParameter("@apellido", usuario.Apellido),
                            new SqlParameter("@correo", usuario.Correo),
                            new SqlParameter("@rango", usuario.Rango),
                            new SqlParameter("@activo", usuario.Activo),
                            new SqlParameter("@id", usuario.Id)
                        });
                }

                MessageBox.Show("Cambios guardados.");
                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnAsignarAlumnos_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                using (INSERT insert = new INSERT())
                {
                    insert.ExecuteInsert(
                        "INSERT INTO alumnos (usuario_id) VALUES (@id);",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo='Alumno' WHERE id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAsignarMaestro_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                using (INSERT insert = new INSERT())
                {
                    insert.ExecuteInsert(
                        "INSERT INTO maestros (usuario_id) VALUES (@id);",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo='Maestro' WHERE id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAsignarAdmin_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo='Admin' WHERE id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado == "pendiente")
            {
                MessageBox.Show("Ya es pendiente.");
                return;
            }

            try
            {
                if (usuario.Estado == "Alumno")
                {
                    using (DELETE delete = new DELETE())
                    {
                        delete.ExecuteDelete(
                            "DELETE FROM alumnos WHERE usuario_id=@id;",
                            new[] { new SqlParameter("@id", usuario.Id) });
                    }
                }
                else if (usuario.Estado == "Maestro")
                {
                    using (DELETE delete = new DELETE())
                    {
                        delete.ExecuteDelete(
                            "DELETE FROM maestros WHERE usuario_id=@id;",
                            new[] { new SqlParameter("@id", usuario.Id) });
                    }
                }

                using (UPDATE update = new UPDATE())
                {
                    update.ExecuteUpdate(
                        "UPDATE usuarios SET tipo=NULL WHERE id=@id;",
                        new[] { new SqlParameter("@id", usuario.Id) });
                }

                CargarUsuariosGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DgvGeneralAdd Principal = new DgvGeneralAdd();
            Principal.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) => EliminarDato();

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuariosCount();
            CargarUsuariosGeneral();
        }
    }
}