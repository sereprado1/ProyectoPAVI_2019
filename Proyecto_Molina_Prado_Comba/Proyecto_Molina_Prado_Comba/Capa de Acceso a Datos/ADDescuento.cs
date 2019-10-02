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
    public class ADDescuento
    {
        public IList<Descuento> GetDescuento()
        {
            List<Descuento> listadoDescuento = new List<Descuento>();

            String strSql = string.Concat(" SELECT id_descuento, ",
                                          "descripcion, ",
                                          "porcentaje ",

                                          "FROM Descuento ",
                                          "WHERE borrado=0 ");
            var resultadoConsulta = ConexionBD.GetConexionBD().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoDescuento.Add(ObjectMapping(row));
            }

            return listadoDescuento;
        }
        public Descuento GetDescuentoConParametros(string descripcion, float porcentaje)
        {
            String strSql = string.Concat(" SELECT id_descuento, ",
                                          "descripcion, ",
                                          "porcentaje ",
                                          "FROM Descuento ",
                                          "WHERE descripcion =  @descripcion AND borrado=0 ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("descuento", descripcion);
            parametros.Add("porcentaje", porcentaje);
            var resultado = ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);


            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }


        public Descuento GetDescuentoSinParametros(string descripcion)
        {
            String strSql = string.Concat(" SELECT id_descuento, ",
                                          "descripcion, ",
                                          "porcentaje ",
                                          "FROM Descuento ",
                                          "WHERE borrado =0 ");

            strSql += " AND descripcion=" + "'" + descripcion + "'";


            var resultado = ConexionBD.GetConexionBD().ConsultaSQL(strSql);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Descuento> GetConFiltrosConParametros(Dictionary<string, object> parametros)
        {

            List<Descuento> lst = new List<Descuento>();
            String strSql = string.Concat(" SELECT id_descuento, ",
                                          "descripcion, ",
                                          "porcentaje ",
                                              "FROM Descuento ",
                                              "WHERE borrado=0 ");


            if (parametros.ContainsKey("id_descuento"))
                strSql += " AND (id_descuento = @id_descuento) ";

            if (parametros.ContainsKey("porcentaje"))
                strSql += " AND (porcentaje = @porcentaje) ";

            if (parametros.ContainsKey("descripcion"))
                strSql += " AND (descripcion LIKE '%' + @descripcion + '%') ";

            var resultado = ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Descuento> GetConFiltrosSinParametros(String condiciones)
        {

            List<Descuento> lst = new List<Descuento>();
            String strSql = string.Concat(" SELECT id_descuento, ",
                                          " descripcion, ",
                                          " porcentaje ",
                                              "FROM Descuento ",
                                              "WHERE borrado=0 " + condiciones);




            var resultado = ConexionBD.GetConexionBD().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Descuento oDescuento)
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

            string str_sql = "INSERT INTO Descuento (descripcion, porcentaje, borrado)" +
                            " VALUES (" +
                            "'" + oDescuento.Descripcion + "'" + "," +
                            "'" + oDescuento.Porcentaje + "'" + ",0)";

            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        internal bool Update(Descuento oDescuento)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Descuento " +
                             "SET descripcion=" + "'" + oDescuento.Descripcion + "'" + "," +
                             " porcentaje=" + "'" + oDescuento.Porcentaje + "'"  +
                             " WHERE id_descuento=" + oDescuento.IdDescuento;

            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Descuento oDescuento)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Descuento " +
                             "SET borrado=1" +
                             " WHERE id_descuento=" + oDescuento.IdDescuento;

            return (ConexionBD.GetConexionBD().EjecutarSQL(str_sql) == 1);
        }

        private Descuento ObjectMapping(DataRow row)
        {
            Descuento oDescuento = new Descuento
            {
                IdDescuento = Convert.ToInt32(row["id_descuento"].ToString()),
                Descripcion = row["descripcion"].ToString(),
                Porcentaje = Convert.ToSingle(double.Parse(row["porcentaje"].ToString()))
            };

            return oDescuento;
        }
    }

}
