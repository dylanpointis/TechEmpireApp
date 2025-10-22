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
        public double MontoTotal { get; set; }   
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

            //Si ya esta el producto en el carrito, aumenta la cantidad
            if (Carrito.FirstOrDefault(i => i.Producto.CodigoProducto == producto.CodigoProducto) != null)
            {
                BEItemCarrito itemExistente = Carrito.FirstOrDefault(i => i.Producto.CodigoProducto == producto.CodigoProducto);
                itemExistente.Cantidad += cantidad;
                return;
            }

            //Si no esta, lo agrega
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
