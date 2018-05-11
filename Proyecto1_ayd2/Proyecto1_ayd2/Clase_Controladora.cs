using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto1_ayd2
{
    public class Clase_Controladora
    {
        private static String cadena_conexion = "Server=tcp:grupo7proyecto.database.windows.net,1433;Initial Catalog=Proyecto;Persist Security Info=False;User ID=Adming7;Password=Ayd2Grupo7.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        //Variables de sesion
        public static string usr_cuenta, usr_password, usr_nombre, usr_apellido, usr_dpi, usr_saldo, usr_correo;        

        private static SqlConnection conectar()
        {
            SqlConnection con = new SqlConnection(cadena_conexion);
            return con;
        }

        /*
         *Metodo para realizar la conexion con la base de datos
         * @cadena es el query a ejecutar
         * retorna un string con la informacion  obtenida
         */
        public static string conectar(String cadena)
        {
            try
            {
                SqlConnection con = conectar();
                con.Open();
                string query = cadena;
                SqlCommand cmd = new SqlCommand(query, con);
                return cmd.ExecuteScalar().ToString();

            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            return "";

        }

        /*
         *variablesSesion para insertar las variables de sesion del login
         * @cuenta el numero para ingresar como usuario 
         * @password para ingresar como usuario 
         */
        public static void variablesSesion(string cuenta, string password)
        {
            try
            {
                SqlConnection con = conectar();
                con.Open();
                string query = "SELECT Nombre, Apellidos, DPI, No_Cuenta, Saldo, correo, contra FROM Usuario WHERE No_Cuenta = '" + cuenta + "' and contra = '" + password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    usr_cuenta = cuenta;
                    usr_password = password;
                    usr_nombre = reader["Nombre"].ToString();
                    usr_apellido = reader["Apellidos"].ToString();
                    usr_dpi = reader["DPI"].ToString();
                    usr_saldo = reader["Saldo"].ToString();
                    usr_correo = reader["correo"].ToString();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            
        }

        public static bool Login(string cuenta, string password)
        {
            SqlConnection con = conectar();
            con.Open();
            string query = "SELECT COUNT(*) FROM Usuario WHERE No_Cuenta = '" + cuenta + "' and contra = '" + password + "'";
            string resultado = conectar(query);

            if (resultado == "1")
            {
                variablesSesion(cuenta, password);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * retornar_saldo()
         * metodo para retornar el saldo del usuario logeado
         */
        public static string Retornar_saldo(String cuenta) {
            string query = "SELECT Saldo FROM Usuario WHERE No_Cuenta = '" + usr_cuenta + "' and contra = '" + usr_password + "'";
            string resultado = conectar(query);
            return resultado;
        }

        /*
         * retornar_nombre()
         * metodo para retornar el nombre y apellido del usuario logeado
         */

        public static string Retornar_nombre(String cuenta)
        {
            string query = "SELECT Nombre FROM Usuario WHERE No_Cuenta = '" + usr_cuenta + "' and contra = '" + usr_password + "'";
            string resultado = conectar(query);
            query = "SELECT Apellido FROM Usuario WHERE No_Cuenta = '" + usr_cuenta + "' and contra = '" + usr_password + "'";
            resultado = resultado + " " + conectar(query);
            return resultado;            
        }

        public static string getNombre()
        {
            return usr_nombre;
        }

        public static string getApellido()
        {
            return usr_apellido;
        }

        public static string getCuenta()
        {
            return usr_cuenta;
        }

        public static string getDpi()
        {
            return usr_dpi;
        }

        public static string getCorreo()
        {
            return usr_correo;
        }

        public static bool validarSaldo(String saldo)
        {
            try
            {
                int valor = Convert.ToInt32(saldo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool validarCorreo(String correo)
        {
            if (correo.Contains("@") && correo.Contains(".com") && correo.Length > 7)
            {
                string[] vals = correo.Split('@');
                if (vals.Length == 2)
                    if (vals[0].Length > 0 && vals[1].Contains(".com") && vals[1].Length > 5)
                        return true;
                return false;
            }
            return false;
        }

        public static string registrarse(string nombre, string apellido, string contra, string dpi, string correo, string saldo)
        {
            try
            {
                SqlConnection con = conectar();
                con.Open();
                string query = "INSERT INTO Usuario (Nombre,Apellidos,DPI,Saldo,Correo,Contra) VALUES('";
                query += nombre + "','";
                query += apellido + "','";
                query += dpi + "','";
                query += saldo + "','";
                query += correo + "','";
                query += contra;
                query += "');";
                SqlCommand cmd = new SqlCommand(query, con);
                // Enviar peticion a la base de datos
                cmd.ExecuteNonQuery();

                // Obtener el numero de cuenta creado para el usuario
                query = "SELECT No_Cuenta FROM Usuario WHERE DPI = '" + dpi + "' AND Correo = '" + correo + "';";
                cmd = new SqlCommand(query, con);
                String cuenta = cmd.ExecuteScalar().ToString();
                return cuenta;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
