using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClsModHarodoor.Common;

namespace ClsModHarodoor.Common
{
    public class ClsModRequest
    {

        /// <summary>
        /// Modelo enviado en la peticion, dependiendo del tipo este se transformara
        /// </summary>
        public string Model { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        /// <summary>
        /// Tipo de perticion a realizar(Catalogos)
        /// </summary>
        public TipoRequest TipoPeticion { get; set; }

        /// <summary>
        /// Tipo de accion a realizar (Metodo a llamar)
        /// </summary>
        public int TipoAccion { get; set; }


        /// <summary>
        /// Formato a utilizar en la patecion y en las respuestas
        /// </summary>
        public FormatoRespuesta Formato { get; set; }
        public string Ruta { get; set; }

        /// <summary>
        /// Propiedad para identificar si la solicitud llamará a modificar (en el caso de guardar)
        /// </summary>
        public bool IsModificar { get; set; }

        /// <summary>
        /// Propiedad para identificar si la solicitud viene del sitio de administración
        /// </summary>
        public bool IsAdmin { get; set; }

    }
}
