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
    public class ADDescuento
    {
        public Descuento getDescuentoPorID(int idDescuento)
        {
            var strSql = String.Concat("SELECT des.descuento, des.porcentaje ",
                                      " FROM Descuento des ",
                                       "WHERE des.idDescuento = " + idDescuento.ToString());
            return agregarAGrilla(ConexionBD.GetConexionBD().ConsultaSQL(strSql).Rows[0]);
        }

        public IList<Descuento> GetDescuentoConFiltro(Dictionary<string, object> parametros)
        {
            List<Descuento> listado = new List<Descuento>();

            var strSql = String.Concat("SELECT des.descuento, des.porcentaje ",
                                      "FROM Descuento des ",
                                       "WHERE 1=1");
            
            if (parametros.ContainsKey("descripcion"))
                strSql += " AND (des.descripcion=@descripcion) ";
            if (parametros.ContainsKey("porcentaje"))
                strSql += " AND (des.porcentaje=@porcentaje) ";

            var resultadoConsulta = (DataRowCollection)ConexionBD.GetConexionBD().ConsultaSQLConParametros(strSql, parametros).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listado.Add(agregarAGrilla(row));
            }

            return listado;
        }

        public IList<Descuento> GetDescuentoFiltrosCondicion(String condiciones)
        {
            List<Descuento> listado = new List<Descuento>();
            String sqlcondiciones = condiciones;

            var strSql = String.Concat("SELECT des.descuento, des.porcentaje ",
                                      "FROM Descuento des ",
                                       "WHERE 1=1");

            strSql += sqlcondiciones;

            //sin parametros


            var resultadoConsulta = (DataRowCollection)ConexionBD.GetConexionBD().ConsultaSQL(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listado.Add(agregarAGrilla(row));
            }

            return listado;
        }

        private Descuento agregarAGrilla(DataRow row)
        {
            Descuento descuento = new Descuento();
            descuento.IdDescuento = Convert.ToInt32(row["id_tipo_doc_diri"].ToString());
            descuento.Porcentaje = Convert.ToInt32(row["nro_doc_diri"].ToString());
            descuento.Descripcion = row["nombre"].ToString();

            return descuento;
        }
    }

}
