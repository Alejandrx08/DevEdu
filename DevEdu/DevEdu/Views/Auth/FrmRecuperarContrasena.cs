using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Core.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu.Views.Auth
{
    public partial class FrmRecuperarContrasena : Form, IPasswordRecoveryView
    {
        private readonly PasswordRecoveryPresenter _presenter;
        private bool _operacionEnCurso;

        public string Correo => txtCorreo.Text;
        public string Codigo => txtCodigo.Text;
        public string NuevaContrasena => txtNuevaContrasena.Text;
        public string ConfirmacionContrasena => txtConfirmacion.Text;

        public FrmRecuperarContrasena()
        {
            InitializeComponent();
            _presenter = new PasswordRecoveryPresenter(
                this, new PasswordRecoveryService());
            btnSolicitarCodigo.Click += async (_, _) => await SolicitarCodigoAsync();
            btnRestablecer.Click += async (_, _) => await RestablecerAsync();
            AcceptButton = btnRestablecer;
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(this, mensaje, "DevEdu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(this, mensaje, "DevEdu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void CerrarFormulario() => Close();

        private async Task SolicitarCodigoAsync()
        {
            if (!IniciarOperacion())
                return;
            try
            {
                await _presenter.SolicitarCodigoAsync();
            }
            finally
            {
                FinalizarOperacion();
            }
        }

        private async Task RestablecerAsync()
        {
            if (!IniciarOperacion())
                return;
            try
            {
                await _presenter.RestablecerContrasenaAsync();
            }
            finally
            {
                FinalizarOperacion();
            }
        }

        private bool IniciarOperacion()
        {
            if (_operacionEnCurso)
                return false;
            _operacionEnCurso = true;
            btnSolicitarCodigo.Enabled = false;
            btnRestablecer.Enabled = false;
            return true;
        }

        private void FinalizarOperacion()
        {
            _operacionEnCurso = false;
            if (IsDisposed || Disposing)
                return;
            btnSolicitarCodigo.Enabled = true;
            btnRestablecer.Enabled = true;
        }
    }
}
