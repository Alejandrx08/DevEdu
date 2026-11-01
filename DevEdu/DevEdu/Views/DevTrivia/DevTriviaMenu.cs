using DevEdu.UI.Forms.DevTrivia;
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
    public partial class DevTriviaMenu : Form
    {
        public DevTriviaMenu()
        {
            InitializeComponent();
            AgregarAccesoParte2();
        }


        private void AgregarAccesoParte2()
        {
            AgregarBotonParte2("JUGAR PARTE 2  →", 106, () => AbrirEjercicio(new DevTriviaFacil_2()));
            AgregarBotonParte2("JUGAR PARTE 2  →", 456, () => AbrirEjercicio(new DevTriviaMedio_2()));
            AgregarBotonParte2("JUGAR PARTE 2  →", 806, () => AbrirEjercicio(new DevTriviaDificil_2()));
        }

        private void AgregarBotonParte2(string texto, int x, Action accion)
        {
            var boton = new Button
            {
                Text = texto,
                Location = new Point(x, 600),
                Size = new Size(188, 46),
                BackColor = Color.FromArgb(226, 235, 248),
                ForeColor = Color.FromArgb(0, 31, 84),
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            boton.FlatAppearance.BorderColor = Color.FromArgb(0, 31, 84);
            boton.FlatAppearance.BorderSize = 2;
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 225, 245);
            boton.Click += (_, _) => accion();
            Controls.Add(boton);
            boton.BringToFront();
        }

        private void AbrirEjercicio(Form ejercicio)
        {
            this.Hide();
            using (ejercicio)
                ejercicio.ShowDialog(this);
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e) => Close();
        private void btn_Facil_Click(object sender, EventArgs e) => AbrirEjercicio(new DevTriviaFacil_1());
        private void btn_Medio_Click(object sender, EventArgs e) => AbrirEjercicio(new DevTriviaMedio_1());

        private void DevTriviaMenu_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void btn_Dificil_Click(object sender, EventArgs e) => AbrirEjercicio(new DevTriviaDificil_1());
    }
}
