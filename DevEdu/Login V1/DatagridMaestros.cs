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
            btn_buscar.Enabled = false;
            btn_guardar.Enabled = false;

            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid.Columns.Clear();
            DataGrid.Columns.Add("ID", "ID");
            DataGrid.Columns.Add("Nombre", "Nombre");
            DataGrid.Columns.Add("Apellido", "Apellido");
            DataGrid.Columns.Add("Asignatura", "Asignatura");
        }

        //programacion modular con parametros
        private void GuardarEnArchivo(string id, string nombre, string apellido, string asignatura)
        {
            string rutaArchivo = @"C:\DevEdu\estudiantes.txt"; // se asigna el directorio en la variable

            string carpeta = System.IO.Path.GetDirectoryName(rutaArchivo); // se le asigna el nombre del directorio a la variable
            if (!System.IO.Directory.Exists(carpeta)) // verifica si el directotio no existe
            {
                System.IO.Directory.CreateDirectory(carpeta); //  en ese caso se crea
            }
            
            string linea = $"{id},{nombre},{apellido},{asignatura}"; // se guardan los datos de los parametros en la variable
            System.IO.File.AppendAllText(rutaArchivo, linea + Environment.NewLine); // se guardan los datos de la variable "linea"en el archivo
                                                                                    // luego pasa a la siguiente linea para evitar sobreescribir
        }

        //programacion modular sin parametros
        private void CargarDesdeArchivo()
        {
            string rutaArchivo = @"C:\DevEdu\estudiantes.txt";
            if (System.IO.File.Exists(rutaArchivo))
            {
                string[] lineas = System.IO.File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 4)
                    {
                        DataGrid.Rows.Add(datos[0], datos[1], datos[2], datos[3]);
                    }
                }
            }
        }

        private void ActualizarArchivo()
        {
            string rutaArchivo = @"C:\DevEdu\estudiantes.txt";
            List<string> lineas = new List<string>();

            foreach (DataGridViewRow fila in DataGrid.Rows)
            {
                if (fila.IsNewRow) continue;
                string linea = $"{fila.Cells[0].Value},{fila.Cells[1].Value},{fila.Cells[2].Value},{fila.Cells[3].Value}";
                lineas.Add(linea);
            }

            System.IO.File.WriteAllLines(rutaArchivo, lineas);
        }
        //fin programacion modular

        private void DatagripMaestros_Load(object sender, EventArgs e)
        {
            CargarDesdeArchivo();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = true;
            btn_buscar.Enabled = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbox_ID.Text) ||
                string.IsNullOrWhiteSpace(txtbox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(txtbox_Apellido.Text) ||
                string.IsNullOrWhiteSpace(txtbox_Asignatura.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!int.TryParse(txtbox_ID.Text, out _))
            {
                MessageBox.Show("El ID debe ser de valor numerico.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_ID.Focus();
                return;
            }
            else if (!txtbox_Nombre.Text.All(char.IsLetter))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Nombre.Focus();
                return;
            }

            else if (!txtbox_Apellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El Apellido solo puede contener letras.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Apellido.Focus();
                return;
            }
            else
            {
                try
                {
                    GuardarEnArchivo(txtbox_ID.Text, txtbox_Nombre.Text, txtbox_Apellido.Text, txtbox_Asignatura.Text);
                    DataGrid.Rows.Add(txtbox_ID.Text, txtbox_Nombre.Text, txtbox_Apellido.Text, txtbox_Asignatura.Text);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error al guardar.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtbox_ID.Clear();
                txtbox_Nombre.Clear();
                txtbox_Apellido.Clear();
                txtbox_Asignatura.Clear();
                txtbox_ID.Focus();
            }
        }
   
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string criterio = txtbox_ID.Text.Trim();
            if (string.IsNullOrEmpty(criterio))
            {
                MessageBox.Show("Ingrese un valor para buscar.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool encontrado = false;
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Selected = true;
                        DataGrid.CurrentCell = cell;
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado) break;
            }

            if (!encontrado)
            {
                MessageBox.Show("No se encontraron resultados.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in DataGrid.SelectedRows)
                {
                    if (!fila.IsNewRow)
                    {
                        DataGrid.Rows.Remove(fila);
                    }
                }

                ActualizarArchivo();

                MessageBox.Show("Registro eliminado de la base de datos.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione al menos una fila para eliminar.", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

