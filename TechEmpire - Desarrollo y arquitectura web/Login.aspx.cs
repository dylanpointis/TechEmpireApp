using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TechEmpire___Desarrollo_y_arquitectura_web
{
    public partial class Login : System.Web.UI.Page
    {
        private BLLUsuario bllUsuario = new BLLUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Trim() == "")
            {
                lblError.Text = "Ingresar el nombre de usuario";
                return;
            }
            if (txtClave.Text.Trim().Length < 8)
            {
                lblError.Text = "Ingresar la contraseña (Mayor a 8 caracteres)";
                return;
            }


            try
            {
                BEUsuario user = bllUsuario.Login(txtNombreUsuario.Text, txtClave.Text);

                Session["User"] = user;


                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}