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

namespace Proyecto_Molina_Prado_Comba.formularios.Dirigente
{
    public partial class ConsultarDirigente : Form
    {
        private readonly SDirigente sDirigente;
        public ConsultarDirigente()
        {
            InitializeComponent();
            //InitializeDataGridView();
            sDirigente = new SDirigente();
        }

        private void ConsultarDirigente_Load(object sender, EventArgs e)
        {
            LlenarCombo(cmbFuncion, Capa_de_Acceso_a_Datos.ConexionBD.GetConexionBD().ConsultaSQL("Select * from Funcion"), "descripcion", "id_funcion");

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String sqlcondiciones;
            sqlcondiciones = "";
            Dictionary<string, object> parametros = new Dictionary<string, object>();




            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                var nombre = txtNombre.Text;
                sqlcondiciones += "AND (D.nombre LIKE '%" + nombre + "%') ";
                parametros.Add("nombre", nombre);
            }

            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                var apellido = txtApellido.Text;
                sqlcondiciones += "AND (D.apellido LIKE '%" + apellido + "%') ";
                parametros.Add("apellido", apellido);
            }

            if (!string.IsNullOrEmpty(cmbFuncion.Text))
            {
                var idFuncion = cmbFuncion.SelectedValue.ToString();
                sqlcondiciones += "AND (X.id_funcion=" + idFuncion + ") ";
                parametros.Add("idFuncion", idFuncion);
            }
            IList<Clases.Dirigente> listado = sDirigente.ConsultarDirigenteConFiltrosCondiciones(sqlcondiciones);

            dgvDirigente.DataSource = listado;
            if (dgvDirigente.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
               

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
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

        

        private void InitializeDataGridView()
        {
            dgvDirigente.ColumnCount = 6;
            dgvDirigente.ColumnHeadersVisible = true;

            dgvDirigente.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvDirigente.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dgvDirigente.Columns[0].Name = "Tipo Documento";
            dgvDirigente.Columns[0].DataPropertyName = "id_tipo_doc_diri";
            dgvDirigente.Columns[0].Width = 50;

            dgvDirigente.Columns[1].Name = "Numero Documento";
            dgvDirigente.Columns[1].DataPropertyName = "nro_doc_diri";

            dgvDirigente.Columns[2].Name = "Nombre";
            dgvDirigente.Columns[2].DataPropertyName = "nombre";

            dgvDirigente.Columns[3].Name = "Apellido";
            dgvDirigente.Columns[3].DataPropertyName = "apellido";

            dgvDirigente.Columns[4].Name = "Telefono";
            dgvDirigente.Columns[4].DataPropertyName = "telefono";

            dgvDirigente.Columns[5].Name = "Dirección";
            dgvDirigente.Columns[5].DataPropertyName = "direccion";

            

            
            dgvDirigente.AutoResizeColumnHeadersHeight();

            dgvDirigente.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
