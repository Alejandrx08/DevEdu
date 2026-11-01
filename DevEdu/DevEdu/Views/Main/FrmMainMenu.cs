using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Views.Admin;
using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class FrmMainMenu : Form, IMainMenuView
    {
        private readonly MainMenuPresenter _presenter;

        public FrmMainMenu()
        {
            InitializeComponent();
            _presenter = new MainMenuPresenter(this);
        }

        public void MostrarMenuUsuarios(bool visible)
        {
            usuariosToolStripMenuItem.Visible = visible;
        }
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void Cerrar()
        {
            Close();
        }

        public void AbrirDevTrivia()
        {
            Hide();
            using (var modulo = new DevTriviaMenu())
                modulo.ShowDialog(this);
            Show();
            Activate();
        }

        public void AbrirDevVis()
        {
            Hide();
            using (var modulo = new DevVisMenu())
                modulo.ShowDialog(this);
            Show();
            Activate();
        }

        public void AbrirDevEx()
        {
            Hide();
            using (var menu = new DevExMenu())
            {
                menu.ShowDialog(this);
            }
            Show();
            Activate();
        }

        public void AbrirDevBot()
        {
            Hide();
            using (var modulo = new DevbotChat())
                modulo.ShowDialog(this);
            Show();
            Activate();
        }

        public void AbrirDevHub()
        {
            Hide();
            using (var modulo = new DevHubMenu())
                modulo.ShowDialog(this);
            Show();
            Activate();
        }

        public void AbrirAlumnos()
        {
            using (var formulario = new DatagridAlumnos())
                formulario.ShowDialog(this);
        }

        public void AbrirMaestros()
        {
            using (var formulario = new DatagridMaestros())
                formulario.ShowDialog(this);
        }

        public void AbrirGeneral()
        {
            using (var formulario = new DataGridGeneral())
                formulario.ShowDialog(this);
        }

        public void AbrirBitacora()
        {
            using (var formulario = new Bitacora())
                formulario.ShowDialog(this);
        }

        public bool ConfirmarCerrarSesion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "DevEdu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        public void CerrarSesion()
        {
            Hide();
        }

        public void AbrirLogin()
        {
            using (var login = new Login())
                login.ShowDialog(this);
            Close();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            _presenter.Iniciar();
        }

        private void btn_DevTrivia_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevTrivia();
        }

        private void btn_DevVis_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevVis();
        }

        private void btn_DevEx_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevEx();
        }

        private void btn_DevBot_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevBot();
        }

        private void btn_DevHub_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevHub();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevBot();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevTrivia();
        }

        private void Exp_Ex_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevEx();
        }

        private void Exp_Vis_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevVis();
        }

        private void Exp_Hub_Click(object sender, EventArgs e)
        {
            _presenter.AbrirDevHub();
        }

        private void alumnosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _presenter.AbrirAlumnos();
        }

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.AbrirMaestros();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.AbrirGeneral();
        }

        private void bItacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.AbrirBitacora();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.CerrarSesion();
        }
    }
}

