using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaGameBox
{
    // Clase estática para almacenar los datos del usuario logueado en la sesión
    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Dni { get; set; }
        public static string Email { get; set; }
        public static string Telefono { get; set; }
        public static string Contraseña { get; set; }
        public static int IdRol { get; set; }

        public static void LimpiarSesion()
        {
            IdUsuario = 0;
            Nombre = null;
            Apellido = null;
            Dni = null;
            Email = null;
            Telefono = null;
            Contraseña = null;
            IdRol = 0;
        }
    }
}

