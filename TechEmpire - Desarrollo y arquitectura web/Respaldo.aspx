<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldo.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Respaldo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Respaldo</h1>
        <asp:Button ID="btnRealizarRespaldo" runat="server" Text="Realizar respaldo" OnClick="btnRealizarRespaldo_Click" />
        <input type="file" id="filePicker" webkitdirectory directory runat="server" />
    <br />
</asp:Content>
