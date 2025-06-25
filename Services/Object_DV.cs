using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Object_DV
    {
        public string Tabla { get; set; }
        public string DVH { get; set; }
        public string DVV { get; set; }

        public Object_DV(string tabla, string dVH, string dVV)
        {
            this.Tabla = tabla;
            this.DVH = dVH;
            this.DVV = dVV;
        }
    }
}
