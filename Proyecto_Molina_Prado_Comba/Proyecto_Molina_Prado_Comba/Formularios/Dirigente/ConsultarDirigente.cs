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
            string strSql = "SELECT TOP 20 D.nro_doc_diri, D.nombre, D.apellido, D.telefono, D.direccion FROM GrupoScoutProyecto.dbo.Dirigente D JOIN GrupoScoutProyecto.dbo.ComunidadXDirigente CD ON D.id_tipo_doc_diri = CD.id_tipo_doc_diri AND D.nro_doc_diri = CD.nro_doc_diri WHERE 1 = 1 ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
          
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                var nombre = txtNombre.Text;
                strSql += "AND (D.nombre=@nombre) ";
                parametros.Add("nombre", nombre);
            }

            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                var apellido = txtApellido.Text;
                strSql += "AND (D.apellido=@apellido) ";
                parametros.Add("apellido", apellido);
            }

            if (!string.IsNullOrEmpty(cmbFuncion.Text))
            {
                var idFuncion = cmbFuncion.SelectedValue.ToString();
                strSql += "AND (CD.id_funcion=@idFuncion) ";
                parametros.Add("idFuncion", idFuncion);
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

        private void ConsultarDirigente_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbFuncion, Clases.ConexionBD.GetConexionBD().ConsultaSQL("Select * from Funcion"), "descripcion", "id_funcion");

        }

    }
}
