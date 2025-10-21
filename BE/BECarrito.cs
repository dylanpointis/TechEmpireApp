using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECarrito
    {
        public List<BEItemCarrito> items { get; set; }
        public string nombreUsuario { get; set; }
        public double montoTotal { get; set; }
    }
}
