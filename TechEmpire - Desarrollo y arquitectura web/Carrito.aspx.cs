using BE;
using BLL;
using Microsoft.Ajax.Utilities;
using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        BEVenta ventaActual;
        List<BEItemCarrito> carritoActual = new List<BEItemCarrito>();
        BLLVenta bllVenta = new BLLVenta();
        BLLEvento bllEventos = new BLLEvento();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BEUsuario usuarioActual = Session["User"] as BEUsuario;
            if (usuarioActual == null)
                Response.Redirect("Login.aspx");


            if(Session["VentaActual"] != null)
            {
                ventaActual = Session["VentaActual"] as BEVenta;
            }
            else { ventaActual = new BEVenta(); }

            if (!IsPostBack)
            {
                //Leer archivo XML
                XmlDocument doc = new XmlDocument();

                string xmlPath = Server.MapPath("Carrito.xml");
                XmlTextReader reader = new XmlTextReader(xmlPath);

                if (new FileInfo(xmlPath).Length == 0)
                {
                    Response.Redirect("Default.aspx");
                }


                doc.Load(reader);

                for (int i = 0; i < doc.DocumentElement.ChildNodes.Count; i++)
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

                Session["montoTotal"] = ventaActual.Carrito.Sum(i => i.Cantidad * i.PrecioVenta);
                Session["cantTotal"] = ventaActual.Carrito.Sum(i => i.Cantidad);

                lblCant.Text = "Cantidad comprada: " + Session["cantTotal"].ToString();
                lblTotal.Text = "Total: $" + Session["montoTotal"].ToString();


                ventaActual.Carrito = carritoActual;
                rptCarrito.DataSource = ventaActual.Carrito;
                rptCarrito.DataBind();
            }
        }


        protected void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //registrar venta y evento
            //resetear archivo xml

            ventaActual.NombreUsuario = (Session["User"] as BEUsuario).NombreUsuario;
            ventaActual.MontoTotal = double.Parse(Session["montoTotal"].ToString());

            bllVenta.RegistrarVenta(ventaActual, Server.MapPath("Carrito.xml"));
            btnRegistrarVenta.Enabled = false;

            ventaActual = null;
            Session["VentaActual"] = null;
            System.IO.File.WriteAllText(Server.MapPath("Carrito.xml"), "<Carrito></Carrito>");

            BEUsuario user = Session["User"] as BEUsuario;
            bllEventos.RegistrarEvento(new Evento(user.NombreUsuario, "Ventas", "Venta realizada", 1));

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ventaActual = null;
            Session["VentaActual"] = null;
            System.IO.File.WriteAllText(Server.MapPath("Carrito.xml"), "<Carrito></Carrito>");
            Response.Redirect("Default.aspx");
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
            {
                if (Convert.ToInt32(item.Element("Cantidad").Value) > 1)
                {
                    item.Element("Cantidad").Value = ((int)item.Element("Cantidad") - 1).ToString();
                }
            }


            xml.Save(Server.MapPath("Carrito.xml"));
            Response.Redirect(Request.RawUrl);
        }
    }
}