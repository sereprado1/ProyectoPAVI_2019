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
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfil p ON u.id_perfil= p.id_perfil WHERE u.borrado=0 ");

            var resultadoConsulta = ConexionBD.GetConexionBD().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(ObjectMapping(row));
            }

            return listadoUsuarios;
        }
        public Usuario GetUsuarioConParametros(string nombreUsuario)
        {
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfil p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.usuario =  @usuario AND u.borrado=0 ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("usuario", nombreUsuario);
            var resultado = ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }


        public Usuario GetUsuarioSinParametros(string nombreUsuario)
        {
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfil p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.borrado =0 ");

            strSql += " AND usuario=" + "'" + nombreUsuario + "'";


            var resultado = ConexionBD.GetConexionBD().ConsultaSQL(strSql);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Usuario> GetConFiltrosConParametros(Dictionary<string, object> parametros)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfil p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado = 0 ");


            if (parametros.ContainsKey("idPerfil"))
                strSql += " AND (u.id_perfil = @idPerfil) ";


            if (parametros.ContainsKey("usuario"))
                strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            var resultado = ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Usuario> GetConFiltrosSinParametros(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.id_perfil, ",
                                          "        p.descripcion as perfil",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfil p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado =0 " + condiciones);


            

            var resultado = ConexionBD.GetConexionBD().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Usuario oUsuario)
        {
            //CON PARAMETROS
            //string str_sql = "     INSERT INTO Usuarios (usuario, password, email, id_perfil, estado, borrado)" +
            //                 "     VALUES (@usuario, @password, @email, @id_perfil, 'S', 0)";

            // var parametros = new Dictionary<string, object>();
            //parametros.Add("usuario", oUsuario.NombreUsuario);
            //parametros.Add("password", oUsuario.Password);
            //parametros.Add("email", oUsuario.Email);
            //parametros.Add("id_perfil", oUsuario.Perfil.IdPerfil);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            //con parametros
            //return (DBHelper.GetDBHelper().EjecutarSQLConParametros(str_sql, parametros) == 1);

            //SIN PARAMETROS

            string str_sql = "INSERT INTO Usuarios (usuario, contraseña, id_perfil, borrado)" +
                            " VALUES (" +
                            "'" + oUsuario.NombreUsuario + "'" + "," +
                            "'" + oUsuario.contraseña + "'" + "," +
                            oUsuario.Perfil.IdPerfil + ",0)";
                            


            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Usuario oUsuario)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Usuarios " +
                             "SET usuario=" + "'" + oUsuario.NombreUsuario + "'" + "," +
                             " contraseña=" + "'" + oUsuario.contraseña + "'" + "," +
                             " id_perfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;

            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Usuario oUsuario)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Usuarios " +
                             "SET borrado=1" +
                             " WHERE id_usuario=" + oUsuario.IdUsuario;

            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                contraseña = row.Table.Columns.Contains("contraseña") ? row["contraseña"].ToString() : null,
                Perfil = new Perfil()
                {
                    IdPerfil = Convert.ToInt32(row["id_perfil"].ToString()),
                    Nombre = row["perfil"].ToString(),
                }
            };

            return oUsuario;
        }
    }

}

