using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class app_Transaccion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string query = "SELECT Cuenta, CONCAT(Cuenta, ' - ', Nombre, ' ', Apellido) AS 'Datos' FROM Usuario WHERE Cuenta != '" + Session["cuenta"] + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        ddlist.DataSource = cmd.ExecuteReader();
        ddlist.DataTextField = "Datos";
        ddlist.DataValueField = "Cuenta";
        ddlist.DataBind();
    }

    protected void bttrans_Click(object sender, EventArgs e)
    {

    }
}