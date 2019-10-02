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

namespace Proyecto_Molina_Prado_Comba.Capa_GUI.Descuento
{
    public partial class frmDescuento : Form
    {
        private SDescuento sDescuento;
        public frmDescuento()
        {
            InitializeComponent();
            sDescuento = new SDescuento();
        }

        private void FrmDescuento_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMDescuento formulario = new frmABMDescuento();
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            dgvDescuento.DataSource = null;
            String condiciones = "";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (txtDescripcion.Text != string.Empty)
                {
                    filters.Add("descripcion", txtDescripcion.Text);
                    condiciones += "AND descripcion LIKE " + "'%" + txtDescripcion.Text + "%'";
                }

                if (txtPorcentaje.Text != string.Empty)
                {
                    filters.Add("porcentaje", txtPorcentaje.Text);
                    condiciones += "AND porcentaje =" + txtPorcentaje.Text;
                }


                if (filters.Count > 0)
                    //SIN PARAMETROS
                    dgvDescuento.DataSource = sDescuento.ConsultarConFiltrosSinParametros(condiciones);

                //CON PARAMETROS
                //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                dgvDescuento.DataSource = sDescuento.ObtenerTodos();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    txtDescripcion.Enabled = false;
                    txtPorcentaje.Enabled = false;
                }
                else
                {
                    txtDescripcion.Enabled = true;
                    txtPorcentaje.Enabled = true;
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmABMDescuento formulario = new frmABMDescuento();
            var descuento = (Clases.Descuento)dgvDescuento.CurrentRow.DataBoundItem;
            formulario.SeleccionarDescuento(frmABMDescuento.FormMode.update, descuento);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void DgvDescuento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmABMDescuento formulario = new frmABMDescuento();
            var descuento = (Clases.Descuento)dgvDescuento.CurrentRow.DataBoundItem;
            formulario.SeleccionarDescuento(frmABMDescuento.FormMode.delete, descuento);
            formulario.ShowDialog();
            BtnConsultar_Click(sender, e);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
