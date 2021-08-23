using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoGrupal.Entidad;

namespace TrabajoGrupal.AccesoDatos
{
    public class ClsHojaDatos
    {
        //Insertar
        public string Insertar(ClsHojaEntidad ObjHoja)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Hoja_Insertar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pAsistencia_id", SqlDbType.Int).Value = ObjHoja.ID_Asistencia;
                comando.Parameters.Add("@pTrabajador_id", SqlDbType.Int).Value = ObjHoja.ID_Trabajador;
                comando.Parameters.Add("@pestado", SqlDbType.VarChar).Value = ObjHoja.Estado;
                comando.Parameters.Add("@phora", SqlDbType.VarChar).Value = ObjHoja.Hora;

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

        public string Asistencia_ACT(int ID_Asistencia,int ID_Trabajador,string Hora)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion(); SqlCommand comando = new SqlCommand("SP_Hoja_Asistir", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pAsistencia_id", SqlDbType.Int).Value = ID_Asistencia;
                comando.Parameters.Add("@pTrabajador_id", SqlDbType.Int).Value = ID_Trabajador;
                comando.Parameters.Add("@phora", SqlDbType.VarChar).Value = Hora;
                sqlCnx.Open();

                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar registro";
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


        public string Verificar_Hoja(int ID_Asistencia, int ID_Trabajador)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion(); SqlCommand comando = new SqlCommand("SP_Hoja_Verificar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pId_Asistencia", SqlDbType.Int).Value = ID_Asistencia;
                comando.Parameters.Add("@pId_Trabajador", SqlDbType.Int).Value = ID_Trabajador;

                sqlCnx.Open();

                Rpta = Convert.ToString(comando.ExecuteScalar());
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


    }
}
