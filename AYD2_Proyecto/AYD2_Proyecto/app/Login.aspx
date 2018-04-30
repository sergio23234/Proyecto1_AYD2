<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="app_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>Log In</h1>
    <br />
    
    <asp:Label runat="server"><h3>No. de Cuenta</h3></asp:Label>
    <asp:TextBox ID="txtcuenta" runat="server">

    </asp:TextBox><br /><br />

    <asp:Label runat="server"><h3>Password</h3></asp:Label>
    <asp:TextBox ID="txtpassword" textmode="Password" runat="server">

    </asp:TextBox><br /><br />

    <asp:Button ID="btentrar" runat="server" Text="Entrar" OnClick="btentrar_Click" />
    
</asp:Content>

