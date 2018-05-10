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

        public static bool Login(string cuenta, string password)
        {
            SqlConnection con = conectar();
            con.Open();
            string query = "SELECT COUNT(*) FROM Usuario WHERE No_Cuenta = '" + cuenta + "' and contra = '" + password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string resultado = cmd.ExecuteScalar().ToString();

            if(resultado == "1")
            {
                query = "SELECT Nombre, Apellidos, DPI, No_Cuenta, Saldo, correo, contra FROM Usuario WHERE No_Cuenta = '" + cuenta + "' and contra = '" + password + "'";
                cmd = new SqlCommand(query, con);
                using(SqlDataReader reader = cmd.ExecuteReader())
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
