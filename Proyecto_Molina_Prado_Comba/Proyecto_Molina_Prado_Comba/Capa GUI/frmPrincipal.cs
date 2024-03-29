﻿using System;
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
            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            formularios.Login.frmLogin login = new formularios.Login.frmLogin();
            login.ShowDialog();
        }
        
        private void DirigentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.Dirigente.ConsultarDirigente frmConsultarDirigente = new formularios.Dirigente.ConsultarDirigente();
            frmConsultarDirigente.ShowDialog();
        }

        private void AfiliaciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            formularios.Afiliacion.frmConsultarAfiliado frmConsultarAfiliado = new formularios.Afiliacion.frmConsultarAfiliado();
            frmConsultarAfiliado.ShowDialog();
        }

        private void ConsultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_GUI.Login.frmUsuarios frmUsuarios = new Capa_GUI.Login.frmUsuarios();
            frmUsuarios.ShowDialog();
        }

        private void descuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_GUI.Descuento.frmDescuento frmDescuento = new Capa_GUI.Descuento.frmDescuento();
            frmDescuento.ShowDialog();
        }
    }
}
