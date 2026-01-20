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

                    string query = "SELECT * FROM ALUMNOS";
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



        private void btnview_Click_1(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnagg_Click(object sender, EventArgs e)
        {
            if (!txtbx_Nombre.Text.All(char.IsLetter))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbx_Nombre.Focus();
                return;
            }

            else if (!txtbx_Apellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El Apellido solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbx_Apellido.Focus();
                return;
            }
            else
            {
                AgregarDato();
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (txtbx_ID.Text == "")
            {
                MessageBox.Show("El ID no puede estar vacio");
                return;
            }
            else if (!txtbx_ID.Text.All(char.IsDigit))
            {
                MessageBox.Show("El ID solo puede contener numeros.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbx_ID.Focus();
                return;
            }
            else
            {
                EliminarDato();
            }
        }
    }
}
