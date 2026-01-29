using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_V1
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
            permisos();
            CargarDatos();
        }

        private void permisos() {
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
        
        string conexion = "server=localhost;database=baseusuarios;user=root;password=123456;";

        private void CargarDatos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                u.id AS ID,
                                u.nombre AS Nombre,
                                u.apellido AS Apellido,
                                u.correo AS Correo,
                                u.rango AS Rango
                             FROM usuarios u
                             INNER JOIN alumnos a ON a.usuario_id = u.id
                             WHERE u.activo = 1;";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewAlumnos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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

        private bool CorreoDisponible(string correo, int idUsuario)
        {
            using (var conn = new MySqlConnection(conexion))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE correo=@c AND id<>@id;", conn))
                {
                    cmd.Parameters.AddWithValue("@c", correo);
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    long existe = (long)cmd.ExecuteScalar();
                    return existe == 0;
                }
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
                return  false;
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
                "¿Deseas quitar el rol a este usuario?","Confirmar", MessageBoxButtons.YesNo,MessageBoxIcon.Warning
            );

            if (r == DialogResult.No) return;

            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    using (var tx = conx.BeginTransaction())
                    {
                        var cmd1 = new MySqlCommand("DELETE FROM alumnos WHERE usuario_id=@id;", conx, tx);
                        cmd1.Parameters.AddWithValue("@id", txtbx_ID.Text);
                        int filas = cmd1.ExecuteNonQuery();

                        var cmd2 = new MySqlCommand("UPDATE usuarios SET tipo=NULL WHERE id=@id;", conx, tx);
                        cmd2.Parameters.AddWithValue("@id", txtbx_ID.Text);
                        cmd2.ExecuteNonQuery();

                        tx.Commit();

                        if (filas > 0) MessageBox.Show("Rol alumno removido (ahora es pendiente).");
                        else MessageBox.Show("Ese ID no está asignado como alumno.");
                    }

                    LimpiarCampos();
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void EditarDatos()
        {
            int id = int.Parse(txtbx_ID.Text);
            string nombre = txtbx_Nombre.Text.Trim();
            string apellido = txtbx_Apellido.Text.Trim();
            string correo = txtbx_Correo.Text.Trim();

            if (!ValidarCorreo()) return;

            if (!CorreoDisponible(correo, id))
            {
                MessageBox.Show("Ese correo ya está registrado en otro usuario.");
                txtbx_Correo.Focus();
                return;
            }

            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    string query = @"UPDATE usuarios
                             SET nombre=@nombre, apellido=@apellido, correo=@correo
                             WHERE id=@id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                            MessageBox.Show("Dato actualizado correctamente");
                        else
                            MessageBox.Show("No se encontró el usuario para actualizar");
                    }

                    LimpiarCampos();
                    CargarDatos();
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

        private void btnview_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (ValidarID())
            {
                EliminarDato();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidarID() && VALIDACIONES() && ValidarCorreo())
            {
                EditarDatos();
            }
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