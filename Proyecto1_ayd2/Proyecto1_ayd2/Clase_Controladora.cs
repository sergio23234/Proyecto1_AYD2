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
        public static string retornar_saldo() {
            string query = "SELECT Saldo FROM Usuario WHERE No_Cuenta = '" + usr_cuenta + "' and contra = '" + usr_password + "'";
            string resultado = conectar(query);
            return resultado;           
            
        }

        /*
         * retornar_nombre()
         * metodo para retornar el nombre y apellido del usuario logeado
         */

        public static string retornar_nombre()
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
    }
}
