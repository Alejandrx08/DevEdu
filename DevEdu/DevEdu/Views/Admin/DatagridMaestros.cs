using DevEdu.Core.DTOs;
using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DatagridMaestros : Form, IMaestrosView, IPermisosView
    {
        private readonly PermisosPresenter _permisos;
        private readonly MaestrosPresenter _presenter;

        public DatagridMaestros()
        {
            InitializeComponent();

            _permisos = new PermisosPresenter(this);
            _presenter = new MaestrosPresenter(this);
        }

        public string Id => txtbox_ID.Text;

        public string Nombre => txtbox_Nombre.Text;

        public string Apellido => txtbox_Apellido.Text;

        public string Correo => txtbox_Correo.Text;

        public void MostrarDatos(List<MaestroDto> datos)
        {
            DataGrid.DataSource = null;
            DataGrid.DataSource = datos;

            DataGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (DataGrid.Columns["Id"] != null)
            {
                DataGrid.Columns["Id"].HeaderText = "ID";
            }
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
            txtbox_Nombre.Clear();
            txtbox_Apellido.Clear();
            txtbox_ID.Clear();
            txtbox_Correo.Clear();
        }

        public void EnfocarCorreo()
        {
            txtbox_Correo.Focus();
        }

        public void EnfocarId()
        {
            txtbox_ID.Focus();
        }

        public void MostrarCantidad(int cantidad)
        {
            txtCount.Text = "Usuarios: " + cantidad;
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

        private void DatagripMaestros_Load(
            object sender,
            EventArgs e)
        {
            if (!_permisos.ValidarSoloAdmin())
                return;

            txtCount.Enabled = false;
            txtbox_ID.ReadOnly = true;

            DataGrid.EnableHeadersVisualStyles = false;

            _presenter.Iniciar();
        }

        private void btn_Editar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.EditarDatos();
        }

        private void btn_eliminar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.EliminarDatos();
        }

        private void btn_Mostrar_Click(
            object sender,
            EventArgs e)
        {
            _presenter.CargarDatos();
            _presenter.CargarCantidad();
        }

        private void DataGrid_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                DataGrid.Rows[e.RowIndex];

            txtbox_ID.Text =
                fila.Cells["Id"].Value?.ToString();

            txtbox_Nombre.Text =
                fila.Cells["Nombre"].Value?.ToString();

            txtbox_Apellido.Text =
                fila.Cells["Apellido"].Value?.ToString();

            txtbox_Correo.Text =
                fila.Cells["Correo"].Value?.ToString();
        }

        private void DataGrid_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void groupBox1_Enter(
            object sender,
            EventArgs e)
        {
        }

        private void txtbox_ID_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void pictureBox1_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}