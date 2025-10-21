using BE;
using BLL;
using Microsoft.Ajax.Utilities;
using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<BEItemCarrito> carritoActual = new List<BEItemCarrito>();
        BLLVenta bllVenta = new BLLVenta();
        BLLEvento bllEventos = new BLLEvento();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BEUsuario usuarioActual = Session["User"] as BEUsuario;
            if (usuarioActual == null)
                Response.Redirect("Login.aspx");


            if (!IsPostBack) 
            { 
                //Leer archivo XML
                XmlDocument doc = new XmlDocument();
                XmlTextReader reader = new XmlTextReader(Server.MapPath("Carrito.xml"));
                doc.Load(reader);

                for(int i = 0; i < doc.DocumentElement.ChildNodes.Count; i++)
                {
                    BEItemCarrito item = new BEItemCarrito();
                    item.CodProducto = int.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText);
                    item.Producto = new BEProducto();
                    item.Producto.Nombre = doc.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText;
                    item.Cantidad = int.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText);
                    item.PrecioVenta = double.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[3].InnerText);
                    item.Producto.ImgUrl = doc.DocumentElement.ChildNodes[i].ChildNodes[4].InnerText;
                    carritoActual.Add(item);
                }
                reader.Close();

                Session["montoTotal"] = carritoActual.Sum(i => i.Cantidad * i.PrecioVenta);
                Session["cantTotal"] = carritoActual.Sum(i => i.Cantidad);

                lblCant.Text = "Cantidad comprada: " + Session["cantTotal"].ToString();
                lblTotal.Text = "Total: $" + Session["montoTotal"].ToString();
                rptCarrito.DataSource = carritoActual;
                rptCarrito.DataBind();
            }
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int codigoProducto = int.Parse(btn.CommandArgument);
            //actualizar la cantidad que hay en el carrito de este producto en el xml

            var xml = XDocument.Load(Server.MapPath("Carrito.xml"));
            var item = xml.Descendants("Item").FirstOrDefault(x => (int)x.Element("CodProducto") == codigoProducto);
            if (item != null)
                item.Element("Cantidad").Value = ((int)item.Element("Cantidad") + 1).ToString();
            xml.Save(Server.MapPath("Carrito.xml"));
            Response.Redirect(Request.RawUrl);
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int codigoProducto = int.Parse(btn.CommandArgument);
            //actualizar xml

            var xml = XDocument.Load(Server.MapPath("Carrito.xml"));
            var item = xml.Descendants("Item").FirstOrDefault(x => (int)x.Element("CodProducto") == codigoProducto);
            if (item != null)
                item.Element("Cantidad").Value = ((int)item.Element("Cantidad") - 1).ToString();
            xml.Save(Server.MapPath("Carrito.xml"));
            Response.Redirect(Request.RawUrl);
        }

        protected void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //registrar venta y evento
            //resetear archivo xml

            BECarrito carrito = new BECarrito();
            carrito.nombreUsuario = (Session["User"] as BEUsuario).NombreUsuario;
            carrito.montoTotal = double.Parse(Session["montoTotal"].ToString());

            bllVenta.RegistrarVenta(carrito, Server.MapPath("Carrito.xml"));

            System.IO.File.WriteAllText(Server.MapPath("Carrito.xml"), "");

            BEUsuario user = Session["User"] as BEUsuario;
            bllEventos.RegistrarEvento(new Evento(user.NombreUsuario, "Ventas", "Venta realizada", 1));

        }
    }
}