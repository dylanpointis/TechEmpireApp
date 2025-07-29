<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldo.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Respaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Respaldo y restauración de base de datos </h1>
        <label>Backup</label>
        <br />
        <asp:Button ID="btnRealizarRespaldo" runat="server" Text="Realizar respaldo" OnClick="btnRealizarRespaldo_Click" CssClass="btn btn-success" />
        <br />
        <br />
        <label>Restaurar</label>
        <br />
         <asp:FileUpload ID="FileUpload1" runat="server"  />
    
        <asp:Button ID="btnRestore" runat="server" Text="Restaurar base de datos" OnClick="btnRestore_Click" CssClass="btn btn-primary"/>
        <br />
        
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>
