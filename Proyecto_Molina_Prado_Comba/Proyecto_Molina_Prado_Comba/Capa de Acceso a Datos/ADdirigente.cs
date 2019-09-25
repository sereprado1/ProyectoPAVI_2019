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
using System.Data;
using Proyecto_Molina_Prado_Comba.Clases;

namespace Proyecto_Molina_Prado_Comba.Capa_de_Acceso_a_Datos
{
    public class ADdirigente
    {
        public Dirigente getDirigentePorID(int idTipoDoc, int nroDoc)
        {
            var strSql = String.Concat("SELECT D.id_tipo_doc_diri, ",
                                                "D.nro_doc_diri, ",
                                                "D.nombre, ",
                                                "D.apellido, ",
                                                "D.telefono, ",
                                                "D.direccion, ",
                                                "F.descripcion as funcion, ",
                                                "C.descripcion as comunidad, ",
                                                "R.nombre as rama",
                                      " FROM Dirigente D ",
                                      "INNER JOIN ComunidadXDirigente X ON D.id_tipo_doc_diri = X.id_tipo_doc_diri AND D.nro_doc_diri = X.nro_doc_diri ",
                                      "INNER JOIN Funcion F ON X.id_funcion = F.id_funcion ",
                                      "INNER JOIN Comunidad C on X.id_comunidad = C.id_comunidad ",
                                      "INNER JOIN Rama R on C.id_rama = R.id_rama ",
                                       "WHERE D.borrado=0 AND D.id_tipo_doc_diri = " + idTipoDoc.ToString() + "AND D.nro_doc_diri = " + nroDoc.ToString());
            return agregarAGrilla(ConexionBD.GetConexionBD().ConsultaSQL(strSql).Rows[0]);
        }

        public IList<Dirigente> GetDirigentesConFiltro(Dictionary<string, object> parametros)
        {
            List<Dirigente> listado = new List<Dirigente>();

            var strSql = String.Concat("SELECT D.id_tipo_doc_diri, ",
                                                "D.nro_doc_diri, ",
                                                "D.nombre, ",
                                                "D.apellido, ",
                                                "D.telefono, ",
                                                "D.direccion, ",
                                                "F.descripcion as funcion, ",
                                                "C.descripcion as comunidad, ",
                                                "R.nombre as rama",
                                      " FROM Dirigente D ",
                                      "INNER JOIN ComunidadXDirigente X ON D.id_tipo_doc_diri = X.id_tipo_doc_diri AND D.nro_doc_diri = X.nro_doc_diri ",
                                      "INNER JOIN Funcion F ON X.id_funcion = F.id_funcion ",
                                      "INNER JOIN Comunidad C on X.id_comunidad = C.id_comunidad ",
                                      "INNER JOIN Rama R on C.id_rama = R.id_rama ",

                                       "WHERE D.borrado=0 AND 1=1");

            
            if (parametros.ContainsKey("nombre"))
                strSql += " AND (D.nombre=@nombre) ";
            if (parametros.ContainsKey("apellido"))
                strSql += " AND (D.apellido=@apellido) ";
            if (parametros.ContainsKey("idFuncion"))
                strSql += " AND (X.id_funcion=@idFuncion) ";
            
            var resultadoConsulta = (DataRowCollection)ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listado.Add(agregarAGrilla(row));
            }

            return listado;
        }

        public IList<Dirigente> GetDirigentesFiltrosCondicion(String condiciones)
        {
            List<Dirigente> listado = new List<Dirigente>();
            String sqlcondiciones = condiciones;

            var strSql = String.Concat("SELECT D.id_tipo_doc_diri, ",
                                                "D.nro_doc_diri, ",
                                                "D.nombre, ",
                                                "D.apellido, ",
                                                "D.telefono, ",
                                                "D.direccion, ",
                                                "F.descripcion as funcion, ",
                                                "C.descripcion as comunidad, ",
                                                "R.nombre as rama",
                                      " FROM Dirigente D ",
                                      "INNER JOIN ComunidadXDirigente X ON D.id_tipo_doc_diri = X.id_tipo_doc_diri AND D.nro_doc_diri = X.nro_doc_diri ",
                                      "INNER JOIN Funcion F ON X.id_funcion = F.id_funcion ",
                                      "INNER JOIN Comunidad C on X.id_comunidad = C.id_comunidad ",
                                      "INNER JOIN Rama R on C.id_rama = R.id_rama ",

                                       "WHERE D.borrado=0 AND 1=1 ");

            strSql += sqlcondiciones;

            //sin parametros


            var resultadoConsulta = (DataRowCollection)ConexionBD.GetConexionBD().ConsultaSQL(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listado.Add(agregarAGrilla(row));
            }

            return listado;
        }

        private Dirigente agregarAGrilla(DataRow row)
        {
            Dirigente dirigente = new Dirigente();
            dirigente.TipoDocumento = Convert.ToInt32(row["id_tipo_doc_diri"].ToString());
            dirigente.NumeroDocumento = Convert.ToInt32(row["nro_doc_diri"].ToString());
            dirigente.Nombre = row["nombre"].ToString();
            dirigente.Apellido = row["apellido"].ToString();
            dirigente.Telefono = row["telefono"].ToString();
            dirigente.Direccion = row["Direccion"].ToString();

            dirigente.funcion = new Funcion();
            dirigente.funcion.Descripcion = row["funcion"].ToString();

            dirigente.Comunidad = new Comunidad();
            dirigente.Comunidad.Descripcion = row["comunidad"].ToString();

            dirigente.rama = new Rama();
            dirigente.rama.Nombre = row["rama"].ToString();

            return dirigente;
        }
    }
}
