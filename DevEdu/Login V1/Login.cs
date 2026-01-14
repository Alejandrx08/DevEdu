using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_V1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int intentos = 3;

        private void btn_Log_Click_1(object sender, EventArgs e)
        {
            if (intentos >= 1)
            {
                // Usuario admin
                if (txt_username.Text == "useradmin@unan.edu.ni" && txt_Password.Text == "123456")
                {
                    Sesion.Usuario = txt_username.Text;
                    Sesion.EsAdmin = true; // MARCAMOS COMO ADMIN

                    this.Hide();
                    FrmMainMenu Principal = new FrmMainMenu();
                    Principal.ShowDialog();
                    this.Close();
                    return;
                }

                // Usuarios regulares desde archivo
                string rutaArchivo = @"C:\DevEdu\Usuarios.txt";
                if (System.IO.File.Exists(rutaArchivo))
                {
                    var lineas = System.IO.File.ReadAllLines(rutaArchivo);
                    bool encontrado = false;
                    foreach (var linea in lineas)
                    {
                        var datos = linea.Split(',');
                        if (datos.Length >= 4)
                        {
                            string correo = datos[2];
                            string contrasena = datos[3];
                            if (txt_username.Text == correo && txt_Password.Text == contrasena)
                            {
                                encontrado = true;
                                break;
                            }
                        }
                    }

                    if (encontrado)
                    {
                        Sesion.Usuario = txt_username.Text;
                        Sesion.EsAdmin = false; // Usuario normal

                        this.Hide();
                        FrmMainMenu Principal = new FrmMainMenu();
                        Principal.ShowDialog();
                        this.Close();
                        return;
                    }
                }

                intentos--;
                MessageBox.Show($"Usuario o contraseña inválida, intentos restantes {intentos}", "DevEdu");
            }
            else
            {
                MessageBox.Show("Has excedido la cantidad de intentos", "Confirmar", MessageBoxButtons.OK);
                Close();
            }
        }

        private void Link_registro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmRegistro Principal = new FrmRegistro();
            Principal.ShowDialog();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_Log_Click_1(sender, e);
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txt_Password.Focus();
            }
        }
    }
}
