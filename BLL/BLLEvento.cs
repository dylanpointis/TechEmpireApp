using DAL;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLEvento
    {
        private DALEvento dalEvento = new DALEvento();

        public List<Evento> FiltrarEventos(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = dalEvento.FiltrarEventos(fechaInicio.ToString("yyyy-MM-dd"), fechaFin.ToString("yyyy-MM-dd"));

            List<Evento> lista = new List<Evento>();

            foreach (DataRow row in tabla.Rows)
            {
                Evento evento = new Evento(row[1].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4]));

                evento.Fecha = row[5].ToString();
                evento.Hora = row[6].ToString();

                evento.CodEvento = Convert.ToInt64(row[0]);
                lista.Add(evento);
            }
            return lista.OrderByDescending(e => e.CodEvento).ToList();
        }

        public void RegistrarEvento(Evento evento)
        {
            evento.Fecha = DateTime.Today.ToString("yyyy-MM-dd");
            evento.Hora = DateTime.Now.ToString("HH:mm");
            dalEvento.RegistrarEvento(evento);
        }

        public List<Evento> TraerListaEventos()
        {
            List<Evento> lista = new List<Evento>();
            DataTable tabla = dalEvento.TraerListaEventos();

            foreach (DataRow row in tabla.Rows)
            {
                Evento evento = new Evento(row[1].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4]));

                evento.Fecha = row[5].ToString();
                evento.Hora = row[6].ToString();

                evento.CodEvento = Convert.ToInt64(row[0]);
                lista.Add(evento);
            }
            return lista.OrderByDescending(e => e.CodEvento).ToList();
        }

    }
}
