using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio;

namespace Proyecto_Molina_Prado_Comba.formularios.Login
{
    public partial class frmLogin : Form
    {
        private readonly SUsuario sUsuario;
        public string UsuarioLogueado { get; internal set; }

        public frmLogin()
        {
            InitializeComponent();
            sUsuario = new SUsuario();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text == ""))
            {
                MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((txtPass.Text == ""))
            {
                MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var usr = sUsuario.ValidarUsuario(txtUsuario.Text, txtPass.Text);
            if (usr != null)
            {
                UsuarioLogueado = usr.NombreUsuario;
                this.Close();
            }
            else
            {
                txtPass.Text = "";
                txtPass.Focus();
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
