using BE;
using BLL;
using Microsoft.Ajax.Utilities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class InformeVentas : System.Web.UI.Page
    {

        //creo una instancia del servicio web estadisticasNegocio.asmx
        WebServiceVentas ws = new WebServiceVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Solo puede entrar el webmaster o el administrador
            BEUsuario user = Session["User"] as BEUsuario;
            if (user == null || (user.codRol != 1 && user.codRol != 2))
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                GridView1.DataSource = ws.FiltrarVenta(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                GridView1.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = calendariofechaInicio.SelectedDate;
            DateTime fechaFin = calendariofechaFin.SelectedDate;



            if (fechaFin >= fechaInicio)
            {
                GridView1.DataSource = ws.FiltrarVenta(fechaInicio.ToString("yyyy-MM-dd"), fechaFin.ToString("yyyy-MM-dd"));
                GridView1.DataBind();
            }
        }
    }
}