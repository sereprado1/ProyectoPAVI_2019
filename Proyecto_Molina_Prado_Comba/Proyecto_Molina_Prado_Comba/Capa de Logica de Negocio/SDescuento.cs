using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Molina_Prado_Comba.Clases;
using Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio
{
    class SDescuento
    {
        private ADDescuento ADDescuento;
        public SDescuento()
        {
            ADDescuento = new ADDescuento();
        }

        public IList<Descuento> ConsultarDescuentoConFiltrosCondiciones(String condiciones)
        {
            return ADDescuento.GetDescuentoFiltrosCondicion(condiciones);
        }

        public IList<Descuento> ConsultarDescuentoConFiltros(Dictionary<string, object> parametros)
        {
            return ADDescuento.GetDescuentoConFiltro(parametros);
        }

        public Descuento ConsultarDirigentePorId(int idDescuento)
        {
            return ADDescuento.getDescuentoPorID(idDescuento);
        }
    }
}
