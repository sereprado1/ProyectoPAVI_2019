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

namespace Proyecto_Molina_Prado_Comba.Capa_GUI.Descuento
{
    public partial class frmABMDescuento : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly SDescuento sDescuento;
        private Clases.Descuento oDescuentoSelected;
        public frmABMDescuento()
        {
            InitializeComponent();
            sDescuento = new SDescuento();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }

        public void SeleccionarDescuento(FormMode op, Clases.Descuento descuentoSelected)
        {
            formMode = op;
            oDescuentoSelected = descuentoSelected;
        }

        private void MostrarDatos()
        {
            if (oDescuentoSelected != null)
            {
                txtDescripcion.Text = oDescuentoSelected.Descripcion;
                txtPorcentaje.Text = oDescuentoSelected.Porcentaje.ToString();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteDescuento() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oDescuento = new Clases.Descuento();
                                oDescuento.Descripcion = txtDescripcion.Text;
                                oDescuento.Porcentaje = System.Convert.ToSingle(double.Parse(txtPorcentaje.Text.Replace('.', ',')));

                                    if (sDescuento.CrearDescuento(oDescuento))
                                    {
                                        MessageBox.Show("Descuento creado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Ya existe el descuento especificado. Ingrese uno nuevo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }

                    case FormMode.update:
                        {
                            if (ValidarCampos())
                            {
                                oDescuentoSelected.Descripcion = txtDescripcion.Text;
                                oDescuentoSelected.Porcentaje = System.Convert.ToSingle(double.Parse(txtPorcentaje.Text.Replace('.', ',')));

                                if (sDescuento.ActualizarDescuento(oDescuentoSelected))
                                {
                                    MessageBox.Show("Descuento modificado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                else
                                    MessageBox.Show("Error al modificar descuento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;
                        }

                    case FormMode.delete:
                        {
                            if (MessageBox.Show("¿Seguro que desea eliminar el descuento?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {

                                if (sDescuento.ModificarEstadoDescuento(oDescuentoSelected))
                                {
                                    MessageBox.Show("Descuento eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Error al eliminar descuento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;
                        }
                }
            }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtDescripcion.Text == string.Empty && txtPorcentaje.Text == string.Empty)
            {
                txtDescripcion.BackColor = Color.Red;
                txtPorcentaje.BackColor = Color.Red;
                txtDescripcion.Focus();
                return false;
            }
            else
                if (txtDescripcion.Text == string.Empty)
                {
                txtDescripcion.BackColor = Color.Red;
                txtDescripcion.Focus();
                return false;
                }
                else
                    if (txtPorcentaje.Text == string.Empty)
                    {
                        txtPorcentaje.BackColor = Color.Red;
                        txtPorcentaje.Focus();
                        return false;
                    }
                    else
                        txtDescripcion.BackColor = Color.White;
                        txtPorcentaje.BackColor = Color.White;

                        return true;
        }

        private bool ExisteDescuento()
        {
            return sDescuento.ObtenerDescuento(txtDescripcion.Text) != null;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmABMDescuento_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Descuento";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Descuento";
                        MostrarDatos();
                        txtDescripcion.Enabled = true;
                        txtPorcentaje.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Descuento";
                        txtDescripcion.Enabled = false;
                        txtPorcentaje.Enabled = false;
                        break;
                    }
            }
        }
                                          
    }
}
