using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModFlotillas.Choferes
{
    public class ClsModEnvioCorreo
    {
        public int id { get; set; }
        public int idChofer { get; set; }
        public string FrenosEstacionamiento { get; set; }
        public string FrenosMantenimiento { get; set; }
        public string DispositivosAcoplamiento { get; set; }
        public string EquipoDeUrgencia { get; set; }
        public string Bocina { get; set; }
        public string LucesYReflectores { get; set; }
        public string Retrovisores { get; set; }
        public string Direccion { get; set; }
        public string Neumaticos { get; set; }
        public string RuedasYLlantas { get; set; }
        public string Limpiaparabrisas { get; set; }
        public string Otro { get; set; }
        public string UbicacionDeInspeccion { get; set; }
        public string Observaciones { get; set; }
        public Nullable<bool> NoHayDefectos { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string TipoInspeccion { get; set; }
    }
}
