namespace Proyecto_Molina_Prado_Comba.formularios
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.beneficiariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarBeneficiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afiliaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ramasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afiliaciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afiliaciónToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.descuentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beneficiariosToolStripMenuItem,
            this.ramasToolStripMenuItem,
            this.afiliaciónToolStripMenuItem1,
            this.usuariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // beneficiariosToolStripMenuItem
            // 
            this.beneficiariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarBeneficiarioToolStripMenuItem,
            this.cobroToolStripMenuItem});
            this.beneficiariosToolStripMenuItem.Name = "beneficiariosToolStripMenuItem";
            this.beneficiariosToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.beneficiariosToolStripMenuItem.Text = "Beneficiarios";
            // 
            // consultarBeneficiarioToolStripMenuItem
            // 
            this.consultarBeneficiarioToolStripMenuItem.Name = "consultarBeneficiarioToolStripMenuItem";
            this.consultarBeneficiarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultarBeneficiarioToolStripMenuItem.Text = "Consultar Beneficiario";
            // 
            // cobroToolStripMenuItem
            // 
            this.cobroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afiliaciónToolStripMenuItem,
            this.cuotasToolStripMenuItem});
            this.cobroToolStripMenuItem.Name = "cobroToolStripMenuItem";
            this.cobroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cobroToolStripMenuItem.Text = "Cobro";
            // 
            // afiliaciónToolStripMenuItem
            // 
            this.afiliaciónToolStripMenuItem.Name = "afiliaciónToolStripMenuItem";
            this.afiliaciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.afiliaciónToolStripMenuItem.Text = "Afiliación";
            // 
            // cuotasToolStripMenuItem
            // 
            this.cuotasToolStripMenuItem.Name = "cuotasToolStripMenuItem";
            this.cuotasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuotasToolStripMenuItem.Text = "Cuotas";
            // 
            // ramasToolStripMenuItem
            // 
            this.ramasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigentesToolStripMenuItem,
            this.comunidadesToolStripMenuItem});
            this.ramasToolStripMenuItem.Name = "ramasToolStripMenuItem";
            this.ramasToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.ramasToolStripMenuItem.Text = "Ramas";
            // 
            // dirigentesToolStripMenuItem
            // 
            this.dirigentesToolStripMenuItem.Name = "dirigentesToolStripMenuItem";
            this.dirigentesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.dirigentesToolStripMenuItem.Text = "Consultar dirigentes";
            this.dirigentesToolStripMenuItem.Click += new System.EventHandler(this.DirigentesToolStripMenuItem_Click);
            // 
            // comunidadesToolStripMenuItem
            // 
            this.comunidadesToolStripMenuItem.Name = "comunidadesToolStripMenuItem";
            this.comunidadesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.comunidadesToolStripMenuItem.Text = "Consultar comunidades";
            // 
            // afiliaciónToolStripMenuItem1
            // 
            this.afiliaciónToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afiliaciónToolStripMenuItem2,
            this.descuentoToolStripMenuItem});
            this.afiliaciónToolStripMenuItem1.Name = "afiliaciónToolStripMenuItem1";
            this.afiliaciónToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.afiliaciónToolStripMenuItem1.Text = "Afiliación";
            // 
            // afiliaciónToolStripMenuItem2
            // 
            this.afiliaciónToolStripMenuItem2.Name = "afiliaciónToolStripMenuItem2";
            this.afiliaciónToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.afiliaciónToolStripMenuItem2.Text = "Consultar afiliación";
            this.afiliaciónToolStripMenuItem2.Click += new System.EventHandler(this.AfiliaciónToolStripMenuItem2_Click);
            // 
            // descuentoToolStripMenuItem
            // 
            this.descuentoToolStripMenuItem.Name = "descuentoToolStripMenuItem";
            this.descuentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descuentoToolStripMenuItem.Text = "Consultar descuento";
            this.descuentoToolStripMenuItem.Click += new System.EventHandler(this.descuentoToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarUsuariosToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // consultarUsuariosToolStripMenuItem
            // 
            this.consultarUsuariosToolStripMenuItem.Name = "consultarUsuariosToolStripMenuItem";
            this.consultarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.consultarUsuariosToolStripMenuItem.Text = "Consultar usuarios";
            this.consultarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.ConsultarUsuariosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Molina_Prado_Comba.Properties.Resources.Fondo1;
            this.ClientSize = new System.Drawing.Size(898, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem beneficiariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarBeneficiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afiliaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ramasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dirigentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comunidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afiliaciónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem afiliaciónToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem descuentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarUsuariosToolStripMenuItem;
    }
}