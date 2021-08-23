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
    public class ClsTrabajadorDatos
    {
        //Listar
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Trabajador_Listar", sqlCnx);
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
        //Insertar
        public string Insertar(ClsTrabajadorEntidad ObjTrabajador)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Trabajador_Insertar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = ObjTrabajador.Nombre;
                comando.Parameters.Add("@papellido", SqlDbType.VarChar).Value = ObjTrabajador.Apellido;
                comando.Parameters.Add("@pdni", SqlDbType.VarChar).Value = ObjTrabajador.DNI;
                comando.Parameters.Add("@prol", SqlDbType.VarChar).Value = ObjTrabajador.Rol;
                comando.Parameters.Add("@pclave", SqlDbType.VarChar).Value = ObjTrabajador.Clave;

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
        //Modificar
        public string Modificar(ClsTrabajadorEntidad ObjTrabajador)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Trabajador_Modificar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ptrabajador_id", SqlDbType.Int).Value = ObjTrabajador.Id_Trabajador;
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = ObjTrabajador.Nombre;
                comando.Parameters.Add("@papellido", SqlDbType.VarChar).Value = ObjTrabajador.Apellido;
                comando.Parameters.Add("@pdni", SqlDbType.VarChar).Value = ObjTrabajador.DNI;
                comando.Parameters.Add("@prol", SqlDbType.VarChar).Value = ObjTrabajador.Rol;
                comando.Parameters.Add("@pclave", SqlDbType.VarChar).Value = ObjTrabajador.Clave;
                sqlCnx.Open();

                Rpta = comando.ExecuteNonQuery() == 1 ? "OK " : "No se pudo actualizar registro";
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
        //Eliminar
        public string Eliminar(int Id)
        {
            string Rpta = "";

            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Trabajador_Eliminar", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@ptrabajador_id", SqlDbType.Int).Value = Id;
                sqlCnx.Open();

                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar registro";
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


        //Buscar(ID)
        public DataTable Loguin(string dni, string clave)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();
            try
            {
                sqlCnx = ClsConexionDatos.getInstancia().establecerConexion();
                SqlCommand comando = new SqlCommand("SP_Trabajador_EncontrarID", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pdni", SqlDbType.VarChar).Value = dni;
                comando.Parameters.Add("@pclave", SqlDbType.VarChar).Value = clave;

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
