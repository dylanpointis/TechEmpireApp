using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDigitoVerificador
    {
        DALDigitoVerificador dalDV = new DALDigitoVerificador();
        List<Object_DV> DVTablas = new List<Object_DV>();

        public void RecalcularDVTabla(string Tabla)
        {
            Object_DV DV = new Object_DV(Tabla, RecalcularDVHTabla(Tabla), RecalcularDVVTabla(Tabla));

            dalDV.RecalcularDVHTabla(Tabla, DV.DVH);
            dalDV.RecalcularDVVTabla(Tabla, DV.DVV);
        }

        private string RecalcularDVHTabla(string Tabla)
        {
            DataTable dt = dalDV.ObtenerTabla(Tabla);

            string DatosConcatenados = "";

            foreach (DataRow r in dt.Rows)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    DatosConcatenados += r[c].ToString();
                }
            }

            return Encriptacion.EncriptarSHA256(DatosConcatenados);
        }

        private string RecalcularDVVTabla(string Tabla)
        {
            DataTable dt = dalDV.ObtenerTabla(Tabla);

            string DatosConcatenados = "";

            foreach (DataColumn c in dt.Columns)
            {
                foreach (DataRow r in dt.Rows)
                {
                    DatosConcatenados += r[c].ToString();
                }
            }

            return Encriptacion.EncriptarSHA256(DatosConcatenados);
        }

        public List<string> ComprobarDV()
        {
            DataTable dt = dalDV.ObtenerTabla("DV");
            DVTablas.Clear();
            List<string> errores = new List<string>();

            foreach (DataRow r in dt.Rows)
            {
                Object_DV DV = new Object_DV(r[0].ToString(), RecalcularDVHTabla(r[0].ToString()), RecalcularDVVTabla(r[0].ToString()));

                DVTablas.Add(DV);

                DataTable DVTabla = dalDV.ObtenerDV(DV.Tabla);

                if (DVTabla.Rows[0][1].ToString() != DV.DVH || DVTabla.Rows[0][2].ToString() != DV.DVV)
                {
                    errores.Add(DV.Tabla);
                }
            }

            return errores;
        }

        public void RecalcularBD()
        {
            DataTable dt = dalDV.ObtenerTabla("DV");

            foreach (DataRow r in dt.Rows)
            {
                if (DVTablas.Any(Object_DV => Object_DV.Tabla == r[0].ToString()))
                {
                    Object_DV o = DVTablas.FirstOrDefault(Object_DV => Object_DV.Tabla == r[0].ToString());

                    dalDV.RecalcularDVHTabla(o.Tabla, o.DVH);
                    dalDV.RecalcularDVVTabla(o.Tabla, o.DVV);
                }
                else
                {
                    RecalcularDVTabla(r[0].ToString());
                }
            }
        }
    }
}
