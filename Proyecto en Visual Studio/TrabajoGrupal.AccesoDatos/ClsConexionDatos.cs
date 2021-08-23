using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrabajoGrupal.Entidad;

namespace TrabajoGrupal.AccesoDatos
{
    class ClsConexionDatos
    {
        private string BD;
        private string Server;
        private string User;
        private string Clave;
        private bool Autenticacion;
        private static ClsConexionDatos cnx = null;

        private ClsConexionDatos()
        {
            BD = "bdAsistencia";
            Server = "DESKTOP-JK1RRAU";
            User = "sa";
            Clave = "2110";
            Autenticacion = true;

        }

        public SqlConnection establecerConexion()
        {
            SqlConnection url = new SqlConnection();
            try
            {
                url.ConnectionString = "Server=" + Server + ";" +
                    "Database=" + BD + ";";
                if (Autenticacion == true)
                {
                    url.ConnectionString += "Integrated Security = SSPI";
                }
                else
                {
                    url.ConnectionString += "User Id=" + User + ";" + "Password=" + Clave;
                }
            }
            catch (Exception ex)
            {
                url = null;
                throw ex;
            }

            return url;
        }

        public static ClsConexionDatos getInstancia()
        {
            if (cnx == null)
            {
                cnx = new ClsConexionDatos();
            }
            return cnx;
        }
    }
}
