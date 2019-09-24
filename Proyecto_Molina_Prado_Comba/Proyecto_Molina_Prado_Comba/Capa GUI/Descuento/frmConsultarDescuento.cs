using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba.formularios.Descuento
{
    public partial class frmConsultarDescuento : Form
    {
        public frmConsultarDescuento()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT * From Descuento d WHERE 1 = 1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();


            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                var descripcion = txtDescripcion.Text;
                strSql += "AND (d.descripcion LIKE '%@Descripcion%') ";
                parametros.Add("Descripcion", descripcion);
            }

            if (!string.IsNullOrEmpty(txtPorcentaje.Text))
            {
                var porcentaje = txtPorcentaje.Text;
                strSql += "AND (d.porcentaje = @Porcentaje) ";
                parametros.Add("Porcentaje", porcentaje);
            }


            dgvDirigente.DataSource = Capa_de_Acceso_a_Datos.ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);
            if (dgvDirigente.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void limpiar()
        {
            txtDescripcion.Clear();
            txtPorcentaje.Clear();
            txtDescripcion.Focus();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
