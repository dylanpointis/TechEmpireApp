<%@ Page Title="Auditoría de eventos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuditoriaEventos.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.AuditoriaEventos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <main>

        <asp:GridView ID="gvEventos" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField DataField="CodEvento" HeaderText="Código" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Modulo" HeaderText="Módulo" />
                <asp:BoundField DataField="evento" HeaderText="Evento" />
                <asp:BoundField DataField="Criticidad" HeaderText="Criticidad" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" ControlStyle-Width="100px" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" />
            </Columns>
        </asp:GridView>
    
            <div style="display: flex; gap: 3em">

                <div>
                    <p>Fecha inicio:</p>
                    <asp:Calendar ID="calendariofechaInicio" runat="server" CssClass=""></asp:Calendar>
                </div>
                
                <div>
                     <p>Fecha fin:</p>
                     <asp:Calendar ID="calendariofechaFin" runat="server"></asp:Calendar>
                </div>
            </div>
           <br />
           <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" />
           


       </main>
</asp:Content>
