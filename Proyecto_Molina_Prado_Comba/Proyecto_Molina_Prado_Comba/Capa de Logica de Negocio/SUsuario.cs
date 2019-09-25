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
            //SIN PARAMETROS

            var usr = ADUsuario.GetUsuarioSinParametros(usuario);
            //CON PARAMETROS
            //var usr = oUsuarioDao.GetUserConParametros(usuario);    

            if (usr.contraseña != null && usr.contraseña.Equals(password))
        {
            return usr;
        }

        return null;
    }
        internal bool CrearUsuario(Usuario oUsuario)
        {
            return ADUsuario.Create(oUsuario);
        }

        internal bool ActualizarUsuario(Usuario oUsuarioSelected)
        {
            return ADUsuario.Update(oUsuarioSelected);
        }

        internal bool ModificarEstadoUsuario(Usuario oUsuarioSelected)
        {
            return ADUsuario.Delete(oUsuarioSelected);
        }

        internal object ObtenerUsuario(string usuario)
        {
            //SIN PARAMETROS
            return ADUsuario.GetUsuarioSinParametros(usuario);

            //CON PARAMETROS
            // return oUsuarioDao.GetUserConParametros(usuario);
        }

        internal IList<Usuario> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return ADUsuario.GetConFiltrosSinParametros(condiciones);
        }

        internal IList<Usuario> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return ADUsuario.GetConFiltrosConParametros(filtros);
        }
    }
}
