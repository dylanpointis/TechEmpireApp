using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class AuditoriaEventos : System.Web.UI.Page
    {
        BLLEvento bLLEvento = new BLLEvento();
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
                List<Evento> events = bLLEvento.TraerListaEventos();

                gvEventos.DataSource = events;
                gvEventos.DataBind();
            }
         
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = calendariofechaInicio.SelectedDate;
            DateTime fechaFin = calendariofechaFin.SelectedDate;

            if(fechaFin >= fechaInicio)
            {
                List<Evento> lista = bLLEvento.FiltrarEventos(fechaInicio, fechaFin);
                gvEventos.DataSource = lista;
                gvEventos.DataBind();
            }

        }
    }
}