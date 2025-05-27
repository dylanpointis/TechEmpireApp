using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BERol
    {
        public BERol(int codRol, string nombreRol)
        {
            CodRol = codRol;
            NombreRol = nombreRol;
        }

        public int CodRol {  get; set; }

        public string NombreRol { get; set; }
    }
}
