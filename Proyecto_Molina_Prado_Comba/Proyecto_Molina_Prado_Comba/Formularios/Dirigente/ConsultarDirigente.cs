using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba.formularios.Dirigente
{
    public partial class ConsultarDirigente : Form
    {
        public ConsultarDirigente()
        {
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT TOP 20 * FROM Dirigente WHERE 1=1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
          
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                var nombre = txtNombre.Text;
                strSql += "AND (nombre=@nombre) ";
                parametros.Add("nombre", nombre);
            }

            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                var apellido = txtApellido.Text;
                strSql += "AND (apellido=@apellido) ";
                parametros.Add("apellido", apellido);
            }

            dgvDirigente.DataSource = Clases.ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);
            if (dgvDirigente.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            
        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNombre.Focus();
        }
    }
}
