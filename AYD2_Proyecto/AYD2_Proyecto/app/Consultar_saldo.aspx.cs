using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class app_Login : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["nombres"] = "Carminia Elizabeth";
        //Session["apellidos"] = "Fuentes Patzán";
        //Session["cuenta"] = "201020967";
        //Session["saldo"] = "123456";
        txt_cuenta.Text = Session["cuenta"].ToString();
        txt_saldo.Text = Session["saldo"].ToString();
    }
    
    
}