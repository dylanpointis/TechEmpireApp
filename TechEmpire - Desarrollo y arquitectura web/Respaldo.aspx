<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldo.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Respaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Respaldo</h1>
        <asp:Button ID="btnRealizarRespaldo" runat="server" Text="Realizar respaldo" OnClick="btnRealizarRespaldo_Click" />
        <br />
         <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    
        <asp:Button ID="btnRestore" runat="server" Text="Restaurar base de datos" OnClick="btnRestore_Click" />
    <br />
</asp:Content>
