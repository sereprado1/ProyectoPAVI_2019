using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Molina_Prado_Comba.Clases;
using Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio
{
    public class SDirigente
    {
        private ADdirigente ADdirigente;
        public SDirigente()
        {
            ADdirigente = new ADdirigente();
        }

        public IList<Dirigente> ConsultarDirigenteConFiltrosCondiciones(String condiciones)
        {
            return ADdirigente.GetDirigentesFiltrosCondicion(condiciones);
        }

        public IList<Dirigente> ConsultarDirigenteConFiltros(Dictionary<string, object> parametros)
        {
            return ADdirigente.GetDirigentesConFiltro(parametros);
        }

        public Dirigente ConsultarDirigentePorId(int tipoDoc, int nroDoc)
        {
            return ADdirigente.getDirigentePorID(tipoDoc, nroDoc);
        }
    }
}
