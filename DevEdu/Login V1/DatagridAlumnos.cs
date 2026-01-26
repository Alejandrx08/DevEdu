using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Login_V1.DatagridAlumnos;

namespace Login_V1
{
    public partial class DatagridAlumnos : Form
    {
        public DatagridAlumnos()
        {
            InitializeComponent();
            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarDatos();
        }

        string conexion = "server=localhost;database=basealumnos;user=root;password=123456;";

        private void CargarDatos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ID, Nombre, Apellido FROM ALUMNOS";
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
        }

        private void AgregarDato()
        {
            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    string query = @"INSERT INTO alumnos (nombre, apellido)
                             VALUES (@nombre, @apellido)";

                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@nombre", txtbx_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtbx_Apellido.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dato agregado correctamente");

                    LimpiarCampos();
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void EliminarDato()
        {
            DialogResult r = MessageBox.Show(
                "deseas eliminar este registro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.No) return;

            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    string query = "DELETE FROM ALUMNOS WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@id", txtbx_ID.Text);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        MessageBox.Show("Registro eliminado");
                    else
                        MessageBox.Show("No existe ese ID");

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
            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    string query = @"Update Alumnos
                                    set nombre=@nombre, apellido=@apellido
                                    where ID=@id;";

                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@id", txtbx_ID.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtbx_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtbx_Apellido.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dato Actualizado correctamente");

                    LimpiarCampos();
                    CargarDatos();
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

        private void btnagg_Click(object sender, EventArgs e)
        {
            if (VALIDACIONES())
            {
                AgregarDato();
            }
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
            if (ValidarID() && VALIDACIONES())
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
            }
        }
    }
}