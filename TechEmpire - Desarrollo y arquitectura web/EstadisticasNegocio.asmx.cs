using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.Data;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    /// <summary>
    /// Descripción breve de WebServiceVentas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceVentas : System.Web.Services.WebService
    {
        BLLVenta bllVenta = new BLLVenta();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public Array FiltrarVenta(string fechaInicio, string fechaFin)
        {
           DataTable tabla = bllVenta.FiltrarVentas(fechaInicio, fechaFin);

            var productosMasVendidos = tabla.AsEnumerable()
              .GroupBy(r => r.Field<int>("CodigoProducto"))
              .Select(g => new
              {
                  CodigoProducto = g.Key,
                  Nombre = g.First().Field<string>("Nombre"),
                  CantidadVendida = g.Sum(x => x.Field<int>("Cantidad")),
                  TotalVendido = g.Sum(x => x.Field<double>("PrecioVenta") * x.Field<int>("Cantidad"))
              })
              .OrderByDescending(x => x.CantidadVendida)
              .ToArray();

            return productosMasVendidos;
        }
    }
}
