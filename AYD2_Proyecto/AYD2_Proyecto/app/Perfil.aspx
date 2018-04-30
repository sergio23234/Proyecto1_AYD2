<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="app_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Perfil de Usuario</h1>
    <br />

    <asp:Label runat="server"><h3>No. de Cuenta</h3></asp:Label>
    <p><%:Session["cuenta"] %></p>
    <br />

    <asp:Label runat="server"><h3>Nombres</h3></asp:Label>
    <p><%:Session["nombres"] %></p>
    <br />

    <asp:Label runat="server"><h3>Apellidos</h3></asp:Label>
    <p><%:Session["apellidos"] %></p>
    <br />

    <asp:Label runat="server"><h3>DPI</h3></asp:Label>
    <p><%:Session["dpi"] %></p>
    <br />

    <asp:Label runat="server"><h3>Correo Electronico</h3></asp:Label>
    <p><%:Session["correo"] %></p>    
</asp:Content>

