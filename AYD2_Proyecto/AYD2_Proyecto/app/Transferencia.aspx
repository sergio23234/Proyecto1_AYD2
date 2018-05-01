<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.master" AutoEventWireup="true" CodeFile="Transferencia.aspx.cs" Inherits="app_Transaccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Transferencia Monetaria</h1>
    <br />

    <asp:Label runat="server"><h3>Seleccione la cuenta destino:</h3></asp:Label>
    <asp:DropDownList runat="server" ID="ddlist"></asp:DropDownList>
    <br /><br />
    
    <asp:Button ID="bttrans" runat="server" Text="Aceptar" OnClick="bttrans_Click"/>
    <br />


</asp:Content>

