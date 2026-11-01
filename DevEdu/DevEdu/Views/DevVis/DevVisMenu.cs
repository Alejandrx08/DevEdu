using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DevVisMenu : Form
    {
        public DevVisMenu()
        {
            InitializeComponent();
            ConfigurarApariencia();
        }

        private void ConfigurarApariencia()
        {
            Color navy = Color.FromArgb(0, 31, 84);
            Color blue = Color.FromArgb(37, 99, 235);
            Color ink = Color.FromArgb(31, 41, 55);
            Color muted = Color.FromArgb(100, 116, 139);
            Color canvas = Color.FromArgb(245, 247, 251);
            Color pale = Color.FromArgb(226, 235, 248);

            Text = "DevVis | Laboratorio visual";
            ClientSize = new Size(1100, 760);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = canvas;
            StartPosition = FormStartPosition.CenterScreen;

            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = new Size(1100, 98);
            pictureBox1.BackColor = navy;

            label1.Text = "DevVis";
            label1.Location = new Point(42, 12);
            label1.Size = new Size(190, 46);
            label1.Font = new Font("Segoe UI Semibold", 25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.BackColor = navy;

            label2.Visible = true;
            label2.Text = "LABORATORIO DE PROGRAMACIÓN VISUAL";
            label2.Location = new Point(46, 60);
            label2.Size = new Size(420, 22);
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(191, 219, 254);
            label2.BackColor = navy;
            label2.TextAlign = ContentAlignment.MiddleLeft;

            button3.Text = "←  Menú principal";
            button3.Location = new Point(914, 26);
            button3.Size = new Size(150, 44);
            button3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            button3.BackColor = Color.FromArgb(20, 52, 101);
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 74, 130);
            button3.Cursor = Cursors.Hand;

            label3.Visible = true;
            label3.Location = new Point(778, 350);
            label3.Size = new Size(220, 126);
            label3.Text = "Explora cómo se conectan y organizan los datos en listas y árboles interactivos.";
            label3.Font = new Font("Segoe UI", 10.5F);
            label3.ForeColor = ink;
            label3.BackColor = Color.White;
            label3.TextAlign = ContentAlignment.MiddleLeft;

            label4.Visible = true;
            label4.Location = new Point(282, 350);
            label4.Size = new Size(220, 126);
            label4.Text = "Observa cómo un ciclo repite instrucciones y transforma los valores en cada iteración.";
            label4.Font = new Font("Segoe UI", 10.5F);
            label4.ForeColor = ink;
            label4.BackColor = Color.White;
            label4.TextAlign = ContentAlignment.MiddleLeft;

            label5.Text = "Explora dos experiencias interactivas y descubre qué ocurre paso a paso.";
            label5.Location = new Point(72, 179);
            label5.Size = new Size(950, 28);
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = muted;
            label5.BackColor = canvas;

            CrearEtiqueta("Aprende viendo cómo se ejecuta", new Point(70, 128), new Size(950, 42), 25F, navy, canvas, true, ContentAlignment.MiddleLeft);

            pictureBox5.Visible = true;
            pictureBox5.Location = new Point(68, 242);
            pictureBox5.Size = new Size(468, 408);
            pictureBox5.BackColor = Color.White;
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.SendToBack();

            pictureBox6.Visible = true;
            pictureBox6.Location = new Point(564, 242);
            pictureBox6.Size = new Size(468, 408);
            pictureBox6.BackColor = Color.White;
            pictureBox6.BorderStyle = BorderStyle.FixedSingle;
            pictureBox6.SendToBack();

            CrearEtiqueta("01", new Point(98, 266), new Size(48, 42), 14F, blue, pale, true, ContentAlignment.MiddleCenter);
            CrearEtiqueta("Bucles", new Point(160, 266), new Size(320, 42), 19F, navy, Color.White, true, ContentAlignment.MiddleLeft);
            CrearEtiqueta("02", new Point(594, 266), new Size(48, 42), 14F, blue, pale, true, ContentAlignment.MiddleCenter);
            CrearEtiqueta("Estructuras de datos", new Point(656, 266), new Size(340, 42), 19F, navy, Color.White, true, ContentAlignment.MiddleLeft);

            picbx_bucles.Location = new Point(108, 336);
            picbx_bucles.Size = new Size(156, 142);
            picbx_bucles.BackColor = Color.White;
            picbx_bucles.Cursor = Cursors.Hand;

            picbx_EstDts.Location = new Point(574, 336);
            picbx_EstDts.Size = new Size(156, 142);
            picbx_EstDts.BackColor = Color.White;
            picbx_EstDts.Cursor = Cursors.Hand;

            btn_bucles.Text = "Explorar bucles  →";
            btn_bucles.Location = new Point(98, 558);
            btn_bucles.Size = new Size(408, 54);
            btn_bucles.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btn_bucles.TextAlign = ContentAlignment.MiddleCenter;
            btn_bucles.BackColor = navy;
            btn_bucles.ForeColor = Color.White;
            btn_bucles.FlatStyle = FlatStyle.Flat;
            btn_bucles.FlatAppearance.BorderSize = 0;
            btn_bucles.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 52, 101);
            btn_bucles.Cursor = Cursors.Hand;

            btn_estructurasDTS.Text = "Explorar estructuras  →";
            btn_estructurasDTS.Location = new Point(594, 558);
            btn_estructurasDTS.Size = new Size(408, 54);
            btn_estructurasDTS.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btn_estructurasDTS.TextAlign = ContentAlignment.MiddleCenter;
            btn_estructurasDTS.BackColor = navy;
            btn_estructurasDTS.ForeColor = Color.White;
            btn_estructurasDTS.FlatStyle = FlatStyle.Flat;
            btn_estructurasDTS.FlatAppearance.BorderSize = 0;
            btn_estructurasDTS.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 52, 101);
            btn_estructurasDTS.Cursor = Cursors.Hand;

            label2.BringToFront();
            label1.BringToFront();
            button3.BringToFront();
            label4.BringToFront();
            label3.BringToFront();
            picbx_bucles.BringToFront();
            picbx_EstDts.BringToFront();
            btn_bucles.BringToFront();
            btn_estructurasDTS.BringToFront();
            CrearEtiqueta("DevEdu  ·  Aprende visualizando", new Point(72, 700), new Size(950, 22), 9F, muted, canvas, false, ContentAlignment.MiddleLeft);
            label5.BringToFront();
        }

        private void CrearEtiqueta(string texto, Point posicion, Size tamanio, float tamFuente, Color frente, Color fondo, bool negrita, ContentAlignment alineacion)
        {
            var etiqueta = new Label
            {
                Text = texto,
                Location = posicion,
                Size = tamanio,
                Font = new Font(negrita ? "Segoe UI Semibold" : "Segoe UI", tamFuente, negrita ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = frente,
                BackColor = fondo,
                TextAlign = alineacion
            };
            Controls.Add(etiqueta);
            etiqueta.BringToFront();
        }
        //Programacion modular para llamar al formulario de Bucles
        private void Bucles()
        {
            Hide();
            using (var ejercicio = new DevVis_Bucles_Ej1())
                ejercicio.ShowDialog(this);
            Show();
            Activate();
        }

        private void estructurasDTS()
        {
            Hide();
            using (var ejercicio = new DevVis_ESTDTS_ej1())
                ejercicio.ShowDialog(this);
            Show();
            Activate();
        }

        private void button3_Click(object sender, EventArgs e) => Close();

        //Llamar al formulario de Bucles
        private void btn_bucles_Click(object sender, EventArgs e)
        {
            Bucles();
        }

        private void picbx_bucles_Click(object sender, EventArgs e)
        {
            Bucles();
        }
        private void btn_estructurasDTS_Click(object sender, EventArgs e)
        {
            estructurasDTS();
        }
        private void picbx_EstDts_Click(object sender, EventArgs e)
        {
            estructurasDTS();
        }
        private void DevVisMenu_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btn_DevTrivia_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
