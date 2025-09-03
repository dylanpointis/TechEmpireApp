using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace DAL
{
    public class DALEvento
    {
        DALConexion dalCon = new DALConexion();

        public DataTable FiltrarEventos(string fechaInicio, string fechaFin)
        {
            SqlParameter[] parametros = new SqlParameter[]
             {
                new SqlParameter("@fechaInicio", fechaInicio),
                new SqlParameter("@fechaFin", fechaFin),
             };
            DataTable tabla = dalCon.ConsultaProcAlmacenado("FiltrarEventos", parametros);

            return tabla;
        }

        public void RegistrarEvento(Evento evento)
        {
            SqlParameter[] parametros = new SqlParameter[]
             {
                new SqlParameter("@NombreUsuario", evento.NombreUsuario),
                new SqlParameter("@Modulo", evento.Modulo),
                new SqlParameter("@Evento", evento.evento),
                new SqlParameter("@Criticidad", evento.Criticidad),
                new SqlParameter("@Fecha", evento.Fecha),
                new SqlParameter("@Hora", evento.Hora)
             };
            dalCon.EjecutarProcAlmacenado("RegistrarEvento", parametros);
        }

        public DataTable TraerListaEventos()
        {
            return dalCon.TraerTabla("Eventos");
        }
    }
}
