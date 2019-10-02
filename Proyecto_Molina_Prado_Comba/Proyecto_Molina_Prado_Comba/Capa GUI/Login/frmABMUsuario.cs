using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio;
using Proyecto_Molina_Prado_Comba.Clases;

namespace Proyecto_Molina_Prado_Comba.Capa_GUI.Login
{
    public partial class frmABMUsuario : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly SUsuario sUsuario;
        private readonly SPerfil sPerfil;
        private Usuario oUsuarioSelected;
        public frmABMUsuario()
        {
            InitializeComponent();
            sUsuario = new SUsuario();
            sPerfil = new SPerfil();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }

        

        public void SeleccionarUsuario(FormMode op, Usuario usuarioSelected)
        {
            formMode = op;
            oUsuarioSelected = usuarioSelected;
        }

        private void MostrarDatos()
        {
            if (oUsuarioSelected != null)
            {
                txtNombre.Text = oUsuarioSelected.NombreUsuario;
                txtContraseña.Text = oUsuarioSelected.contraseña;
                txtRepContraseña.Text = txtContraseña.Text;
                cmbPerfil.Text = oUsuarioSelected.Perfil.Nombre;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteUsuario() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oUsuario = new Usuario();
                                oUsuario.NombreUsuario = txtNombre.Text;
                                oUsuario.contraseña = txtContraseña.Text;
                                oUsuario.Perfil = new Perfil();
                                oUsuario.Perfil.IdPerfil = (int)cmbPerfil.SelectedValue;

                                if (sUsuario.CrearUsuario(oUsuario))
                                {
                                    MessageBox.Show("Usuario creado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Ya existe el nombre de usuario. Ingrese uno nuevo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oUsuarioSelected.NombreUsuario = txtNombre.Text;
                            oUsuarioSelected.contraseña = txtContraseña.Text;
                            oUsuarioSelected.Perfil = new Perfil();
                            oUsuarioSelected.Perfil.IdPerfil = (int)cmbPerfil.SelectedValue;

                            if (sUsuario.ActualizarUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario modificado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al modificar usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("¿Seguro que desea eliminar el usuario?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (sUsuario.ModificarEstadoUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al eliminar usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombre.Text == string.Empty || txtContraseña.Text == string.Empty || txtRepContraseña.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;

            return true;
        }

        private bool ExisteUsuario()
        {
            return sUsuario.ObtenerUsuario(txtNombre.Text) != null;
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void FrmABMUsuario_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbPerfil, Capa_de_Acceso_a_Datos.ConexionBD.GetConexionBD().ConsultaSQL("Select * from Perfil"), "descripcion", "id_perfil");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Usuario";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtRepContraseña.Enabled = true;
                        cmbPerfil.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtNombre.Enabled = false;
                        txtContraseña.Enabled = false;
                        cmbPerfil.Enabled = false;
                        txtRepContraseña.Enabled = false;
                        break;
                    }
            }
        }
    }
}
