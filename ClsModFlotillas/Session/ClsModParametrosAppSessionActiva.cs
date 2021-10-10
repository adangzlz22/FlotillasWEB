using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Session
{
    public class ClsModParametrosAppSessionActiva
    {
        public int idChofer { get; set; }
        public string placa { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public bool inicioSession { get; set; }
        public string remolque1 { get; set; }
        public string remolque2 { get; set; }
        public string envios { get; set; }
    }
}
