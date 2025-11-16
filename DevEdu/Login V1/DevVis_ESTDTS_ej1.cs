using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login_V1
{
    public partial class DevVis_ESTDTS_ej1 : Form
    {
        private Timer timer;
        private int Actual = 0;

        public Color colorr { get; private set; }

        public DevVis_ESTDTS_ej1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

            txtbx_valor.Focus();
            txtbx1.ReadOnly = true;
            txtbx2.ReadOnly = true;
            txtbx3.ReadOnly = true;
            txtbx4.ReadOnly = true;  
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            string valor = txtbx_valor.Text;

            if (string.IsNullOrEmpty(txtbx_valor.Text) && (!string.IsNullOrEmpty(txtbx_indice.Text)))
            {
                MessageBox.Show("complete el campo Valor", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbx_valor.Focus();
            }
            else if (!string.IsNullOrEmpty(txtbx_valor.Text) && (string.IsNullOrEmpty(txtbx_indice.Text)))
            {
                MessageBox.Show("complete el campo Indice", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbx_valor.Focus();
            }
            else if (int.TryParse(txtbx_indice.Text, out int indice))
            {
                if (indice > 3)
                {
                    MessageBox.Show("El número no puede ser mayor que la cantidad de nodos", "DevEdu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (indice == 0)
                    {
                        txtbx1.Text = valor;
                    }
                    else if (indice == 1)
                    {
                        txtbx2.Text = valor;
                    }
                    else if (indice == 2)
                    {
                        txtbx3.Text = valor;
                    }
                    else if (indice == 3)
                    {
                        txtbx4.Text = valor;
                    }
                }
            }
        }

        private void btn_recorrer_Click(object sender, EventArgs e)
        {
            Actual = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btn_recorrer.Enabled = false;
            colorr = btn_color.BackColor;

            if (Actual == 0)
            {
                txtbx1.BackColor = colorr;
                txtbx1.ForeColor = Color.White;
            }
            else if (Actual == 1)
            {
                flecha1.ForeColor = colorr;
                txtbx1.BackColor = Color.White;
                txtbx1.ForeColor = Color.Black;
            }
            else if (Actual == 2)
            {
                txtbx2.BackColor = colorr;
                txtbx2.ForeColor = Color.White;
                flecha1.ForeColor = Color.White;
            }
            else if (Actual == 3)
            {
                flecha2.ForeColor = colorr;
                txtbx2.BackColor = Color.White;
                txtbx2.ForeColor = Color.Black;
            }
            else if (Actual == 4)
            {
                txtbx3.BackColor = colorr;
                txtbx3.ForeColor = Color.White;
                flecha2.ForeColor = Color.White;
            }
            else if (Actual == 5)
            {
                flecha3.ForeColor = colorr;
                txtbx3.BackColor = Color.White;
                txtbx3.ForeColor = Color.Black;
            }
            else if (Actual == 6)
            {
                txtbx4.BackColor = colorr;
                txtbx4.ForeColor = Color.White;
                flecha3.ForeColor = Color.White;
            }
            else if (Actual == 7)
            { 
                txtbx4.BackColor = Color.White;
                txtbx4.ForeColor = Color.Black;
            }

            Actual++;

            if (Actual > 7)
            {
                timer.Stop();
                btn_recorrer.Enabled = true;
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevVisMenu Principal = new DevVisMenu();
            Principal.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtbx1.Text = "A";
            txtbx2.Text = "B";
            txtbx3.Text = "C";
            txtbx4.Text = "D";
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            if (btn_color.BackColor == Color.Green)
            {
                btn_color.BackColor = Color.Red;
                btn_color.Text = "Rojo";
                colorr = Color.Red;
            }

            else if (btn_color.BackColor == Color.Red)
            {
                btn_color.BackColor = Color.Green;
                btn_color.Text = "verde";
                colorr = Color.Green;
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevVis_ESTDTS_ej2 Principal = new DevVis_ESTDTS_ej2();
            Principal.ShowDialog();
            this.Close();
        }
    }
}