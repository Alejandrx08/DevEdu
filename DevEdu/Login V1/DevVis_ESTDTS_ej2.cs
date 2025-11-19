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

namespace Login_V1
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
            flecha1.ForeColor = Color.White;
            flecha2.ForeColor = Color.White;
            flecha3.ForeColor = Color.White;
            flecha4.ForeColor = Color.White;
            flecha5.ForeColor = Color.White;
            flecha6.ForeColor = Color.White;
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



        private void bx1_Click(object sender, EventArgs e) // cuando se le da click
        {
            if (bx1.ForeColor == Color.Black)
            {
                Colorr();
                bx1C();
                txtbx_slctnodo.Text = bx1.Text; // el texto de select nodo va a ser igual al texto de bx1 
                indice = 1;

            }
            else
            {
                clear();
                Colorr();
                indice = 0;
            }
        }
        private void bx2_Click(object sender, EventArgs e)
        {
            if (bx2.ForeColor == Color.Black)
            {
                Colorr();
                bx2.ForeColor = Color.White;
                bx2.BackColor = Color.Green;
                bx1C();
                flecha1.ForeColor = Color.Green;
                txtbx_slctnodo.Text = bx2.Text;
                indice = 2;
            }
            else
            {
                clear();
                Colorr(); 
                indice = 0;
            }
        }
        private void bx3_Click(object sender, EventArgs e)
        {
            if (bx3.ForeColor == Color.Black)
            {
                Colorr();
                bx3.ForeColor = Color.White;
                bx3.BackColor = Color.Green;
                bx1C();
                flecha1.ForeColor = Color.Green;
                flecha2.ForeColor = Color.Green;
                txtbx_slctnodo.Text = bx3.Text;
                indice = 3;

            }
            else
            {
                clear();
                Colorr();
                indice = 0;
            }
        }
        private void bx4_Click(object sender, EventArgs e)
        {
            if (bx4.ForeColor == Color.Black)
            {
                Colorr();
                bx4.ForeColor = Color.White;
                bx4.BackColor = Color.Green;
                bx1C();
                bx2.ForeColor = Color.White;
                bx2.BackColor = Color.Green;
                flecha1.ForeColor= Color.Green;
                flecha3.ForeColor = Color.Green;
                txtbx_slctnodo.Text = bx4.Text;
                indice = 4;
            }
            else
            {
                clear();
                Colorr();
                indice = 0;
            }
        }
        private void bx5_Click(object sender, EventArgs e)
        {
            if (bx5.ForeColor == Color.Black)
            {
                Colorr();
                bx5.ForeColor = Color.White;
                bx5.BackColor = Color.Green;
                flecha4.ForeColor = Color.Green;
                flecha3.ForeColor = Color.Green;
                bx2.ForeColor = Color.White;
                bx2.BackColor = Color.Green;
                flecha1.ForeColor = Color.Green;
                bx1C();
                txtbx_slctnodo.Text = bx5.Text;
                indice = 5;

            }
            else
            {
                clear();
                Colorr();
                indice = 0;
            }
        }
        private void bx6_Click(object sender, EventArgs e)
        {
            if (bx6.ForeColor == Color.Black)
            {
                Colorr();
                bx6.ForeColor = Color.White;
                bx6.BackColor = Color.Green;
                flecha5.ForeColor = Color.Green;
                bx3.ForeColor = Color.White;
                bx3.BackColor = Color.Green;
                flecha2.ForeColor = Color.Green;
                flecha1.ForeColor = Color.Green;    
                bx1C();
                txtbx_slctnodo.Text = bx6.Text;
                indice = 6;
            }
            else
            {
                clear();
                Colorr();
                indice = 0;
            }
        }

        private void bx7_Click(object sender, EventArgs e)
        {

            if (bx7.ForeColor == Color.Black)
            {
                Colorr();
                bx7.ForeColor = Color.White;
                bx7.BackColor = Color.Green;
                flecha6.ForeColor = Color.Green;
                bx5.ForeColor = Color.White;
                bx5.BackColor = Color.Green;
                flecha4.ForeColor = Color.Green;
                flecha3.ForeColor = Color.Green;
                bx2.ForeColor = Color.White;
                bx2.BackColor = Color.Green;
                flecha1.ForeColor = Color.Green;
                bx1C();
                txtbx_slctnodo.Text = bx7.Text;
                indice = 7;
            }
            else
            {   
                clear();
                Colorr();
                indice = 0;
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevVisMenu Principal = new DevVisMenu();
            Principal.ShowDialog();
            this.Close();
        }

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
