using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Usuarios
{
    public class ClsModUsuarios
    {
        public string users { get; set; }
        public string pass { get; set; }

        public int status { get; set; }
        public string mensaje { get; set; }

        public int id { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apeidoPaterno { get; set; }
        public string apeidoMaterno { get; set; }
        public int idNivel { get; set; }
        public int idEmpresa { get; set; }
        public string Empresa { get; set; }
        public string userSmbTrack { get; set; }
        public string passSmbTrack { get; set; }

    }
}
