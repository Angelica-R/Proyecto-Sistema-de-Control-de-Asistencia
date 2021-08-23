using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoGrupal.Entidad;
using TrabajoGrupal.AccesoDatos;
using System.Data;

namespace TrabajoGrupal.Negocio
{
    public class ClsHojaNegocio
    {
  
        public static string Insertar(int id_Asistencia, int id_Trabajador, string estado, string hora)
        {
            ClsHojaDatos objHoja= new ClsHojaDatos();

            ClsHojaEntidad objEntiHoja = new ClsHojaEntidad();

            objEntiHoja.ID_Asistencia= id_Asistencia;
            objEntiHoja.ID_Trabajador = id_Trabajador;
            objEntiHoja.Estado = estado;
            objEntiHoja.Hora = hora;

            return objHoja.Insertar(objEntiHoja);

        }

        public static string Asistencia_ACT(int ID_Asistencia, int ID_Trabajador, string Hora)
        {
            ClsHojaDatos objHoja = new ClsHojaDatos();


            return objHoja.Asistencia_ACT(ID_Asistencia, ID_Trabajador, Hora);
        }


        public static string Verificar_Hoja(int ID_Asistencia, int ID_Trabajador)
        {
            ClsHojaDatos objHoja = new ClsHojaDatos();


            return objHoja.Verificar_Hoja(ID_Asistencia, ID_Trabajador);
        }



    }
        
}
