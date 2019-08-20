using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        //Boton clic
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seguro desea salir", "Atencion", MessageBoxButtons.YesNo);
            this.Close();
        }

        //Boton Ingresar
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe ingresar un Usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Debe ingresar un Contraseña", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bienvenido " + txtUsuario.Text, "Iniciando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close() ;
        }
    }
}
