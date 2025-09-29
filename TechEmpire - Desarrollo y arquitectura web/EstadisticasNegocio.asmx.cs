using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

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
            return bllVenta.FiltrarVentas(fechaInicio, fechaFin);
        }
    }
}
