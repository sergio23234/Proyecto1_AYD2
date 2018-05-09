using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Manejo
/// </summary>
public class Manejo
{
    public Manejo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //

    }
    public String Verificar_Usuario(String Cuenta, String contra)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string query = "SELECT COUNT(*) FROM Usuario WHERE Cuenta = '" + Cuenta + "' and Password = '" + contra + "'";
        SqlCommand cmd = new SqlCommand(query, con);
        String resultado = cmd.ExecuteScalar().ToString();
        con.Close();
        return resultado;
    }
}