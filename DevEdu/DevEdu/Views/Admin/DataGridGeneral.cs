using DevEdu.Core.Interfaces;
using DevEdu.Core.Models;
using DevEdu.Core.Presenters;
using DevEdu.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DataGridGeneral : Form, IGeneralView, IPermisosView
    {
        private readonly PermisosPresenter _permisos;
        private readonly GeneralPresenter _presenter;

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
                        DgvGeneral.CurrentRow.Cells["id"].Value),

                    Nombre =
                        DgvGeneral.CurrentRow.Cells["nombre"]
                        .Value?.ToString() ?? "",

                    Apellido =
                        DgvGeneral.CurrentRow.Cells["apellido"]
                        .Value?.ToString() ?? "",

                    Correo =
                        DgvGeneral.CurrentRow.Cells["correo"]
                        .Value?.ToString() ?? "",

                    Rango =
                        DgvGeneral.CurrentRow.Cells["rango"]
                        .Value?.ToString() ?? "",

                    Estado =
                        DgvGeneral.CurrentRow.Cells["estado"]
                        .Value?.ToString() ?? "",

                    Activo = Convert.ToBoolean(
                        DgvGeneral.CurrentRow.Cells["activo"].Value)
                };
            }
        }

        public void MostrarDatos(DataTable datos)
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
            DgvGeneralAdd principal = new DgvGeneralAdd();
            principal.ShowDialog();
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

        private void DataDridGeneral_Load(
            object sender,
            EventArgs e)
        {
            if (!_permisos.ValidarSoloAdmin())
                return;

            txtCount.Enabled = false;

            _presenter.Iniciar();
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            _presenter.GuardarCambios();
        }

        private void btnAsignarAlumnos_Click(
            object sender,
            EventArgs e)
        {
            _presenter.AsignarAlumno();
        }

        private void btnAsignarMaestro_Click(
            object sender,
            EventArgs e)
        {
            _presenter.AsignarMaestro();
        }

        private void btnAsignarAdmin_Click(
            object sender,
            EventArgs e)
        {
            _presenter.AsignarAdmin();
        }

        private void btnQuitarRol_Click(
            object sender,
            EventArgs e)
        {
            _presenter.QuitarRol();
        }

        private void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.AgregarUsuario();
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            _presenter.EliminarUsuario();
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.ActualizarVista();
        }
    }
}