<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reuniones.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Reuniones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Reuniones</h1>
    <br />
    <h2>Seleccionar fecha de la reunión</h2>
    <br />


    <asp:Calendar ID="Calendar1" runat="server"
        selectionmode ="Day"
        ondayrender="Calendar1_DayRender"
        onselectionchanged="Calendar1_SelectionChanged">
    </asp:Calendar>

    <asp:Label ID="lblFechas" runat="server" Text="">

    </asp:Label>

    <br />
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar selección" OnClick="btnConfirmar_Click" CssClass="btn btn-primary" />

</asp:Content>
