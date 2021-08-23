using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoGrupal.Entidad;

namespace TrabajoGrupal.AccesoDatos
{
    public class ClsTablaAsistenciaDatos
    {
        //Insertar
        public string Insertar(ClsTablaAsistenciaEntidad ObjAsistencia)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Asistencia_Insertar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pfecha", SqlDbType.VarChar).Value = ObjAsistencia.Fecha;
                comando.Parameters.Add("@phora", SqlDbType.VarChar).Value = ObjAsistencia.Hora;
                

                sqlCnx.Open();

                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;

            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                    sqlCnx.Close();
            }
            return Rpta;
        }
        //
        public int FechaActualC()
        {

            int Rpta;
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Asistencia_FechaActual", sqlCnx);
                sqlCnx.Open();
                Rpta = Convert.ToInt32(comando.ExecuteScalar());
                return Rpta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                    sqlCnx.Close();
            }

        }
        //Buscar Fecha Alterna
        public DataTable Buscar_Fecha(string Busqueda)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Asistencia_BuscarFechaAlterna", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pbusqueda", SqlDbType.VarChar).Value = Busqueda;
                sqlCnx.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                    sqlCnx.Close();
            }

        }

        //Encontrar Fecha
        public DataTable Buscar_EncontrarFecha(int Busqueda)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Asistencia_EncontrarFecha", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid", SqlDbType.Int).Value = Busqueda;

                sqlCnx.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                    sqlCnx.Close();
            }

        }


        //Verificar
        public DataTable Verificar(string Busqueda)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Asistencia_Verificar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pfecha", SqlDbType.VarChar).Value = Busqueda;

                sqlCnx.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                    sqlCnx.Close();
            }

        }

    }
}
