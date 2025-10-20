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
    public partial class Reuniones : System.Web.UI.Page
    {

        BLLEvento bllEventos = new BLLEvento();
        BEUsuario usuarioActual = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioActual = Session["User"] as BEUsuario;
            if(usuarioActual == null)
                Response.Redirect("Login.aspx");


            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now;


            }
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblFechas.Text = "<h2>Usted eligió las siguientes fechas</h2>";
            foreach(DateTime fecha in Calendar1.SelectedDates)
            {
                lblFechas.Text += "<li>" + fecha.ToString("D");
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime maxDate = today.AddMonths(2);

            if (e.Day.Date < today || e.Day.Date > maxDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblFechas.Text = $"<h2>Fecha confirmada: {Calendar1.SelectedDate.ToString("dd/MM/yyyy")}</h2>";


            bllEventos.RegistrarEvento(new Evento(usuarioActual.NombreUsuario, "Reuniones", $"Reunión confirmada para {Calendar1.SelectedDate.ToString("dd/MM/yyyy")}", 1));
        }
    }
}