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

    }

    protected void btentrar_Click(object sender, EventArgs e)
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        //con.Open();
        //string query = "SELECT COUNT(*) FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
        //SqlCommand cmd = new SqlCommand(query, con);
        Manejo man = new Manejo();
        string resultado = man.Verificar_Usuario(txtcuenta.Text,txtpassword.Text);

        if (resultado == "1")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            String query;
            SqlCommand cmd;
            String nombres, apellidos, cuenta, dpi, saldo, correo, password;

            query = "SELECT Nombre FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            nombres = cmd.ExecuteScalar().ToString();

            query = "SELECT Apellido FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            apellidos = cmd.ExecuteScalar().ToString();

            query = "SELECT DPI FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            dpi = cmd.ExecuteScalar().ToString();

            query = "SELECT Saldo FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            saldo = cmd.ExecuteScalar().ToString();

            query = "SELECT Correo FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            correo = cmd.ExecuteScalar().ToString();

            query = "SELECT Password FROM Usuario WHERE Cuenta = '" + txtcuenta.Text + "' and Password = '" + txtpassword.Text + "'";
            cmd = new SqlCommand(query, con);
            password = cmd.ExecuteScalar().ToString();

            cuenta = txtcuenta.Text;

            con.Close();

            Session["cuenta"] = cuenta;
            Session["nombres"] = nombres;
            Session["apellidos"] = apellidos;
            Session["dpi"] = dpi;
            Session["password"] = password;
            Session["saldo"] = saldo;
            Session["correo"] = correo;
            Session["error_login"] = null;
            Response.Write("<script>alert('Bienvenido " + nombres + " " + apellidos +"');</script>");
            Response.Redirect("~/app/Perfil.aspx");
        }
        else
        {
            Session["cuenta"] = null;
            Session["nombres"] = null;
            Session["apellidos"] = null;
            Session["dpi"] = null;
            Session["password"] = null;
            Session["saldo"] = null;
            Session["correo"] = null;
                     
            Session["error_login"] = "Error. No. de cuenta o password incorrecto.";
            Response.Redirect("~/app/Login.aspx");
        }
    }

}