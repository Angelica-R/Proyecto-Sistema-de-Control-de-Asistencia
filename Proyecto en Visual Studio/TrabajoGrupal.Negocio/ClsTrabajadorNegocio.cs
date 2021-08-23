using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TrabajoGrupal.AccesoDatos;
using TrabajoGrupal.Entidad;


namespace TrabajoGrupal.Negocio
{
    public class ClsTrabajadorNegocio
    {
        public static DataTable Listar()
        {
            ClsTrabajadorDatos objTrabajador = new ClsTrabajadorDatos();
            return objTrabajador.Listar();
        }

        public static string Insertar(string Nombre, string Apellido, string Dni, string Rol, string Clave)
        {
            ClsTrabajadorDatos objTrabajador = new ClsTrabajadorDatos();

            ClsTrabajadorEntidad objEntiTrabajador = new ClsTrabajadorEntidad();

            objEntiTrabajador.Nombre = Nombre;
            objEntiTrabajador.Apellido = Apellido;
            objEntiTrabajador.DNI = Dni;
            objEntiTrabajador.Rol = Rol;
            objEntiTrabajador.Clave = Clave;  
            return objTrabajador.Insertar(objEntiTrabajador);

        }

        public static string Modificar(int ID, string Nombre, string Apellido, string Dni, string Rol, string Clave)
        {
            ClsTrabajadorDatos objTrabajador = new ClsTrabajadorDatos();

            ClsTrabajadorEntidad objEntiTrabajador = new ClsTrabajadorEntidad();

            objEntiTrabajador.Id_Trabajador = ID;
            objEntiTrabajador.Nombre = Nombre;
            objEntiTrabajador.Apellido = Apellido;
            objEntiTrabajador.DNI = Dni;
            objEntiTrabajador.Rol = Rol;
            objEntiTrabajador.Clave = Clave;
            return objTrabajador.Modificar(objEntiTrabajador);

        }


        public static string Eliminar(int ID)
        {
            ClsTrabajadorDatos objTrabajador = new ClsTrabajadorDatos();
            return objTrabajador.Eliminar(ID);
        }

        public static DataTable Loguin(string Usuario, string clave)
        {
            ClsTrabajadorDatos objTrabajador = new ClsTrabajadorDatos();
            return objTrabajador.Loguin(Usuario, clave);
        }


    }
}
