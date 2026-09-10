using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DatagridAlumnos : Form, IPermisosView, IAlumnosView
    {
        private readonly PermisosPresenter _permisos;
        private readonly AlumnosPresenter _presenter;

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
            MessageBox.Show("Acceso denegado.");
            Close();
        }

        private void DatagridAlumnos_Load(object sender, EventArgs e)
        {
            if (!_permisos.ValidarAdminOMaestro())
                return;

            txtCount.Enabled = false;

            dataGridViewAlumnos.EnableHeadersVisualStyles = false;

            txtbx_ID.ReadOnly = true;

            _presenter.CargarDatos();
            _presenter.CargarCantidad();
        }

        private void btnview_Click_1(object sender, EventArgs e)
        {
            _presenter.CargarDatos();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            _presenter.EliminarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _presenter.EditarDatos();
        }

        private void dataGridViewAlumnos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtbx_ID.Text =
                dataGridViewAlumnos.Rows[e.RowIndex]
                .Cells["ID"]
                .Value?
                .ToString();

            txtbx_Nombre.Text =
                dataGridViewAlumnos.Rows[e.RowIndex]
                .Cells["Nombre"]
                .Value?
                .ToString();

            txtbx_Apellido.Text =
                dataGridViewAlumnos.Rows[e.RowIndex]
                .Cells["Apellido"]
                .Value?
                .ToString();

            txtbx_Correo.Text =
                dataGridViewAlumnos.Rows[e.RowIndex]
                .Cells["Correo"]
                .Value?
                .ToString();
        }

        public void MostrarDatos(DataTable datos)
        {
            dataGridViewAlumnos.DataSource = datos;
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
    }
}