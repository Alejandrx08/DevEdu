using DevEdu.Core.DTOs;
using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DatagridAlumnos : Form,
        IPermisosView, IAlumnosView
    {
        private readonly PermisosPresenter _permisos;
        private readonly AlumnosPresenter _presenter;
        private bool _operacionEnCurso;

        public DatagridAlumnos()
        {
            InitializeComponent();

            dataGridViewAlumnos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            _permisos = new PermisosPresenter(this);
            _presenter = new AlumnosPresenter(this);
        }

        public string Id => txtbx_ID.Text;
        public string Nombre => txtbx_Nombre.Text;
        public string Apellido => txtbx_Apellido.Text;
        public string Correo => txtbx_Correo.Text;

        public void AccesoDenegado()
        {
            MessageBox.Show(
                "Acceso denegado.",
                "DevEdu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
        }

        private async void DatagridAlumnos_Load(
            object sender,
            EventArgs e)
        {
            if (!_permisos.ValidarAdminOMaestro())
                return;

            txtCount.Enabled = false;
            txtbx_ID.ReadOnly = true;

            dataGridViewAlumnos.EnableHeadersVisualStyles = false;

            await EjecutarOperacionAsync(
                () => _presenter.IniciarAsync());
        }

        private async void btnview_Click_1(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.IniciarAsync());
        }

        private async void btnDel_Click_1(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.EliminarDatosAsync());
        }

        private async void btnEdit_Click(
            object sender,
            EventArgs e)
        {
            await EjecutarOperacionAsync(
                () => _presenter.EditarDatosAsync());
        }

        private void dataGridViewAlumnos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dataGridViewAlumnos.Rows[e.RowIndex];

            txtbx_ID.Text =
                fila.Cells["Id"].Value?.ToString() ?? string.Empty;

            txtbx_Nombre.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;

            txtbx_Apellido.Text =
                fila.Cells["Apellido"].Value?.ToString() ?? string.Empty;

            txtbx_Correo.Text =
                fila.Cells["Correo"].Value?.ToString() ?? string.Empty;
        }

        public void MostrarDatos(List<AlumnoDto> datos)
        {
            dataGridViewAlumnos.DataSource = null;
            dataGridViewAlumnos.DataSource = datos;

            dataGridViewAlumnos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewAlumnos.Columns["Id"] != null)
            {
                dataGridViewAlumnos.Columns["Id"].HeaderText = "ID";
            }
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

        public void LimpiarCampos()
        {
            txtbx_Nombre.Clear();
            txtbx_Apellido.Clear();
            txtbx_ID.Clear();
            txtbx_Correo.Clear();
        }

        public void EnfocarCorreo()
        {
            txtbx_Correo.Focus();
        }

        public void EnfocarId()
        {
            txtbx_ID.Focus();
        }

        private async Task EjecutarOperacionAsync(
            Func<Task> operacion)
        {
            if (_operacionEnCurso || IsDisposed)
                return;

            _operacionEnCurso = true;
            CambiarEstadoControles(false);

            try
            {
                await operacion();
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MostrarError(
                        "Error inesperado: " + ex.Message);
                }
            }
            finally
            {
                _operacionEnCurso = false;

                if (!IsDisposed)
                    CambiarEstadoControles(true);
            }
        }

        private void CambiarEstadoControles(bool habilitados)
        {
            dataGridViewAlumnos.Enabled = habilitados;
            btnview.Enabled = habilitados;
            btnDel.Enabled = habilitados;
            btnEdit.Enabled = habilitados;
        }
    }
}
