using MySql.Data.MySqlClient;
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

namespace Login_V1
{
    public partial class DataGridGeneral : Form
    {
        public DataGridGeneral()
        {
            InitializeComponent();
        }
        private string conx = "Server=localhost;Database=baseusuarios;Uid=root;password=123456;";

        private void DataDridGeneral_Load(object sender, EventArgs e)
        {
            if (Sesion.Rango != "SuperSU")
            {
             MessageBox.Show("Acceso denegado.");
             Close();
             return;
            }

            DgvGeneral.EnableHeadersVisualStyles = false;

            UsuariosCount();

            CargarUsuariosGeneral();
        }

        private DataTable dtUsuarios;

        private void UsuariosCount()
        {
            using (MySqlConnection conn = new MySqlConnection(conx))
            {
                conn.Open();

                using (MySqlCommand checkCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM usuarios;", conn))
                {

                    long existe = (long)checkCmd.ExecuteScalar();
                    txtCount.Text = $"Usuarios: " + existe.ToString();
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
                      IFNULL(u.tipo, 'pendiente') AS estado,
                      u.activo
                   FROM usuarios u;";

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var da = new MySqlDataAdapter(query, conn))
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

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);

            var r = MessageBox.Show(
                $"¿Deseas ELIMINAR el usuario con ID {id}?\n\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new MySqlCommand("DELETE FROM alumnos WHERE usuario_id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }

                        using (var cmd = new MySqlCommand("DELETE FROM maestros WHERE usuario_id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }

                        int filas;
                        using (var cmd = new MySqlCommand("DELETE FROM usuarios WHERE id=@id;", conn, tx))
                        { cmd.Parameters.AddWithValue("@id", id); filas = cmd.ExecuteNonQuery(); }

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

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);

            string nombre = DgvGeneral.CurrentRow.Cells["nombre"].Value?.ToString() ?? "";
            string apellido = DgvGeneral.CurrentRow.Cells["apellido"].Value?.ToString() ?? "";
            string correo = DgvGeneral.CurrentRow.Cells["correo"].Value?.ToString() ?? "";
            string rango = DgvGeneral.CurrentRow.Cells["rango"].Value?.ToString() ?? "";
            int activo = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["activo"].Value ?? 0);

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();

                using (var check = new MySqlCommand(
                    "SELECT COUNT(*) FROM usuarios WHERE correo=@correo AND id<>@id;", conn))
                {
                    check.Parameters.AddWithValue("@correo", correo);
                    check.Parameters.AddWithValue("@id", id);
                    long existe = (long)check.ExecuteScalar();
                    if (existe > 0)
                    {
                        MessageBox.Show("Ese correo ya existe en otro usuario.");
                        return;
                    }
                }

                string query = @"UPDATE usuarios 
                       SET nombre=@nombre, apellido=@apellido, correo=@correo, rango=@rango, activo=@activo
                       WHERE id=@id;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@rango", rango);
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cambios guardados.");
            CargarUsuariosGeneral();
        }

        private void btnAsignarAlumnos_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);
            string estado = DgvGeneral.CurrentRow.Cells["estado"].Value.ToString();

            if (estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + estado);
                return;
            }

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd1 = new MySqlCommand(
                            "INSERT INTO alumnos (usuario_id) VALUES (@id);", conn, tx))
                        {
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();
                        }

                        using (var cmd2 = new MySqlCommand(
                            "UPDATE usuarios SET tipo='Alumno' WHERE id=@id;", conn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();
                        }

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

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);
            string estado = DgvGeneral.CurrentRow.Cells["estado"].Value.ToString();

            if (estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + estado);
                return;
            }

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd1 = new MySqlCommand(
                            "INSERT INTO maestros (usuario_id) VALUES (@id);", conn, tx))
                        {
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();
                        }

                        using (var cmd2 = new MySqlCommand(
                            "UPDATE usuarios SET tipo='Maestro' WHERE id=@id;", conn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();
                        }

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

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);
            string estado = DgvGeneral.CurrentRow.Cells["estado"].Value.ToString();

            if (estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + estado);
                return;
            }

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new MySqlCommand(
                            "UPDATE usuarios SET tipo='Admin' WHERE id=@id;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

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

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);
            string estado = DgvGeneral.CurrentRow.Cells["estado"].Value.ToString();

            if (estado == "pendiente")
            {
                MessageBox.Show("Ya es pendiente.");
                return;
            }

            using (var conn = new MySqlConnection(conx))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        if (estado == "Alumno")
                        {
                            using (var cmd = new MySqlCommand(
                                "DELETE FROM alumnos WHERE usuario_id=@id;", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (estado == "Maestro")
                        {
                            using (var cmd = new MySqlCommand(
                                "DELETE FROM maestros WHERE usuario_id=@id;", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        using (var cmd2 = new MySqlCommand(
                            "UPDATE usuarios SET tipo=NULL WHERE id=@id;", conn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();
                        }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EliminarDato();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuariosCount();
            CargarUsuariosGeneral();
        }
    }
}