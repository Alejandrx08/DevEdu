using DevEdu.Core.Models;
using DevEdu.Core.Services;
using DevEdu.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace DevEdu
{
    public partial class DataGridGeneral : Form
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();
        private DataTable dtUsuarios;

        public DataGridGeneral()
        {
            InitializeComponent();
        }

        private void DataDridGeneral_Load(object sender, EventArgs e)
        {
            if (Sesion.Rango != "SuperSU")
            {
                MessageBox.Show("Acceso denegado.");
                Close();
                return;
            }

            DgvGeneral.EnableHeadersVisualStyles = false;
            txtCount.Enabled = false;
            ActualizarVista();
        }

        private void ActualizarVista()
        {
            txtCount.Text = "Usuarios: " + _usuarioService.ContarUsuarios();

            dtUsuarios = _usuarioService.ObtenerUsuariosGeneral();
            DgvGeneral.DataSource = dtUsuarios;

            DgvGeneral.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvGeneral.MultiSelect = false;
            DgvGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvGeneral.Columns["estado"].ReadOnly = true;
            DgvGeneral.Columns["id"].ReadOnly = true;
        }

        private Persona ObtenerUsuarioSeleccionado()
        {
            return new Persona
            {
                Id = Convert.ToInt32(DgvGeneral.CurrentRow.Cells["id"].Value),
                Nombre = DgvGeneral.CurrentRow.Cells["nombre"].Value?.ToString() ?? "",
                Apellido = DgvGeneral.CurrentRow.Cells["apellido"].Value?.ToString() ?? "",
                Correo = DgvGeneral.CurrentRow.Cells["correo"].Value?.ToString() ?? "",
                Rango = DgvGeneral.CurrentRow.Cells["rango"].Value?.ToString() ?? "",
                Estado = DgvGeneral.CurrentRow.Cells["estado"].Value?.ToString() ?? "",
                Activo = Convert.ToBoolean(DgvGeneral.CurrentRow.Cells["activo"].Value)
            };
        }

        private void EliminarDato()
        {
            if (DgvGeneral.CurrentRow == null || DgvGeneral.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Debe seleccionar un usuario válido.");
                return;
            }

            Persona usuario = ObtenerUsuarioSeleccionado();

            var r = MessageBox.Show(
                $"¿Deseas ELIMINAR el usuario {usuario.ObtenerNombreCompleto()} con ID {usuario.Id}?\n\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                _usuarioService.EliminarUsuario(usuario.Id);
                MessageBox.Show("Usuario eliminado con éxito.");
                ActualizarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            try
            {
                _usuarioService.ActualizarUsuario(usuario);
                MessageBox.Show("Cambios guardados.");
                ActualizarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AsignarRolSeleccionado(string rol)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado != "pendiente")
            {
                MessageBox.Show("Ya tiene rol: " + usuario.Estado);
                return;
            }

            try
            {
                _usuarioService.AsignarRol(usuario.Id, rol);
                ActualizarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAsignarAlumnos_Click(object sender, EventArgs e) => AsignarRolSeleccionado("Alumno");
        private void btnAsignarMaestro_Click(object sender, EventArgs e) => AsignarRolSeleccionado("Maestro");
        private void btnAsignarAdmin_Click(object sender, EventArgs e) => AsignarRolSeleccionado("Admin");

        private void btnQuitarRol_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.CurrentRow == null) return;

            Persona usuario = ObtenerUsuarioSeleccionado();

            if (usuario.Estado == "pendiente")
            {
                MessageBox.Show("Ya es pendiente.");
                return;
            }

            try
            {
                _usuarioService.QuitarRol(usuario.Id, usuario.Estado);
                ActualizarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DgvGeneralAdd Principal = new DgvGeneralAdd();
            Principal.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) => EliminarDato();

        private void btnActualizar_Click(object sender, EventArgs e) => ActualizarVista();
    }
}