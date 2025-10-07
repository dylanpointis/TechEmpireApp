using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
