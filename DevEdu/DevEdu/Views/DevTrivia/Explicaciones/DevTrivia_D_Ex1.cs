using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu.UI.Forms.DevTrivia
{
    public partial class DevTrivia_D_Ex1 : Form
    {
        public DevTrivia_D_Ex1()
        {
            InitializeComponent();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMainMenu Principal = new FrmMainMenu();
            Principal.ShowDialog();
            this.Close();
        }
    }
}
