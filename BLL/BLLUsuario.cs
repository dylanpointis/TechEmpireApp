using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Runtime.InteropServices;
using Services;
using System.Net;

namespace BLL
{
    public class BLLUsuario
    {
        private DALUsuario dalUsuario = new DALUsuario();
        private BLLEvento bllEvento = new BLLEvento();

        public BEUsuario Login(string username, string clave)
        {
            //verifica si existe el usuario por el username
            BEUsuario user = ValidarUsuario(username, 0, ""); 
            if (user == null)
                throw new Exception("El usuario ingresado no existe");

            int intentosFallidos = user.ContFallidos;

            //si ya esta bloqueado o desactivado
            if (user.Bloqueado == true || user.Activo == false)
                throw new Exception("El usuario se encuentra bloqueado o desactivado, comuníquese con el administrador del sistema");

            //si no coincide la contraseña
            if(Encriptacion.EncriptarSHA256(clave) != user.Clave)
            {
                //aumenta el numero de intentos fallidos
                intentosFallidos += 1;
                ModificarContFallido(user.NombreUsuario, intentosFallidos);
                
                //si llega a 3 intentos fallidos lo bloquea
                if(intentosFallidos >= 3)
                {
                    ModificarBloqueo(user.DNI, true);
                    bllEvento.RegistrarEvento(new Evento(username, "Sesiones", "Usuario bloqueado", 1));
                    throw new Exception("Se ha bloqueado al usuario por superar el límite de intentos fallidos, por favor comuníquese con el administrador del sistema");
                }


                throw new Exception("Las credenciales no coinciden");
            }


            bllEvento.RegistrarEvento(new Evento(user.NombreUsuario, "Sesiones", "Inicio sesión", 1));
            ModificarContFallido(user.NombreUsuario, 0);
            return user;
        }

      

        public BEUsuario ValidarUsuario(string nombreusuario, int dni, string email)
        {
            BEUsuario user = dalUsuario.ValidarUsuario(nombreusuario, dni, email);
            return user;
        }

        public void ModificarContFallido(string nombreUsuario, int contClaveIncorrecta)
        {
            dalUsuario.ModificarContFallido(nombreUsuario, contClaveIncorrecta);
        }

        public void ModificarBloqueo(int DNI, bool bloqueo)
        {
            dalUsuario.ModificarBloqueo(DNI, bloqueo);
        }
    }
}
