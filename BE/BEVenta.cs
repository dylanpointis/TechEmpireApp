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
    }
}
