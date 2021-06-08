using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Choferes
{
    public class ClsModChoferes
    {
        public int id { get; set; }
        public string users { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apeidoP { get; set; }
        public string apeidoM { get; set; }
        public int idEmpresa { get; set; }
        public string Empresa { get; set; }

        public int status { get; set; }
        public string mensaje { get; set; }
        public string passSmbTrack { get; set; }
        public string userSmbTrack { get; set; }
    }
}
