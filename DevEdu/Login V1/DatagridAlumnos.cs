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
using static Login_V1.DatagridAlumnos;

namespace Login_V1
{
    public partial class DatagridAlumnos : Form
    {
        public DatagridAlumnos()
        {
            InitializeComponent();

            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAlumnos.Columns.Add("Primer Nombre", "Primer Nombre");
            dataGridViewAlumnos.Columns.Add("Segundo Nombre", "Segundo Nombre");
            dataGridViewAlumnos.Columns.Add("Correo", "Correo");
            dataGridViewAlumnos.Rows.Clear();
        }

        public struct Alumnos   
        {
            public int ID;
            public string Nombre;
            public string Apellido;
        }

        List<Alumnos> listaAlumnos = new List<Alumnos>();

        private void btnagg_Click(object sender, EventArgs e)
        {
            if (txtbx_ID.Text == "" || txtbx_Nombre.Text == "" || txtbx_Apellido.Text == "")
            {
                MessageBox.Show("Complete todos los campos.");
            }
            else if (!int.TryParse(txtbx_ID.Text, out int X))
            {
                MessageBox.Show("El Id solo puede contener numeros.");
            }
            else if (int.TryParse(txtbx_Apellido.Text, out _) || int.TryParse(txtbx_Nombre.Text, out _))
            {
                MessageBox.Show("El nombre no puede contener números.");
            }
            else
            {
                Alumnos Alumno;
                Alumno.ID = X;
                Alumno.Nombre = txtbx_Nombre.Text;
                Alumno.Apellido = txtbx_Apellido.Text;
                listaAlumnos.Add(Alumno);

                txtbx_ID.Clear();
                txtbx_Nombre.Clear();
                txtbx_Apellido.Clear();

                MessageBox.Show("El alumno ha sido agregado exitosamente.");
            }
        }

        private void btnview_Click_1(object sender, EventArgs e)
        {
            dataGridViewAlumnos.Rows.Clear();

            foreach (var Alumno in listaAlumnos)
            {
                dataGridViewAlumnos.Rows.Add(Alumno.ID, Alumno.Nombre, Alumno.Apellido);
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewAlumnos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in dataGridViewAlumnos.SelectedRows)
                {
                    int ix = fila.Index;

                    if (ix >= 0 && ix < listaAlumnos.Count)
                    {
                        listaAlumnos.RemoveAt(ix);
                        dataGridViewAlumnos.Rows.RemoveAt(ix);
                    }
                }

                MessageBox.Show("fila eliminada correctamente");
            }
            else
            {
                MessageBox.Show("Seleccione al menos una fila para eliminar");
            }
        }
    }
}
