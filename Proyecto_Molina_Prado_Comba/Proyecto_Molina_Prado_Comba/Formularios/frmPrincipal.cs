using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Molina_Prado_Comba.formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ConsultarDirigenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.Dirigente.ConsultarDirigente frmConsultarDirigente = new formularios.Dirigente.ConsultarDirigente();
            frmConsultarDirigente.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            formularios.Login.frmLogin login = new formularios.Login.frmLogin();
            login.ShowDialog();
        }

        
        
    }
}
