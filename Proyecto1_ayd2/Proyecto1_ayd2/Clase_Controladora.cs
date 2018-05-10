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
        private static String cuentaUsuario = "";
        private static String passwordUsuario ="";

        private static SqlConnection conectar()
        {
            SqlConnection con = new SqlConnection(cadena_conexion);
            return con;
        }

        public static bool login(string cuenta, string password)
        {
            SqlConnection con = conectar();
            con.Open();
            string query = "SELECT COUNT(*) FROM Usuario WHERE No_Cuenta = '" + cuenta + "' and contra = '" + password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string resultado = cmd.ExecuteScalar().ToString();

            if(resultado == "1")
            {
                cuentaUsuario = cuenta;
                passwordUsuario = password;
                return true;
            }
            else
            {
                return false;
            }
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
         * retornar_saldo()
         * metodo para retornar el saldo del usuario logeado
         */
        public static string retornar_saldo() {

            string query = "SELECT Saldo FROM Usuario WHERE No_Cuenta = '" + cuentaUsuario + "' and contra = '" + passwordUsuario + "'";
            return conectar(query);           
            
        }

        /*
         * retornar_nombre()
         * metodo para retornar el nombre y apellido del usuario logeado
         */

        public static string retornar_nombre()
        {

            string query = "SELECT Nombre, Apellidos FROM Usuario WHERE No_Cuenta = '" + cuentaUsuario + "' and contra = '" + passwordUsuario + "'";
            return conectar(query);
        }

    }
}
