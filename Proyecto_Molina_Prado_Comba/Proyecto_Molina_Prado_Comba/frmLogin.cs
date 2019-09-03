using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void brnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Seguro Desea Salir?"," ", MessageBoxButtons.OKCancel);
            Close();
        }

        private void brnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text== "")
            {
                MessageBox.Show("Debe Ingresar un usuario");
                txtUsuario.Focus();
                return;
            }
            if(txtContraseña.Text == "")
            {
                MessageBox.Show("Debe Ingresar contraseña");
                txtUsuario.Focus();
                return;
            }
        }
    }
}
