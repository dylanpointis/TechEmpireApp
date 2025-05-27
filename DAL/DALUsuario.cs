using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DAL
{
    public class DALUsuario
    {
        DALConexion dalCon = new DALConexion();

        public void ModificarBloqueo(int DNI, bool bloqueo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                 new SqlParameter("@DNI", DNI),
                 new SqlParameter("@Bloqueo", bloqueo)
            };

            dalCon.EjecutarProcAlmacenado("ModificarBloquearUsuario", parametros);
        }

        public void ModificarContFallido(string nombreUsuario, int contClaveIncorrecta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@ContClaveIncorrecta", contClaveIncorrecta)
            };
            dalCon.EjecutarProcAlmacenado("ModificarContFallido", parametros);
        }

        public BEUsuario ValidarUsuario(string nombreusuario, int DNI, string Email)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                 new SqlParameter("@NombreUsuario", nombreusuario),
                 new SqlParameter("@DNI", DNI),
                 new SqlParameter("@Email", Email)
            };


            DataTable tabla = dalCon.ConsultaProcAlmacenado("ValidarUsuario", parametros);

            BEUsuario user = null;
            foreach (DataRow dr in tabla.Rows)
            {
                user = new BEUsuario(Convert.ToString(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToBoolean(dr[7]), Convert.ToBoolean(dr[8]));
                user.ContFallidos = Convert.ToInt16(dr[9]);
                user.Rol = new BERol(Convert.ToInt32(dr[10]), dr[11].ToString());

                break;
                //Solo agarra el primer registro que coincida nombreusuario
            }
            return user;
        }
    }
}
