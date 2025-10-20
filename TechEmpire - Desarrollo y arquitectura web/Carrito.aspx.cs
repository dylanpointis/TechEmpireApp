using BE;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<BEItemCarrito> carritoActual = new List<BEItemCarrito>();
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

                double total = carritoActual.Sum(i => i.Cantidad * i.PrecioVenta);
                int cantTotal = carritoActual.Sum(i => i.Cantidad);

                lblCant.Text = "Cantidad comprada: f" + cantTotal.ToString();
                lblTotal.Text = "Total: $" + total.ToString();
                rptCarrito.DataSource = carritoActual;
                rptCarrito.DataBind();
            }
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int codigoProducto = int.Parse(btn.CommandArgument);
            //actualizar xml
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int codigoProducto = int.Parse(btn.CommandArgument);
            //actualizar xml
        }

        protected void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            //registrar venta y evento
            //resetear archivo xml
        }
    }
}