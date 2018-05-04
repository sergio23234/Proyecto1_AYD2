<%@ Page Language="C#" MasterPageFile="~/app/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="app_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>Registro</h1>
    <br />
    
    <div style="width: 590px">
        <asp:Label runat="server"><h3>Nombres</h3></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server">

        </asp:TextBox><br /><br />

        <asp:Label runat="server"><h3>Apellidos</h3></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server">

        </asp:TextBox><br /><br />

        <asp:Label runat="server"><h3>DPI</h3></asp:Label>
        <asp:TextBox ID="txtDPI" textmode="Number" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server"><h3>Saldo Inicial</h3></asp:Label>
        <asp:TextBox ID="txtSaldo" textmode="Number" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server"><h3>Correo</h3></asp:Label>
        <asp:TextBox ID="txtCorreo" textmode="Email" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server"><h3>Contraseña</h3></asp:Label>
        <asp:TextBox ID="txtContra" textmode="Password" runat="server">

        </asp:TextBox><br /><br />

        <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
        <br />
    </div>

    
    <!--<asp:Label id="lb_error" style="color=red" runat="server"><%:Session["error_login"]%></asp:Label>-->
    
</asp:Content>