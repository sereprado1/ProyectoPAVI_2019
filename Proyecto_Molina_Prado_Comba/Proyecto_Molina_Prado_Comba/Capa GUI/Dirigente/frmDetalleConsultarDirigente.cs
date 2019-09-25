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

namespace Proyecto_Molina_Prado_Comba.Capa_GUI.Dirigente
{
    public partial class frmDetalleConsultarDirigente : Form
    {
        private SDirigente sDirigente;
        public frmDetalleConsultarDirigente()
        {
            InitializeComponent();
            sDirigente = new SDirigente();
        }

        internal void InicializarDetalleDirigente(int tipoDoc, int nroDoc)
        {


            var resultado = sDirigente.ConsultarDirigentePorId(tipoDoc, nroDoc);

            if (resultado != null)
            {
                txtTipoDoc.Text = resultado.TipoDocumento.ToString();
                txtNroDoc.Text = resultado.NumeroDocumento.ToString();
                txtNombre.Text = resultado.Nombre;
                txtApellido.Text = resultado.Apellido;
                txtTelefono.Text = resultado.Telefono;
                txtDireccion.Text = resultado.Direccion;
                txtFuncion.Text = resultado.funcion.Descripcion;
                txtComunidad.Text = resultado.Comunidad.Descripcion;
                txtRama.Text = resultado.rama.Nombre;
            }

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
