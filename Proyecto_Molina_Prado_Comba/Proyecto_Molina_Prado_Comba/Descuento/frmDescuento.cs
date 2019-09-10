using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba.NewFolder1
{
    public partial class frmCuotas : Form
    {
        public frmCuotas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT * From Descuento d WHERE 1 = 1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtid_descuento.Text))
            {
                var id_descuento = txtid_descuento.Text;
                strSql += "AND (d.id_descuento = @id_descuento) ";
                parametros.Add("id_descuento", id_descuento);
            }

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                var descripcion = txtDescripcion.Text;
                strSql += "AND (d.descripcion = @descripcion) ";
                parametros.Add("Descripcion", descripcion);
            }

            if (!string.IsNullOrEmpty(txtPorcentaje.Text))
            {
                var porcentaje = txtPorcentaje.Text;
                strSql += "AND (d.porcentaje = @porcentaje) ";
                parametros.Add("Porcentaje", porcentaje);
            }


            dgvDirigente.DataSource = Clases.ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);
            if (dgvDirigente.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txtid_descuento.Clear();
            txtDescripcion.Clear();
            txtPorcentaje.Clear();
            txtid_descuento.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
