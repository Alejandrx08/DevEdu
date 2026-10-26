using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DgvGeneralAdd : Form, IGeneralAddView
    {
        private readonly GeneralAddPresenter _presenter;
        private bool _operacionEnCurso;

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
            MessageBox.Show(
                mensaje,
                "DevEdu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            EnfocarNombre();
        }

        private async void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            if (_operacionEnCurso || IsDisposed)
                return;

            _operacionEnCurso = true;
            btnAgregar.Enabled = false;

            try
            {
                await _presenter.AgregarUsuarioAsync();
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MostrarError(
                        "Error inesperado al registrar: " + ex.Message);
                }
            }
            finally
            {
                _operacionEnCurso = false;

                if (!IsDisposed)
                    btnAgregar.Enabled = true;
            }
        }
    }
}
