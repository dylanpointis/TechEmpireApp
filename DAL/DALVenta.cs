using BE;
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

        public void RegistrarVenta(BEVenta venta)
        {
            //registro la venta en la tabla venta y luego los items en la tabla carrito
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("Fecha", DateTime.Now.ToString("yyyy-MM-dd")),
                new SqlParameter("Hora", DateTime.Now.ToString("hh:mm")),
                new SqlParameter("@nombreUsuario", venta.NombreUsuario),
                new SqlParameter("@montoTotal", venta.MontoTotal)
            };

            dalCon.EjecutarProcAlmacenado("RegistrarVenta", parametros);

            foreach (var item in venta.Carrito)
            {
                SqlParameter[] parametrosItems = new SqlParameter[]
                {
                    //new SqlParameter("@codVenta", item.NombreUsuario),
                    new SqlParameter("@codProducto", item.CodProducto),
                    new SqlParameter("@cantidad", item.Cantidad),
                    new SqlParameter("@precioVenta", item.PrecioVenta),
                };
                dalCon.EjecutarProcAlmacenado("RegistrarItems", parametrosItems);
            }
        }
    }
}
