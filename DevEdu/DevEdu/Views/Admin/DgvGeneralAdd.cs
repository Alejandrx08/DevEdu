using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DgvGeneralAdd : Form, IGeneralAddView
    {
        private readonly GeneralAddPresenter _presenter;

        public DgvGeneralAdd()
        {
            InitializeComponent();

            _presenter = new GeneralAddPresenter(this);
        }

        public string Nombre => txtbx_nombre.Text;

        public string Apellido => txtbx_apellido.Text;

        public string Correo => txtbx_correo.Text;

        public string Contrasena => txtbx_contrasena.Text;

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "DevEdu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public void LimpiarCampos()
        {
            txtbx_nombre.Clear();
            txtbx_apellido.Clear();
            txtbx_correo.Clear();
            txtbx_contrasena.Clear();
        }

        public void EnfocarNombre()
        {
            txtbx_nombre.Focus();
        }

        public void Cerrar()
        {
            Close();
        }

        private void DgvGeneralAdd_Load(
            object sender,
            EventArgs e)
        {
        }

        private void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.AgregarUsuario();
        }
    }
}