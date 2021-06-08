using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{

    public class ClsReadSettings
    {
        /// <summary>
        /// Regresa el tipo de conexion configurado en el archivo
        /// </summary>
        /// <returns>Regresa enum con Tipo de conexion</returns>
        public static TipoConexion GetTipoConexion()
        {
            try
            {
                return (TipoConexion)Enum.Parse(typeof(TipoConexion), ConfigurationManager.AppSettings["TipoConexion"], true);
            }
            catch
            {
                return TipoConexion.Local;
            }
        }

        /// <summary>
        /// Regresa el Formato de respuesta configurado
        /// </summary>
        /// <returns>Regresa enum con formato de respuesta</returns>
        public static FormatoRespuesta GetFormatoRespuesta()
        {
            try
            {
                return (FormatoRespuesta)Enum.Parse(typeof(FormatoRespuesta), ConfigurationManager.AppSettings["FormatoRespuesta"], true);
            }
            catch
            {
                return FormatoRespuesta.JSON;
            }
        }
        /// <summary>
        /// Regresa si el servicio esta en IIS o no
        /// </summary>
        /// <returns>bolean </returns>
        public static bool GetInstalacionIIS()
        {
            try
            {
                return bool.Parse(ConfigurationManager.AppSettings["IIS"]);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// Regresa si el servicio esta en IIS o no
        /// </summary>
        /// <returns>bolean </returns>
        public static string GetIISRuta()
        {
            try
            {
                return ConfigurationManager.AppSettings["Ruta"].ToString();
            }
            catch
            {
                return "";
            }
        }

    }
}
