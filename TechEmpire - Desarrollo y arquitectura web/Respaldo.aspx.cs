using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Respaldo : System.Web.UI.Page
    {
        private BEUsuario user;
        private BLLRespaldo bllRespaldo = new BLLRespaldo();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["User"] as BEUsuario;
            if (user == null || user.codRol != 1 && user.codRol != 2)
            {
                Response.Redirect("Login.aspx");
            }
        }

        

        protected void btnRealizarRespaldo_Click(object sender, EventArgs e)
        {
            bllRespaldo.RealizarBackUp(user.NombreUsuario);
        }
    }
}