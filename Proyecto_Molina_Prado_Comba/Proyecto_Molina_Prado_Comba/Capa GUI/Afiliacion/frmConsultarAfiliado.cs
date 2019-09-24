using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba.formularios.Afiliacion
{
    public partial class frmConsultarAfiliado : Form
    {
        public frmConsultarAfiliado()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtAño.Clear();
            txtAño.Focus();
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string strSql = "SELECT * FROM GrupoScoutProyecto.dbo.Afiliado A WHERE 1 = 1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(txtAño.Text))
            {
                var año = txtAño.Text;
                strSql += "AND (A.año=@año) ";
                parametros.Add("año", año);
            }

            //if (!string.IsNullOrEmpty(txtNombre.Text))
            //{
            //    var nombre = txtNombre.Text;
            //    strSql += "AND (D.nombre=@nombre) ";
            //    parametros.Add("nombre", nombre);
            //}

            //if (!string.IsNullOrEmpty(txtApellido.Text))
            //{
            //    var apellido = txtApellido.Text;
            //    strSql += "AND (D.apellido=@apellido) ";
            //    parametros.Add("apellido", apellido);
            //}

            //if (!string.IsNullOrEmpty(cmbFuncion.Text))
            //{
            //    var idFuncion = cmbFuncion.SelectedValue.ToString();
            //    strSql += "AND (CD.id_funcion=@idFuncion) ";
            //    parametros.Add("idFuncion", idFuncion);


            // dgvAfiliacion.DataSource = Clases.ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);
            //if (dgvAfiliacion.Rows.Count == 0)
            //{
            //  MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

    }
}
