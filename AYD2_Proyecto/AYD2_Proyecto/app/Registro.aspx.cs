using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class app_Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        // Verificar que vengan todos los campos necesarios!
        if(txtNombre.Text == "" || txtApellido.Text == "" || txtContra.Text == "" || txtDPI.Text == "" || txtSaldo.Text == "" || 
            txtCorreo.Text == "")
        {
            mostrarMensaje("Ingrese todos los datos necesarios e intente nuevamente.");
            return;
        }
        // Aqui se efectua el registro del usuario
        String cuenta = crearCuenta();
        // Mostrar en mensaje que se creo la cuenta si se logro hacer el registro
        if (cuenta != null || cuenta != "")
            mostrarMensaje("Registro exitoso! Su numero de cuenta es: " + cuenta);
        else
            mostrarMensaje("No se pudo realizar el registro!\nIntente nuevamente.");
    }

    public String crearCuenta()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        con.Open();
        string query = "INSERT INTO Usuario (Nombre,Apellido,DPI,Saldo,Correo,Password) VALUES('";
        query += txtNombre.Text + "','";
        query += txtApellido.Text + "','";
        query += txtDPI.Text + "', '";
        query += txtSaldo.Text + "','";
        query += txtCorreo.Text + "','";
        query += txtContra.Text;
        query += "');";
        SqlCommand cmd = new SqlCommand(query, con);
        // Enviar peticion a la base de datos
        cmd.ExecuteNonQuery();

        // Obtener el numero de cuenta creado para el usuario
        query = "SELECT Cuenta FROM Usuario WHERE DPI = '" + txtDPI.Text + "' AND Correo = '" + txtCorreo.Text + "';";
        cmd = new SqlCommand(query, con);
        String cuenta = cmd.ExecuteScalar().ToString();
        return cuenta;
    }

    public void mostrarMensaje(String msj)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msj + "')</script>");
    }
}