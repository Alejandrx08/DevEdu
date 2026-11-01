using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevVis_ESTDTS_ej2 : Form
    {
        public DevVis_ESTDTS_ej2()
        {
            InitializeComponent();
            txtbx_slctnodo.Enabled = false; // se desactiva el texbox select  nodo
        }

        int indice; 

        private void Colorr() //cambia el color de la flecha y el texto al original
        {
            bx1.ForeColor = Color.Black;
            bx1.BackColor = Color.White;
            bx2.ForeColor = Color.Black;
            bx2.BackColor = Color.White;
            bx3.ForeColor = Color.Black;
            bx3.BackColor = Color.White;
            bx4.ForeColor = Color.Black;
            bx4.BackColor = Color.White;
            bx5.ForeColor = Color.Black;
            bx5.BackColor = Color.White;
            bx6.ForeColor = Color.Black;
            bx6.BackColor = Color.White;
            bx7.ForeColor = Color.Black;
            bx7.BackColor = Color.White;
            flecha1.ForeColor = Color.FromArgb(100, 116, 139);
            flecha2.ForeColor = Color.FromArgb(100, 116, 139);
            flecha3.ForeColor = Color.FromArgb(100, 116, 139);
            flecha4.ForeColor = Color.FromArgb(100, 116, 139);
            flecha5.ForeColor = Color.FromArgb(100, 116, 139);
            flecha6.ForeColor = Color.FromArgb(100, 116, 139);
        }
        private void bx1C()
        {
            bx1.ForeColor = Color.White;
            bx1.BackColor = Color.Green;
        }

        private void clear()
        {
            txtbx_slctnodo.Text = "";
            txtbx_valornodo.Text = "";
        }

        private void SeleccionarNodo(int nodo)
        {
            Button[] nodos = { bx1, bx2, bx3, bx4, bx5, bx6, bx7 };
            Label[] aristas = { flecha1, flecha2, flecha3, flecha4, flecha5, flecha6 };
            bool cancelar = indice == nodo;
            Colorr(); clear(); indice = 0;
            if (cancelar) return;

            int[][] rutasNodos =
            {
                new[] { 1 },
                new[] { 1, 2 },
                new[] { 1, 3 },
                new[] { 1, 2, 4 },
                new[] { 1, 2, 5 },
                new[] { 1, 3, 6 },
                new[] { 1, 3, 7 }
            };
            int[][] rutasAristas =
            {
                Array.Empty<int>(),
                new[] { 1 }, new[] { 2 },
                new[] { 1, 3 }, new[] { 1, 4 },
                new[] { 2, 5 }, new[] { 2, 6 }
            };

            foreach (int numero in rutasNodos[nodo - 1])
            {
                nodos[numero - 1].BackColor = Color.FromArgb(0, 128, 0);
                nodos[numero - 1].ForeColor = Color.White;
            }
            foreach (int numero in rutasAristas[nodo - 1])
                aristas[numero - 1].ForeColor = Color.FromArgb(0, 128, 0);

            txtbx_slctnodo.Text = nodos[nodo - 1].Text;
            indice = nodo;
        }
        private void bx1_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(1);
        }

        private void bx2_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(2);
        }

        private void bx3_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(3);
        }

        private void bx4_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(4);
        }

        private void bx5_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(5);
        }

        private void bx6_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(6);
        }

        private void bx7_Click(object sender, EventArgs e)
        {
            SeleccionarNodo(7);
        }

        private void btn_return_Click(object sender, EventArgs e) => Close();

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtbx_valornodo.Text)) // se ejecuta un if else de todos los casos posibles siendo el primero una validacion.
            {
                MessageBox.Show("Complete el campo Valor del nodo", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbx_valornodo.Focus();
            }
            else if (indice == 1) //si es asi el
            { 
                bx1.Text = txtbx_valornodo.Text;
            }
            else if (indice == 2)
            {
                bx2.Text = txtbx_valornodo.Text;
            }
            else if (indice == 3)
            {
                bx3.Text = txtbx_valornodo.Text;
            }
            else if (indice == 4)
            {
                bx4.Text = txtbx_valornodo.Text;
            }
            else if (indice == 5)
            {
                bx5.Text = txtbx_valornodo.Text;
            }
            else if (indice == 6)
            {
                bx6.Text = txtbx_valornodo.Text;
            }
            else if (indice == 7)
            {
                bx7.Text = txtbx_valornodo.Text;
            }

            indice = 0; // independientemente del caso al final el indic, para deseleccionar cualquier nodo
            Colorr();
            clear();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            Colorr();
            bx1.Text = "A"; 
            bx2.Text = "B";
            bx3.Text = "C";
            bx4.Text = "D";
            bx5.Text = "E";
            bx6.Text = "F";
            bx7.Text = "G";
            clear();
            indice = 0; 
        }
    }
}
