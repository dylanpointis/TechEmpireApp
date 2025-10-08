using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEVenta
    {
        public int CodVenta { get; set; }  
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public float MontoTotal { get; set; }   
        public string NombreUsuario { get; set; }   


        public List<BEItemCarrito> Carrito { get; set; }

        public BEVenta()
        {
            Carrito = new List<BEItemCarrito>();
        }

        public void AgregarItem(BEVenta venta, BEProducto producto, int cantidad)
        {
            BEItemCarrito item = new BEItemCarrito();
            item.CodVenta = venta.CodVenta;
            item.CodProducto = producto.CodigoProducto;
            item.Cantidad = cantidad;
            item.PrecioVenta = producto.Precio;
            item.Producto = producto;

            Carrito.Add(item);
        }

        public void QuitarItem(int codigoProducto)
        {
            BEItemCarrito item = Carrito.FirstOrDefault(c => c.CodProducto == codigoProducto);
            if (item != null)
            {
                Carrito.Remove(item);
            }

        }
    }
}
