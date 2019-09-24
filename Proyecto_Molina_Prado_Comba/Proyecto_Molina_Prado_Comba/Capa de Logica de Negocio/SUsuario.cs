using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Molina_Prado_Comba.Clases;
using Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Logica_de_Negocio
{ 
public class SUsuario
{
    private ADUsuario ADUsuario;
    public SUsuario()
    {
            ADUsuario = new ADUsuario();
    }
    public IList<Usuario> ObtenerTodos()
    {
        return ADUsuario.GetUsuarios();
    }

    public Usuario ValidarUsuario(string usuario, string password)
    {
        var usr = ADUsuario.getUsuario(usuario);

        if (usr.contraseña != null && usr.contraseña.Equals(password))
        {
            return usr;
        }

        return null;
    }
}
}