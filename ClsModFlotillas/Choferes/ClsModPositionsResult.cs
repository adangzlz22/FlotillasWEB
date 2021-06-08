using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Choferes
{
    public class ClsModPositionsResult
    {
        public string IDEquipo { get; set; }
        public string Fecha { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string velocidad { get; set; }
        public string distancia { get; set; }
        public string horimetro { get; set; }
        public string voltajeBateria { get; set; }
        public string cursoSobreTerreno { get; set; }
        public string satelites { get; set; }
        public string voltajePrincipal { get; set; }
        public string fixGPS { get; set; }
        public string radio { get; set; }
        public string ignicion { get; set; }
    }
}
