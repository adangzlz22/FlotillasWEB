using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Bitacora
{
    public class ClsModParamsBit
    {
        public int idChofer { get; set; }
        public string placa { get; set; }
        public int idEstado { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string logituf { get; set; }
        public string latitud { get; set; }
        public string nombreUbicacion { get; set; }
    }
}
