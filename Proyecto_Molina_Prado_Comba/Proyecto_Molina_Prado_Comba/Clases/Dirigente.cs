using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Molina_Prado_Comba.Clases
{
    public class Dirigente
    {
        public int TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Funcion funcion { get; set; }
        public Comunidad Comunidad { get; set; }
        public Rama rama { get; set; }

    }
}
