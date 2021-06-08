using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Bitacora
{
    public class ClsModBitacoraInformacion
    {
        public int id { get; set; }
        public Nullable<int> idChofer { get; set; }
        public Nullable<int> idEstado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaFin { get; set; }
        public string longitud { get; set; }
        public string latitud { get; set; }
        public string nombreUbicacion { get; set; }
        public string EstadoAccion { get; set; }

    }
}
