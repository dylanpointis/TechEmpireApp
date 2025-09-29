using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALVenta
    {

        DALConexion dalCon = new DALConexion();

        public DataTable TraerListaVentas(string fechaInicio, string fechaFin)
        {


            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@fechaInicio", fechaInicio),
                new SqlParameter("@fechaFin", fechaFin),
            };

            DataTable tabla = dalCon.ConsultaProcAlmacenado("TraerVentas", parametros);
            return tabla;

        }
    }
}
