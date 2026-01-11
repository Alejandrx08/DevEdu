using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_V1
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private bool ValidacionVacio()
        {
            if (string.IsNullOrWhiteSpace(txtbx_nombre.Text) ||
                string.IsNullOrWhiteSpace(txtbx_apellido.Text) ||
                string.IsNullOrWhiteSpace(txtbx_correo.Text) ||
                string.IsNullOrWhiteSpace(txtbx_contrasena.Text) ||
                string.IsNullOrWhiteSpace(txtbx_confirmacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return true;
            }
            return false;
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            if (ValidacionVacio())
                return;

            if (txtbx_contrasena.Text == txtbx_confirmacion.Text)
            {
                string rutaArchivo = @"C:\DevEdu\Usuarios.txt";
                string carpeta = System.IO.Path.GetDirectoryName(rutaArchivo); // se le asigna el nombre del directorio a la variable
                if (!System.IO.Directory.Exists(carpeta)) // verifica si el directotio no existe
                {
                    System.IO.Directory.CreateDirectory(carpeta); //  en ese caso se crea
                }

                string datosUsuario = $"{txtbx_nombre.Text},{txtbx_apellido.Text},{txtbx_correo.Text},{txtbx_contrasena.Text}";
                System.IO.File.AppendAllText(rutaArchivo, datosUsuario + Environment.NewLine);

                MessageBox.Show("Usuario registrado con éxito");
                this.Hide();
                Login Principal = new Login();
                Principal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
        }

        private void btn_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar))
                return;

            if(!char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
        private void txtbx_nombre_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int SelectionStart = tb.SelectionStart;
            string cleaned = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsControl(c)).ToArray());

            if (tb.Text != cleaned)
            {
                tb.Text = cleaned;
                tb.SelectionStart = Math.Min(SelectionStart, tb.Text.Length);
            }
        }

        private void txtbx_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtbx_apellido_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int SelectionStart = tb.SelectionStart;
            string cleaned = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsControl(c)).ToArray());

            if (tb.Text != cleaned)
            {
                tb.Text = cleaned;
                tb.SelectionStart = Math.Min(SelectionStart, tb.Text.Length);
            }
        }

        private void Link_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login Principal = new Login();
            Principal.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
