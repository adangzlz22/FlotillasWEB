using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public enum TipoConexion
    {
        /// <summary>
        /// Inca que la conexion que se establecera es local(usaran dlls locales)
        /// </summary>
        Local = 1,
        /// <summary>
        /// Indica que la conexion por WCF(WCF)
        /// </summary>
        WCF = 2
    }
}
