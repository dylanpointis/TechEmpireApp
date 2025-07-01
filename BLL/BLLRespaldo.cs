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


        public void RealizarBackUp(string ruta, string nombreUsuario)
        {

            dalRespaldo.RealizarBackUp(ruta);
            bllEv.RegistrarEvento(new Evento(nombreUsuario, "Respaldos", "Backup realizado", 1));
        }

        public void RealizarRestore(string ruta, string nombreUsuario)
        {
            dalRespaldo.RealizarRestore(ruta);
            bllEv.RegistrarEvento(new Evento(nombreUsuario, "Respaldos", "Restore realizado", 1));
        }
    }
}
