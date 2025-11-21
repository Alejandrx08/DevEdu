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
    public partial class Arrays : Form
    {
        public Arrays()
        {
            InitializeComponent();
            txtbx_duracion.Enabled = false;
            txtbx_materias.Enabled = false;
            txtbx_prom.Enabled = false;
        }

        String[] Materias = new string[5];

        private void btn_materias_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_posicion_uniD.Text))
            {
                MessageBox.Show("Por favor ingrese una posicion");
                return;
            }
            if (!int.TryParse(txtbx_posicion_uniD.Text, out int posicion))
            {
                MessageBox.Show("Por favor ingrese un numero valido");
                return;
            }
            if (posicion < 0 || posicion >= Materias.Length)
            {
                MessageBox.Show("Posicion fuera de rango. Ingrese un valor entre 0 y " + (Materias.Length - 1).ToString());
            }
            else
            {
                txtbx_materias.Text = Materias[posicion];
            }
        }

        String[,] Horarios = { { "Lunes", "1 hora" }, 
                               { "Martes", "4 horas" }, 
                               { "Miercoles", "3 horas" }, 
                               { "Jueves", "Dia Libre" } };

        private void btn_duracion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_posicionbiD1.Text))
            {
                MessageBox.Show("Por favor ingrese una posicion");
                txtbx_posicionbiD1.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtbx_posicionbiD2.Text))
            {
                MessageBox.Show("Por favor ingrese una posicion");
                txtbx_posicionbiD2.Focus();
                return;
            }
            if (!int.TryParse(txtbx_posicionbiD1.Text, out int posicionbid1))
            {
                MessageBox.Show("Por favor ingrese un numero valido");
                return;
            }
            if (!int.TryParse(txtbx_posicionbiD2.Text, out int posicionbid2))
            {
                MessageBox.Show("Por favor ingrese un numero valido");
                return;
            }
            if (posicionbid1 < 0 || posicionbid1 >= Horarios.Length)
            {
                MessageBox.Show("Posicion fuera de rango. Ingrese un valor entre 0 y " + (Horarios.Length - 1).ToString());
            }
            if (posicionbid2 < 0 || posicionbid2 >= 2)
            {
                MessageBox.Show("Posicion fuera de rango. Ingrese un valor entre 0 y 1");
            }
            else
            {
                txtbx_duracion.Text = Horarios[posicionbid1,posicionbid2];
            }
        }
        private void btn_promedio_Click(object sender, EventArgs e)
        {
           double.TryParse(txtbx_clase1.Text, out double nota1);
           double.TryParse(txtbx_clase2.Text, out double nota2);
           if (nota1 < 0 || nota1 > 5)
           {
               MessageBox.Show("Ingrese una nota valida entre 0 y 5");
               return;
           }
           if (nota2 < 0 || nota2 > 5)
           {
               MessageBox.Show("Ingrese una nota valida entre 0 y 5");
               return;
           }
           if (string.IsNullOrWhiteSpace(txtbx_clase1.Text))
            {
                MessageBox.Show("Por favor ingrese una nota");
                txtbx_clase1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtbx_clase2.Text))
            {
                MessageBox.Show("Por favor ingrese una nota");
                txtbx_clase2.Focus();
                return;
            }
            if (!double.TryParse(txtbx_clase1.Text, out nota1))
            {
                MessageBox.Show("Por favor ingrese un numero valido");
                return;
            }
            if (!double.TryParse(txtbx_clase2.Text, out nota2))
            {
                MessageBox.Show("Por favor ingrese un numero valido");
                return;
            }
            double promedio = (nota1 + nota2) / 2;
            txtbx_prom.Text = promedio.ToString();
        }

        private void btn_ordenar_Click(object sender, EventArgs e)
        {
            Array.Sort(Materias);
            MessageBox.Show("Materias ordenadas alfabéticamente.");
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string diaBuscado = txtbx_dia.Text; 

            if (string.IsNullOrWhiteSpace(diaBuscado))
            {
                MessageBox.Show("Ingrese un día para buscar.");
                return;
            }

            bool encontrado = false;

            for (int i = 0; i < Horarios.GetLength(0); i++)
            {
                if (Horarios[i, 0].Equals(diaBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Día encontrado:\n{Horarios[i, 0]} - {Horarios[i, 1]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                MessageBox.Show("Horario no encontrado para ese día.");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_agg.Text))
            {
                MessageBox.Show("Por favor ingrese una materia");
                txtbx_agg.Focus();
                return;
            }
            else 
            {
                for (int i = 0; i < Materias.Length; i++)
                {
                    if (string.IsNullOrEmpty(Materias[i]))
                    {
                        Materias[i] = txtbx_agg.Text;
                        MessageBox.Show("Materia agregada en la posicion " + i.ToString());
                        txtbx_agg.Clear();
                        return;
                    }
                }
                MessageBox.Show("No hay espacio dentro del arreglo para agregar más materias.");
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMainMenu Principal = new FrmMainMenu();
            Principal.ShowDialog();
            this.Close();
        }
    }
}