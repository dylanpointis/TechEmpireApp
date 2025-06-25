using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDigitoVerificador
    {
        DALConexion dalCon = new DALConexion();

        public void RecalcularDVHTabla(string Tabla, string DVH)
        {
            SqlParameter[] parametros = new SqlParameter[]
             {
                new SqlParameter("@DVH", DVH),
                new SqlParameter("@Tabla", Tabla)
             };
            dalCon.EjecutarProcAlmacenado("RecalcularDVHTabla", parametros);
        }

        public void RecalcularDVVTabla(string Tabla, string DVV)
        {
            SqlParameter[] parametros = new SqlParameter[]
             {
                new SqlParameter("@DVV", DVV),
                new SqlParameter("@Tabla", Tabla)
             };
            dalCon.EjecutarProcAlmacenado("RecalcularDVVTabla", parametros);
        }

        public DataTable ObtenerDV(string Tabla)
        {
            DataTable dt = dalCon.TraerTabla("DV", $"Tabla = '{Tabla}'");
            return dt;
        }

        public DataTable ObtenerTabla(string Tabla)
        {
            return dalCon.TraerTabla(Tabla);
        }
    }
}
