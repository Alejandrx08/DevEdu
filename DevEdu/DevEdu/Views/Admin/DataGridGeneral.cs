using DevEdu.Core.DTOs;
using DevEdu.Core.Interfaces;
using DevEdu.Core.Models;
using DevEdu.Core.Presenters;
using DevEdu.Models;
using System;
using System.Collections.Generic;
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
                        DgvGeneral.CurrentRow.Cells["Id"].Value),

                    Nombre =
                        DgvGeneral.CurrentRow.Cells["Nombre"]
                        .Value?.ToString() ?? "",

                    Apellido =
                        DgvGeneral.CurrentRow.Cells["Apellido"]
                        .Value?.ToString() ?? "",

                    Correo =
                        DgvGeneral.CurrentRow.Cells["Correo"]
                        .Value?.ToString() ?? "",

                    Rango =
                        DgvGeneral.CurrentRow.Cells["Rango"]
                        .Value?.ToString() ?? "",

                    Estado =
                        DgvGeneral.CurrentRow.Cells["Estado"]
                        .Value?.ToString() ?? "",

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