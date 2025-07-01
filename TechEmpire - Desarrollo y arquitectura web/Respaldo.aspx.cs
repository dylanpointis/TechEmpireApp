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
            try
            {
                // Verificar si la carpeta Backups existe en el disco D, si no, crearlo
                if (!Directory.Exists(@"D:\Backups\"))
                {
                    Directory.CreateDirectory(@"D:\Backups\");
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear el directorio de backups: " + ex.Message;
                return;
            }
            string nombreArchivo = $"TechEmpire.BackUp_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.bak";
            string rutaCompleta = @"D:\Backups\" + nombreArchivo;
            bllRespaldo.RealizarBackUp(rutaCompleta, user.NombreUsuario);

            //Descargar el archivo
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={nombreArchivo}");
            Response.TransmitFile(rutaCompleta);
            Response.End();
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            //Session["archivo"] = Path.GetFileName(FileUpload1.FileName.ToString());
            if (!Directory.Exists(@"D:\Uploads\"))
            {
                Directory.CreateDirectory(@"D:\Uploads\");
            }
            string savePath = @"D:\Uploads\" + FileUpload1.FileName; // Guardarlo en el servidor

            // Guardar el archivo
            FileUpload1.SaveAs(savePath);



            bllRespaldo.RealizarRestore(savePath, user.NombreUsuario);
        }
    }
}