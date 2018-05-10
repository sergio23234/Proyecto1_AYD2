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
        private static String cadena_conexion = "Server=tcp:grupo7proyecto.database.windows.net,1433;Initial Catalog=Proyecto;Persist Security Info=False;User ID=\"Adming7\";Password=\"Ayd2Grupo7\";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static SqlConnection conectar()
        {
            SqlConnection con = new SqlConnection(cadena_conexion);
            return con;
        }

        public static bool login(string cuenta, string password)
        {
            SqlConnection con = conectar();
            con.Open();
            string query = "SELECT COUNT(*) FROM Usuario WHERE Cuenta = '" + cuenta + "' and Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string resultado = cmd.ExecuteScalar().ToString();

            if(resultado == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
