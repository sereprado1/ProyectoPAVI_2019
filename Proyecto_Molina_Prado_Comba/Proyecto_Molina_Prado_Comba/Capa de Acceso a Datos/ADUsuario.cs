using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Proyecto_Molina_Prado_Comba.Clases;
using System.Data;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos
{
    public class ADUsuario
    {
        public IList<Usuario> GetUsuarios()
        {
            List<Usuario> listado = new List<Usuario>();

            var strSql = "SELECT id_usuario, usuario, from Usuarios  where borrado=0";

            var resultadoConsulta = ConexionBD.GetConexionBD().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listado.Add(agregarAGrilla(row));
            }

            return listado;
        }

        public Usuario getUsuario(string pUsuario)
        {
            String consultaSql = string.Concat(" SELECT id_usuario, usuario, contraseña ",
                                               "   FROM Usuarios ",
                                               "  WHERE borrado=0 and usuario =  '", pUsuario, "'");

            var resultado = ConexionBD.GetConexionBD().ConsultaSQL(consultaSql);

            if (resultado.Rows.Count > 0)
            {
                return agregarAGrilla(resultado.Rows[0]);
            }

            return null;
        }

        private Usuario agregarAGrilla(DataRow row)
        {
            Usuario usuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                contraseña = row.Table.Columns.Contains("contraseña") ? row["contraseña"].ToString() : null
            };

            return usuario;
        }
    }

}