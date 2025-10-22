using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class BLLVenta
    {

        private DALVenta dalVenta = new DALVenta();

        public DataTable FiltrarVentas(string fechaInicio, string fechaFin)
        {
            List<BEVenta> lista = new List<BEVenta>();
            DataTable tabla = dalVenta.TraerListaVentas(fechaInicio, fechaFin);
            return tabla;
        }

        public void RegistrarVenta(BEVenta venta, string rutaArchivo)
        {
            venta.Carrito = new List<BEItemCarrito>();
            using (XmlTextReader lector = new XmlTextReader(rutaArchivo))
            {
                BEItemCarrito itemActual = null;

                while (lector.Read())
                {
                    if (lector.NodeType == XmlNodeType.Element)
                    {
                        switch (lector.Name)
                        {
                            case "Item":
                                itemActual = new BEItemCarrito();
                                itemActual.Producto = new BEProducto();
                                break;

                            case "CodProducto":
                                lector.Read();
                                itemActual.CodProducto = int.Parse(lector.Value);
                                break;

                            case "NombreProducto":
                                lector.Read();
                                itemActual.Producto.Nombre = lector.Value;
                                break;

                            case "Cantidad":
                                lector.Read();
                                itemActual.Cantidad = int.Parse(lector.Value);
                                break;

                            case "PrecioVenta":
                                lector.Read();
                                itemActual.PrecioVenta = double.Parse(lector.Value);
                                break;

                            case "ImgUrl":
                                lector.Read();
                                itemActual.Producto.ImgUrl = lector.Value;
                                break;
                        }
                    }
                    else if (lector.NodeType == XmlNodeType.EndElement && lector.Name == "Item")
                    {
                        if (itemActual != null)
                        {
                            venta.Carrito.Add(itemActual);
                            itemActual = null;
                        }
                    }

                    
                }
            }

            dalVenta.RegistrarVenta(venta);
        }
    }
}
