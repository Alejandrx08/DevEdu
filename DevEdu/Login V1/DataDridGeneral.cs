using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_V1
{
    public partial class DataDridGeneral : Form
    {
        public DataDridGeneral()
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

            CargarUsuariosGeneral();
        }

        private string conx = "Server=localhost;Database=baseusuarios;Uid=root;password=123456;";
        private DataTable dtUsuarios;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            int id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value);
            string nombre = DgvGeneral.CurrentRow.Cells["nombre"].Value.ToString();
            string apellido = DgvGeneral.CurrentRow.Cells["apellido"].Value.ToString();
            string correo = DgvGeneral.CurrentRow.Cells["correo"].Value.ToString();
            string rango = DgvGeneral.CurrentRow.Cells["rango"].Value.ToString();
            int activo = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["activo"].Value);

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
                            "UPDATE usuarios SET tipo='alumno' WHERE id=@id;", conn, tx))
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
                            "UPDATE usuarios SET tipo='maestro' WHERE id=@id;", conn, tx))
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
                        if (estado == "alumno")
                        {
                            using (var cmd = new MySqlCommand(
                                "DELETE FROM alumnos WHERE usuario_id=@id;", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (estado == "maestro")
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
    }
}