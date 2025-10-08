using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEItemCarrito
    {
        public int CodVenta { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioVenta { get; set; }

        public BEProducto Producto { get; set; }
        public BEVenta Venta { get; set; }
    }
}
