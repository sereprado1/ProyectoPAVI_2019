using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos;
using Proyecto_Molina_Prado_Comba.Clases;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio
{
    public class SPerfil
    {
        private ADperfil aDperfil;
        public SPerfil()
        {
            aDperfil = new ADperfil();
        }
        public IList<Perfil> ObtenerTodos()
        {
            return aDperfil.GetAll();
        }
    }
}