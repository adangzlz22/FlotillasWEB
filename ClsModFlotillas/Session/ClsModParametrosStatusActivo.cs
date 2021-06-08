using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Session
{
    public class ClsModParametrosStatusActivo
    {
        public int id { get; set; }
        public int idChofer { get; set; }
        public int idEstatus { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

    }
}
