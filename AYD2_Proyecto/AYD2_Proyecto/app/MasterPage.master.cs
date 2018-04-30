using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["cuenta"] == null)
        {
            li_login.Visible = true;
            li_registro.Visible = true;
            li_perfil.Visible = false;
        }
        else
        {
            li_login.Visible = false;
            li_registro.Visible = false;
            li_perfil.Visible = true;
        }
    }
}
