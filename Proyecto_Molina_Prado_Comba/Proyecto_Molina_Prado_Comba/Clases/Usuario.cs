using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Molina_Prado_Comba.Clases
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string contraseña { get; set; }
        public Perfil Perfil { get; set; }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
