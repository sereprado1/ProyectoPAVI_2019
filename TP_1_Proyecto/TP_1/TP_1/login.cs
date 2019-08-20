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
<<<<<<< HEAD
                MessageBox.Show("Atención! Debe ingresar un Usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
=======
                MessageBox.Show("Error! Debe ingresar un Usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
>>>>>>> 240fb2fbf5e1e0f6b94d27692417099e46c9659e
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
