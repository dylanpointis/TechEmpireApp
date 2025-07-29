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
            // Solo puede entrar el webmaster o el administrador
            if (user == null || (user.codRol != 1 && user.codRol != 2))
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
            // Generar el nombre del archivo de respaldo con la fecha y hora actual
            string nombreArchivo = $"TechEmpire.BackUp_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.bak";
            string rutaCompleta = @"D:\Backups\" + nombreArchivo;
            //Llamar al metodo de respaldo de la BLL
            try
            {
                bllRespaldo.RealizarBackUp(rutaCompleta, user.NombreUsuario);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al realizar el respaldo: " + ex.Message;
                return;
            }

            //Descargar el archivo
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={nombreArchivo}");
            Response.TransmitFile(rutaCompleta);
            Response.End();
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un archivo para restaurar
            if (!FileUpload1.HasFile)
            {
                lblMensaje.Text = "Por favor, seleccione un archivo para restaurar.";
                return;
            }


            // Verificar si existe la carpeta Uploads
            if (!Directory.Exists(@"D:\Uploads\"))
            {
                Directory.CreateDirectory(@"D:\Uploads\");
            }

           
            //guardar el archivo subido en la carpeta Uploads
            string savePath = @"D:\Uploads\" + FileUpload1.FileName; 

            // Guardar el archivo
            FileUpload1.SaveAs(savePath);

            //Realizar el restore de la base de datos
            try
            {
                bllRespaldo.RealizarRestore(savePath, user.NombreUsuario);
                lblMensaje.Text = "Base de datos restaurada";
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al restaurar la base de datos: " + ex.Message;
                return;
            }
        }
    }
}