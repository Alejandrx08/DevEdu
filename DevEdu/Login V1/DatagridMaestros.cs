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
    public partial class DatagridMaestros : Form
    {
        public DatagridMaestros()
        {
            InitializeComponent();
            CargarDatos();
        }

        string conexion = "server=localhost;database=basemaestros;user=root;password=123456;";

        private void CargarDatos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ID, Nombre, Apellido, Asignatura FROM Maestros";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataGrid.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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
            else if (txtbox_Asignatura.Text == "")
            {
                MessageBox.Show("El campo 'Asignatura' no puede estar vacio");
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

        private void LimpiarCampos()
        {
            txtbox_Nombre.Clear();
            txtbox_Apellido.Clear();
            txtbox_ID.Clear();
            txtbox_Asignatura.Clear();
        }

        private void AgregarDato()
        {
            using (MySqlConnection conx = new MySqlConnection(conexion))
            {
                try
                {
                    conx.Open();

                    string query = @"INSERT INTO maestros (nombre, apellido, asignatura)
                             VALUES (@nombre, @apellido,@asignatura)";

                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@nombre", txtbox_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtbox_Apellido.Text);
                    cmd.Parameters.AddWithValue("@asignatura", txtbox_Asignatura.Text);

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

                    string query = "DELETE FROM MAESTROS WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@id", txtbox_ID.Text);

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

                    string query = @"Update maestros
                                    set nombre=@nombre, apellido=@apellido, asignatura=@asignatura
                                    where ID=@id;";

                    MySqlCommand cmd = new MySqlCommand(query, conx);
                    cmd.Parameters.AddWithValue("@id", txtbox_ID.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtbox_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtbox_Apellido.Text);
                    cmd.Parameters.AddWithValue("@asignatura", txtbox_Asignatura.Text);

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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (VALIDACIONES()) 
            { 
                AgregarDato();
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (ValidarID() && VALIDACIONES())
            {
                EditarDatos();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (ValidarID())
            {
                EliminarDato();
            }
        }

        private void btn_Mostrar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtbox_ID.Text = DataGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtbox_Nombre.Text = DataGrid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtbox_Apellido.Text = DataGrid.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtbox_Asignatura.Text = DataGrid.Rows[e.RowIndex].Cells["Asignatura"].Value.ToString();
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void DatagripMaestros_Load(object sender, EventArgs e)
        {
        }
    }
}

