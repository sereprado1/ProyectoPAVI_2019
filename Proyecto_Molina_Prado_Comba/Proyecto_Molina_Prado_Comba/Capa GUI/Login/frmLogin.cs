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

namespace Proyecto_Molina_Prado_Comba.formularios.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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

            if (ValidarIngreso(txtUsuario.Text, txtPass.Text))
            {
                MessageBox.Show("Usted a ingresado al sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                txtPass.Text = "";
                txtPass.Focus();
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarIngreso(string pUsuario, string pPassword)
        {
            bool usuarioValido = false;
            try
            {
                String consultaSql = string.Concat(" SELECT * ",
                                                   "   FROM Usuarios ",
                                                   "  WHERE usuario =  '", pUsuario, "'");

                DataTable resultado = Clases.ConexionBD.GetConexionBD().ConsultaSQL(consultaSql);

                if (resultado.Rows.Count >= 1)
                {
                    if (resultado.Rows[0]["contraseña"].ToString() == pPassword)
                    {
                        usuarioValido = true;
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(string.Concat("Error de base de datos: ", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usuarioValido;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
