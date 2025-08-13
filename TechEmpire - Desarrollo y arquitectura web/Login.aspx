<%@ Page Title="Inicio de sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div  id="login" runat="server" class="form-group d-flex flex-column gap-3"> 
        <div class="d-flex flex-column">
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-flex flex-column">
            <asp:Label ID="lblClave" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        
            <asp:RequiredFieldValidator
                controltovalidate="txtClave"
                text="Debe escribir la contraseña"
                display="Dynamic"
                runat="server"
                ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                controltovalidate="txtClave"
                text="Su password debe contener entre 3 y 20 caracteres"
                validationexpression="\w{3,20}"
                runat="server"
                ></asp:RegularExpressionValidator>

             <asp:RegularExpressionValidator
             controltovalidate="txtClave"
             text="Su password debe contener al menos 1 numero y un caracter"
             validationexpression="[a-zA-Z]+\w*\d+\w*"
             runat="server"
             ></asp:RegularExpressionValidator>
        
        
        </div>
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary"  OnClick="btnLogin_Click" />
            <br />
            <p>¿No tienes una cuenta?</p>
            <asp:Button ID="btnRegistrar" runat="server" Text="Crear cuenta" CssClass="btn btn-success"  OnClick="btnRegistrar_Click" />
            <br />
            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>