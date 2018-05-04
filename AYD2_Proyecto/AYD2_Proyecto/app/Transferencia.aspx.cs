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
        con.Close();

        if (!this.IsPostBack)
        {
            Session["error_transferencia"] = null;
        }
    }

    protected void bttrans_Click(object sender, EventArgs e)
    {
        double monto;
        if (txtMonto.Text == "")
        {
            monto = 0;
        }
        else
        {
            monto = Convert.ToDouble(txtMonto.Text);
        }

        string cuenta_destino = ddlist.SelectedValue.ToString();

        System.Diagnostics.Debug.WriteLine(cuenta_destino + " - " + monto.ToString());

        if (monto > Convert.ToDouble(Session["saldo"].ToString()))
        {
            Session["error_transferencia"] = "Error. No se cuenta con los fondos suficientes para realizar la transferencia.";            
            //Response.Redirect("~/app/Transferencia.aspx");
        }
        else
        {
            transferir_monto(monto, cuenta_destino);

            descontar_monto(monto);
        }
    }

    private void transferir_monto(double monto, string cuenta_destino)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string query = "UPDATE Usuario SET saldo = saldo + " + monto + " WHERE Cuenta = '" + cuenta_destino + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteScalar();
        con.Close();
    }

    private void descontar_monto(double monto)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string query = "UPDATE Usuario SET saldo = saldo - " + monto + " WHERE Cuenta = '" + Session["cuenta"] + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteScalar();

        Session["saldo"] = (Convert.ToDouble(Session["saldo"].ToString()) - monto).ToString();

        Session["error_transferencia"] = "Transferencia realizada con exito.";
        txtMonto.Text = "";

        con.Close();
    }
}