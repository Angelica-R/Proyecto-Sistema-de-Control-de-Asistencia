using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoGrupal.Entidad;
using TrabajoGrupal.AccesoDatos;


namespace TrabajoGrupal.Negocio
{
    public class ClsTablaAsistenciaNegocio
    {
        //Listar
        public static string Insertar(string Fecha, string Hora)
        {
            ClsTablaAsistenciaDatos objAsistencia = new ClsTablaAsistenciaDatos();

            //string Verificar = objAsistencia.Verificar(Fecha);

            DataTable Tabla = new DataTable();
            Tabla= objAsistencia.Verificar(Fecha);

            if (Tabla.Rows.Count <= 0)
            {
                
                ClsTablaAsistenciaEntidad objEntiAsistencia = new ClsTablaAsistenciaEntidad();
                objEntiAsistencia.Fecha = Fecha;
                objEntiAsistencia.Hora = Hora;

                return objAsistencia.Insertar(objEntiAsistencia);
            }
            else
            {
                return "La fecha ya fue generada";
            }



        }

        public static int FechaActualC()
        {
            ClsTablaAsistenciaDatos objAsistencia = new ClsTablaAsistenciaDatos();
            return objAsistencia.FechaActualC();
        }

        public static DataTable Buscar_Fecha(string Busqueda)
        {
            ClsTablaAsistenciaDatos objAsistencia = new ClsTablaAsistenciaDatos();
            return objAsistencia.Buscar_Fecha(Busqueda);
        }

        public static DataTable Buscar_EncontrarFecha(int Busqueda)
        {
            ClsTablaAsistenciaDatos objAsistencia = new ClsTablaAsistenciaDatos();
            return objAsistencia.Buscar_EncontrarFecha(Busqueda);
        }


    }
}
