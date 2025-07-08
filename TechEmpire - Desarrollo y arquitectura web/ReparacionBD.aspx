<%@ Page Title="Reparación de base de datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReparacionBD.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.ReparacionBD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style= "font-size: 40px; text-align: center"><b>
        Inconsistencia encontrada en la base de datos.
        <br />
        <br />
        Tablas afectadas:
    </b></p>

    <asp:Label ID="lblTablaAfectada" runat="server" Text="-" Font-Bold="true" style="text-align: center; display: block; width: 100%; font-size: 40px"></asp:Label>
    <asp:Button  ID="btnRecalcular" runat="server" Text="Recalcular dígito verificador" style="display: block; font-size: 20px; margin:20px auto; width:100%; padding: 10px"  OnClick="btnRecalcular_Click" Width="698px" CssClass="btn btn-primary"/>
    <asp:Button ID="btnSalir" runat="server" Text="Volver a inicio de sesión"  style="display: block; font-size: 20px; margin: 20px auto; width: 100%; padding: 10px " OnClick="btnSalir_Click" CssClass="btn btn-danger" />
</asp:Content>
