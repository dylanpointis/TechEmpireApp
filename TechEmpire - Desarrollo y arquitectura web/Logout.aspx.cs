using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using BE;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        BLLEvento bllEvento = new BLLEvento();

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

            BEUsuario user = Session["User"] as BEUsuario;


            bllEvento.RegistrarEvento(new Evento(user.NombreUsuario, "Sesiones", "Cierre sesión", 1));

            Session["User"] = null;
            Response.Redirect("Login");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}