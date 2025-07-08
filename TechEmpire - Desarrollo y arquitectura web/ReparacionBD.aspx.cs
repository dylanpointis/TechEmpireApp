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
    public partial class ReparacionBD : System.Web.UI.Page
    {
        BLLDigitoVerificador bllDV = new BLLDigitoVerificador();
        protected void Page_Load(object sender, EventArgs e)
        {
            BEUsuario user = Session["User"] as BEUsuario;
            //solo puede entrar el webmaster
            if (user == null ||  user.codRol != 2)
            {
                Response.Redirect("Login.aspx");
            }

            lblTablaAfectada.Text = Session["TablasError"].ToString();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            bllDV.RecalcularBD();

            Response.Write("<script>alert('Se recalculó el dígito verificador');</script>");

            Session["User"] = null;
            Session["TablaError"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}