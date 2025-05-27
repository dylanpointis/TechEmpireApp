<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Logout" %>

<%--<!DOCTYPE html>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <main>

        <asp:Label ID="Label1" runat="server" Style="margin-left: 60px;" Text="¿Estás seguro de que deseas cerrar sesión?"></asp:Label>
        <br /><br />
        <asp:Button ID="btnCerrar" runat="server" Style="margin-left: 20px;" Text="Cerrar sesión" OnClick="btnCerrar_Click" CssClass="btn btn-danger" />
        <asp:Button ID="btnCancelar" runat="server" Style="margin-left: 20px;" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-light" />
    
   </main>
</asp:Content>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Style="margin-left: 60px;" Text="¿Estás seguro de que deseas cerrar sesión?"></asp:Label>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Style="margin-left: 20px;" Text="Cerrar sesión" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Style="margin-left: 20px;" Text="Mantener sesión iniciada" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>--%>
