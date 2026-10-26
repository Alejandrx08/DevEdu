
using DevEdu.Core.DTOs;
using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using DevEdu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DataGridGeneral : Form, IGeneralView, IPermisosView
    {
        private readonly PermisosPresenter _permisos;
        private readonly GeneralPresenter _presenter;
        private bool _operacionEnCurso;

        public DataGridGeneral()
        {
            InitializeComponent();

            _permisos = new PermisosPresenter(this);
            _presenter = new GeneralPresenter(this);
        }

        public Persona UsuarioSeleccionado
        {
            get
            {
                if (DgvGeneral.CurrentRow == null ||
                    DgvGeneral.CurrentRow.IsNewRow)
                {
                    return null;
                }

                return new Persona
                {
                    Id = Convert.ToInt32(
                        DgvGeneral.CurrentRow.Cells["Id"].Value),

                    Nombre = DgvGeneral.CurrentRow
                        .Cells["Nombre"].Value?.ToString() ?? "",

                    Apellido = DgvGeneral.CurrentRow
                        .Cells["Apellido"].Value?.ToString() ?? "",

                    Correo = DgvGeneral.CurrentRow
                        .Cells["Correo"].Value?.ToString() ?? "",

                    Rango = DgvGeneral.CurrentRow
                        .Cells["Rango"].Value?.ToString() ?? "",

                    Estado = DgvGeneral.CurrentRow
                        .Cells["Estado"].Value?.ToString() ?? "",

                    Activo = Convert.ToBoolean(
                        DgvGeneral.CurrentRow.Cells["Activo"].Value)
                };
            }
        }

        public void MostrarDatos(List<UsuarioDto> datos)
        {
            DgvGeneral.DataSource = datos;
        }

        public void MostrarCantidad(int cantidad)
        {
            txtCount.Text = "Usuarios: " + cantidad;
        }

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

        public bool Confirmar(string mensaje)
        {
            DialogResult resultado = MessageBox.Show(
                mensaje,
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return resultado == DialogResult.Yes;
        }

        public void ConfigurarGrid()
        {
            DgvGeneral.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            DgvGeneral.MultiSelect = false;

            DgvGeneral.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void AbrirAgregarUsuario()
        {
            using (DgvGeneralAdd formulario = new DgvGeneralAdd())
            {
                formulario.ShowDialog(this);
            }
        }

        public void AccesoDenegado()
        {
            MessageBox.Show(
                "Acceso denegado.",
                "DevEdu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
        }

        private async Task EjecutarOperacionAsync(
            Func<Task> operacion)
        {
            if (_operacionEnCurso || IsDisposed)
                return;

            _operacionEnCurso = true;
            CambiarEstadoBotones(false);

            try
            {
                await operacion();
            }
            catch (OperationCanceledException)
            {
                // La operación fue cancelada.
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MostrarError(
                        "Ocurrió un error inesperado: " + ex.Message);
                }
            }
            finally
            {
                _operacionEnCurso = false;

                if (!IsDisposed)
                    CambiarEstadoBotones(true);
            }
        }

        private void CambiarEstadoBotones(bool habilitados)
        {
            btnSave.Enabled = habilitados;
            btnDelete.Enabled = habilitados;
            btnAsignarAlumnos.Enabled = habilitados;
            btnAsignarMaestro.Enabled = habilitados;
            btnAsignarAdmin.Enabled = habilitados;
            btnQuitarRol.Enabled = habilitados;
            btnActualizar.Enabled = habilitados;
            btnAgregar.Enabled = habilitados;
            DgvGeneral.Enabled = habilitados;
        }

        private async void DataDridGeneral_Load(
            object sender,
            EventArgs e)
        {
            if (!_permisos.ValidarSoloAdmin())
                return;

            txtCount.Enabled = false;

            await EjecutarOperacionAsync(
                () => _presenter.IniciarAsync());
        }

        private async void btnSave_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.GuardarCambiosAsync());
        }

        private async void btnAsignarAlumnos_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.AsignarAlumnoAsync());
        }

        private async void btnAsignarMaestro_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.AsignarMaestroAsync());
        }

        private async void btnAsignarAdmin_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.AsignarAdminAsync());
        }

        private async void btnQuitarRol_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.QuitarRolAsync());
        }

        private async void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            if (_operacionEnCurso)
                return;

            _presenter.AgregarUsuario();

            await EjecutarOperacionAsync(
                () => _presenter.ActualizarVistaAsync());
        }

        private async void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.EliminarUsuarioAsync());
        }

        private async void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.ActualizarVistaAsync());
        }
    }
}
