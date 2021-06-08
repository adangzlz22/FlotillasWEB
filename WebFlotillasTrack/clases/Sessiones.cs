using ClsModFlotillas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace ClsDatFlotillas.clases
{
    public static class Sessiones
    {
        private static HttpSessionState session { get { return HttpContext.Current.Session; } }

        public static ClsModUsuarios sesionUsuarioDTO
        {
            get { return session["ClsModUsuarios"] as ClsModUsuarios; }
            set { session["ClsModUsuarios"] = value; }
        }
        public static string usuarioSession
        {
            get { return session["usuarioSession"] as string; }
            set { session["usuarioSession"] = value; }
        }
        public static ClsModUsuarios oUsuario
        {
            get { return session["oUsuario"] as ClsModUsuarios; }
            set { session["oUsuario"] = value; }
        }
    }
}


