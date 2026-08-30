using DevEdu.Core.Services;
using DevEdu.Core.Validation;
using System;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DgvGeneralAdd : Form
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();

        public DgvGeneralAdd()
        {
            InitializeComponent();
        }

        private void DgvGeneralAdd_Load(object sender, EventArgs e) { }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtbx_nombre.Text.Trim();
            string apellido = txtbx_apellido.Text.Trim();
            string correo = txtbx_correo.Text.Trim();
            string pass = txtbx_contrasena.Text;

            if (!UsuarioValidator.EsValidoParaAlta(nombre, apellido, correo, pass, out string mensajeError))
            {
                MessageBox.Show(mensajeError);
                return;
            }

            try
            {
                _usuarioService.Registrar(nombre, apellido, correo, pass);

                MessageBox.Show("Usuario agregado con éxito.");
                txtbx_nombre.Clear();
                txtbx_apellido.Clear();
                txtbx_correo.Clear();
                txtbx_contrasena.Clear();
                txtbx_nombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}