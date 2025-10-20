using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null && Session["TablaError"] == null)
            {

                BEUsuario user = Session["User"] as BEUsuario;

                btnCerrarSesion.Visible = true;
                btnReuniones.Visible = true;
                btnCarrito.Visible = true;

                if (user.codRol == 1 || user.codRol == 2)
                {
                    btnEventos.Visible = true;
                    btnRespaldo.Visible = true;
                    btnEstadisticas.Visible = true;
                }
            }

            if (Session["TablaError"] != null)
            {
                btnInicio.HRef = "~/Login";

                //cierra la sesion al salir de la página de reparación de DV
                if (!Request.Path.EndsWith("ReparacionBD.aspx", StringComparison.OrdinalIgnoreCase))
                {
                    Session["User"] = null;
                }
            }
            else
            {
                btnInicio.HRef = "~/";
            }
        }
    }
}