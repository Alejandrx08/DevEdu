using DevEdu.Core.Models;
using DevEdu.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DataGridGeneral : Form
    {
        public DataGridGeneral()
        {
            InitializeComponent();
        }

        ConexionDB db = new ConexionDB();

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
            using (SqlConnection conn = db.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM usuarios;", conn))
                {
                    int existe = Convert.ToInt32(checkCmd.ExecuteScalar());
                    txtCount.Text = "Usuarios: " + existe.ToString();
                }
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var da = new SqlDataAdapter(query, conn))
                {
                    dtUsuarios = new DataTable();
                    da.Fill(dtUsuarios);
                    DgvGeneral.DataSource = dtUsuarios;
                }
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand("DELETE FROM alumnos WHERE usuario_id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", usuario.Id); cmd.ExecuteNonQuery(); }

                        using (var cmd = new SqlCommand("DELETE FROM maestros WHERE usuario_id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", usuario.Id); cmd.ExecuteNonQuery(); }

                        int filas;
                        using (var cmd = new SqlCommand("DELETE FROM usuarios WHERE id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", usuario.Id); filas = cmd.ExecuteNonQuery(); }

                        tx.Commit();

                        if (filas > 0)
                        {
                            MessageBox.Show("Usuario eliminado con éxito.");
                            UsuariosCount();
                            CargarUsuariosGeneral();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario (posiblemente ya fue eliminado).");
                        }
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();

                using (var check = new SqlCommand(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@correo AND id<>@id;", conn))
                {
                    check.Parameters.AddWithValue("@correo", usuario.Correo);
                    check.Parameters.AddWithValue("@id", usuario.Id);

                    int existe = Convert.ToInt32(check.ExecuteScalar());
                    if (existe > 0)
                    {
                        MessageBox.Show("Ese correo ya existe en otro usuario.");
                        return;
                    }
                }

                string query = @"UPDATE usuarios 
                SET nombre=@nombre,
                    apellido=@apellido,
                    correo=@correo,
                    rango=@rango,
                    activo=@activo
                WHERE id=@id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@rango", usuario.Rango);
                    cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@id", usuario.Id);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cambios guardados.");
            CargarUsuariosGeneral();
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd1 = new SqlCommand(
                            "INSERT INTO alumnos (usuario_id) VALUES (@id);", conn, tx))
                        { cmd1.Parameters.AddWithValue("@id", usuario.Id); cmd1.ExecuteNonQuery(); }

                        using (var cmd2 = new SqlCommand(
                            "UPDATE usuarios SET tipo='Alumno' WHERE id=@id;", conn, tx))
                        { cmd2.Parameters.AddWithValue("@id", usuario.Id); cmd2.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }

            CargarUsuariosGeneral();
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd1 = new SqlCommand(
                            "INSERT INTO maestros (usuario_id) VALUES (@id);", conn, tx))
                        { cmd1.Parameters.AddWithValue("@id", usuario.Id); cmd1.ExecuteNonQuery(); }

                        using (var cmd2 = new SqlCommand(
                            "UPDATE usuarios SET tipo='Maestro' WHERE id=@id;", conn, tx))
                        { cmd2.Parameters.AddWithValue("@id", usuario.Id); cmd2.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }

            CargarUsuariosGeneral();
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "UPDATE usuarios SET tipo='Admin' WHERE id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", usuario.Id); cmd.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }

            CargarUsuariosGeneral();
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

            using (var conn = db.ObtenerConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        if (usuario.Estado == "Alumno")
                        {
                            using (var cmd = new SqlCommand(
                                "DELETE FROM alumnos WHERE usuario_id=@id;", conn, tx))
                            { cmd.Parameters.AddWithValue("@id", usuario.Id); cmd.ExecuteNonQuery(); }
                        }
                        else if (usuario.Estado == "Maestro")
                        {
                            using (var cmd = new SqlCommand(
                                "DELETE FROM maestros WHERE usuario_id=@id;", conn, tx))
                            { cmd.Parameters.AddWithValue("@id", usuario.Id); cmd.ExecuteNonQuery(); }
                        }

                        using (var cmd2 = new SqlCommand(
                            "UPDATE usuarios SET tipo=NULL WHERE id=@id;", conn, tx))
                        { cmd2.Parameters.AddWithValue("@id", usuario.Id); cmd2.ExecuteNonQuery(); }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }

            CargarUsuariosGeneral();
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
