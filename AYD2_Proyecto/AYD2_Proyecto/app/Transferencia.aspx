<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.master" AutoEventWireup="true" CodeFile="Transferencia.aspx.cs" Inherits="app_Transaccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Transferencia Monetaria</h1>
    <br />

    <asp:Label><h3>Saldo Actual:</h3></asp:Label>
    <p>Q. <%:Session["saldo"] %></p>
    <br />

    <asp:Label><h3>Monto a transferir:</h3></asp:Label>
    <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="regex1" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$" ErrorMessage="Debe ingresar un monto valido. Solo se permiten numeros con un max. de 2 decimales." ControlToValidate="txtMonto"></asp:RegularExpressionValidator>
    <br /><br />

    <asp:Label runat="server"><h3>Seleccione la cuenta destino:</h3></asp:Label>
    <asp:DropDownList runat="server" ID="ddlist"></asp:DropDownList>
    <br /><br />
    
    <asp:Button ID="bttrans" runat="server" Text="Aceptar" OnClick="bttrans_Click"/>
    <br />
    <asp:Label ID="lb_error" runat="server"><%:Session["error_transferencia"] %></asp:Label>


</asp:Content>

