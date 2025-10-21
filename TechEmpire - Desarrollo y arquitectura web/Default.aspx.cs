using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using System.Xml;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class _Default : Page
    {
        private BLLProducto bllProd = new BLLProducto();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<BEProducto> listaProductos = bllProd.TraerListaProducto();
            if (!IsPostBack)
            {

                rptProductos.DataSource = listaProductos;
                rptProductos.DataBind();


                BEUsuario user = Session["User"] as BEUsuario;
                if (user != null)
                {
                    lblUser.Text = $"Bienvenido {user.Rol.NombreRol}: {user.NombreUsuario}";
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/About.aspx");
        }



        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int codigoProducto = int.Parse(btn.CommandArgument);

            // Obtener el producto desde la lista original
            BEProducto productoSeleccionado = bllProd.TraerListaProducto()
                                                     .FirstOrDefault(p => p.CodigoProducto == codigoProducto);

            BEVenta ventaActual;
            if (Session["VentaActual"] == null)
            {
                ventaActual = new BEVenta();
                Session["VentaActual"] = ventaActual;
            }
            else
            {
                ventaActual = Session["VentaActual"] as BEVenta;
            }


            ventaActual.CodVenta = 0;
            if (productoSeleccionado != null)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Producto {productoSeleccionado.Nombre} agregado al carrito');", true);

                int cantidad = 1;;
                ventaActual.AgregarItem(ventaActual, productoSeleccionado, cantidad);
                
                //Ejercicio B XmlTextWriter
                XmlTextWriter escritor = new XmlTextWriter(Server.MapPath("Carrito.xml"), null);
                escritor.Formatting = Formatting.Indented;
                
                escritor.WriteStartDocument();
                escritor.WriteStartElement("Carrito");
                foreach (BEItemCarrito item in ventaActual.Carrito)
                {
                    escritor.WriteStartElement("Item");
                    escritor.WriteElementString("CodProducto", item.CodProducto.ToString());
                    escritor.WriteElementString("NombreProducto", item.Producto.Nombre);
                    escritor.WriteElementString("Cantidad", item.Cantidad.ToString());
                    escritor.WriteElementString("PrecioVenta", item.PrecioVenta.ToString());
                    escritor.WriteElementString("ImgUrl", item.Producto.ImgUrl);
                    escritor.WriteEndElement();
                }
                escritor.WriteEndElement();
                escritor.WriteEndDocument();
                escritor.Close();
            }
        }












        /*
         * <asp:GridView ID="gvProductos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
            <Columns>   
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-success" CommandArgument='<%# Eval("ID") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         * */
    }
}