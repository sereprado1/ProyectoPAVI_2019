using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Molina_Prado_Comba.Clases;
using Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio
{
    public class SDescuento
    {
        private ADDescuento ADDescuento;
        public SDescuento()
        {
            ADDescuento = new ADDescuento();
        }
        public IList<Descuento> ObtenerTodos()
        {
            return ADDescuento.GetDescuento();
        }

        public Descuento ValidarDescuento(string descripcion, string porcentaje)
        {
            //SIN PARAMETROS

            var dsc = ADDescuento.GetDescuentoSinParametros(descripcion);
            //CON PARAMETROS
            //var usr = oUsuarioDao.GetUserConParametros(usuario);    

            if (dsc.Porcentaje.ToString() != null && dsc.Porcentaje.Equals(porcentaje))
            {
                return dsc;
            }

            return null;
        }

        internal bool CrearDescuento(Descuento oDescuento)
        {
            return ADDescuento.Create(oDescuento);
        }

        internal bool ActualizarDescuento(Descuento oDescuentoSelected)
        {
            return ADDescuento.Update(oDescuentoSelected);
        }

        internal bool ModificarEstadoDescuento(Descuento oDescuentoSelected)
        {
            return ADDescuento.Delete(oDescuentoSelected);
        }

        internal object ObtenerDescuento(string descripcion)
        {
            //SIN PARAMETROS
            return ADDescuento.GetDescuentoSinParametros(descripcion);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }

        internal IList<Descuento> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return ADDescuento.GetConFiltrosSinParametros(condiciones);
        }

        internal IList<Descuento> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return ADDescuento.GetConFiltrosConParametros(filtros);
        }
    }
}
