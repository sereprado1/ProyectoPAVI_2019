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
    public partial class frmUsuarios : Form
    {
        private SUsuario sUsuario;
        private SPerfil sPerfil;
        public frmUsuarios()
        {
            InitializeComponent();
            sUsuario = new SUsuario();
            sPerfil = new SPerfil();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbPerfil, Capa_de_Acceso_a_Datos.ConexionBD.GetConexionBD().ConsultaSQL("Select * from Perfil"), "descripcion", "id_perfil");
            this.CenterToParent();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    txtNombre.Enabled = false;
                    cmbPerfil.Enabled = false;
                }
                else
                {
                    txtNombre.Enabled = true;
                    cmbPerfil.Enabled = true;
                }
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = null;
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (cmbPerfil.Text != string.Empty)
                {
                    filters.Add("idPerfil", cmbPerfil.SelectedValue);
                    condiciones += " AND u.id_perfil=" + cmbPerfil.SelectedValue.ToString();

                }

                if (txtNombre.Text != string.Empty)
                {
                    filters.Add("usuario", txtNombre.Text);
                    condiciones += "AND u.usuario LIKE " + "'%" + txtNombre.Text + "%'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvUsuarios.DataSource = sUsuario.ConsultarConFiltrosSinParametros(condiciones);

                //CON PARAMETROS
                //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvUsuarios.DataSource = sUsuario.ObtenerTodos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuario.FormMode.update, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void dgvUsuarios_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMUsuario formulario = new frmABMUsuario();
            var usuario = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuario.FormMode.delete, usuario);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
