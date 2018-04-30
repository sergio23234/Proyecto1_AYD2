using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["cuenta"] = null;
        Session["nombres"] = null;
        Session["apellidos"] = null;
        Session["dpi"] = null;
        Session["password"] = null;
        Session["saldo"] = null;
        Session["correo"] = null;
    }
}