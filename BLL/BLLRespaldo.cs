using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLRespaldo
    {
        private DALRespaldo dalRespaldo = new DALRespaldo();
        private BLLEvento bllEv = new BLLEvento();
       

        public void RealizarBackUp(string nombreUsuario)
        {
            string nombreArchivo = $"TechEmpire.BackUp_{DateTime.Now.ToString("ddMMyy_HHmm")}.bak";
            string rutaCompleta = System.IO.Path.Combine(@"D:\backuptest", nombreArchivo);


            dalRespaldo.RealizarBackUp(rutaCompleta);
            bllEv.RegistrarEvento(new Evento(nombreUsuario, "Respaldos", "Backup realizado", 1));
        }

        public void RealizarRestore(string nombreUsuario)
        {
            dalRespaldo.RealizarRestore(Directory.GetCurrentDirectory());
            bllEv.RegistrarEvento(new Evento(nombreUsuario, "Respaldos", "Restore realizado", 1));
        }
    }
}
