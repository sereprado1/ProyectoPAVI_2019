using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Molina_Prado_Comba.Clases
{
    public class Comunidad
    {
        public int IdComunidad { get; set; }
        public Rama Rama { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
