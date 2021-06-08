using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geocoding;
namespace WebFlotillasTrack.clases
{
    public class obtenerUbicacion
    {
        public string obtenerNombreUbicacion(double latitud, double longitud)
        {
            string n = "";
            Location locacion = new Location(latitud, longitud);


            return n;
        }
    }
}