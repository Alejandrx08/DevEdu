using DevEdu.Core.Interfaces;
using DevEdu.Core.Presenters;
using System.Data;
using System.Windows.Forms;

namespace DevEdu.Views.Admin
{
    public partial class Bitacora : Form, IBitacoraView
    {
        private readonly BitacoraPresenter _presenter;

        public Bitacora()
        {
            InitializeComponent();

            _presenter = new BitacoraPresenter(this);

            Load += Bitacora_Load;
        }

        public void MostrarDatos(DataTable datos)
        {
            DgvBitacora.DataSource = datos;
        }

        public void MostrarCantidad(int cantidad)
        {
            txtCount.Text = "Registros: " + cantidad;
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

        public void ConfigurarGrid()
        {
            DgvBitacora.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            DgvBitacora.MultiSelect = false;

            DgvBitacora.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DgvBitacora.ReadOnly = true;
        }

        public void AccesoDenegado()
        {
            MessageBox.Show(
                "No tiene permisos para acceder a la bitácora.",
                "Acceso denegado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
        }

        private void Bitacora_Load(
            object sender,
            System.EventArgs e)
        {
            _presenter.Iniciar();
        }

        private void DgvBitacora_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void txtCount_TextChanged(
            object sender,
            System.EventArgs e)
        {
        }
    }
}