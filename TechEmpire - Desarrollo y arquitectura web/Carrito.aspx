<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; justify-content:space-around">

    <div style="display: flex; flex-direction: column">

        <asp:Repeater ID="rptCarrito" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Producto.Nombre") %></h5>
                    <p class="card-text">Precio: $<%# Eval("PrecioVenta") %></p>
                    <p class="card-text">Cantidad: <%# Eval("Cantidad") %></p>
                    <img src='<%# Eval("Producto.ImgUrl") %>' alt="Imagen producto" class="card-img-top" style="max-height:150px;object-fit:cover;" />
                    <br />
                    <br />
                    <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="btn btn-success" CommandArgument='<%# Eval("CodProducto") %>' OnClick="btnSumar_Click" />
                    <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="btn btn-danger" CommandArgument='<%# Eval("CodProducto") %>' OnClick="btnRestar_Click" />
                </div>
            </div>
        </ItemTemplate>
        </asp:Repeater>
    </div>

    <div style="display: flex; flex-direction: column; gap:1em">
        <h1>Detalle de compra</h1>
        <asp:Label ID="lblCant" runat="server" Text="Cantidad comprada: 0"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="Monto total: 0"></asp:Label>
        <asp:Button ID="btnRegistrarVenta" runat="server" Text="Comprar" CssClass="btn btn-success" style="width: 300px; padding: 1em" OnClick="btnRegistrarVenta_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-warning" style="width: 300px; padding: 1em" OnClick="btnCancelar_Click" />
    </div>
        
    </div>


</asp:Content>
