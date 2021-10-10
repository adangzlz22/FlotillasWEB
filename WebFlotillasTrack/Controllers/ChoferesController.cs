using ClsDatFlotillas;
using ClsModFlotillas.Bitacora;
using ClsModFlotillas.Choferes;
using ClsModFlotillas.Session;
using ClsModHarodoor.Common;
using ClsNegFlotillas.Choferes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using WebFlotillasTrack.clases;

namespace WebFlotillasTrack.Controllers
{
    public class ChoferesController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerChoferes")]
        public ClsModResponse ObtenerChoferes([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosChoferes objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosChoferes>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<ClsModChoferes> objUsuarios = new ClsNegChoferes().ObtenerChoferes(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("CrearEditarChoferes")]
        public ClsModResponse CrearEditarChoferes([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosChoferes objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosChoferes>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModChoferes objUsuarios = new ClsNegChoferes().CrearEditarChoferes(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EliminarChoferes")]
        public ClsModResponse EliminarChoferes([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosChoferes objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosChoferes>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModChoferes objUsuarios = new ClsNegChoferes().EliminarChoferes(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EnviarCorreo")]
        public ClsModResponse EnviarCorreo([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosChoferes objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosChoferes>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            Globales.sendEmail(objUsuario.subject, objUsuario.msg, objUsuario.emails);

            //ClsModChoferes objUsuarios = new ClsNegChoferes().EliminarChoferes(objUsuario, out objModResultado);
            //objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("LogearseEnSmbTrack")]
        public ClsModResponse LogearseEnSmbTrack([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosLogSmb objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosLogSmb>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            var url = $"https://ci8dp85wa4.execute-api.us-east-1.amazonaws.com/imovit/access/login";
            var request = (HttpWebRequest)WebRequest.Create(url);

            ClsModLogSMB objUs = new ClsModLogSMB();
            objUs.keyUser = objUsuario.keyUser;
            objUs.pass = objUsuario.pass;
            objUs.user = objUsuario.user;

            string parameters = Newtonsoft.Json.JsonConvert.SerializeObject(objUs);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.KeepAlive = true;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(parameters);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return objModResponse;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                            objModResponse.Model = responseBody;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerVehiculos")]
        public ClsModResponse ObtenerVehiculos([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosObtenerVehiculos objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosObtenerVehiculos>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;
            ClsModObtenerVehiculosParametros objUsuarioParametros = new ClsModObtenerVehiculosParametros();
            objUsuarioParametros.user = objUsuario.user;

            var url = $"https://ci8dp85wa4.execute-api.us-east-1.amazonaws.com/imovit/cars/getVehiclesEvents?user=" + objUsuarioParametros.user;
            var request = (HttpWebRequest)WebRequest.Create(url);

            ClsModObtenerVehiculosHeders objUsuarioHeders = new ClsModObtenerVehiculosHeders();


            objUsuarioHeders.accessToken = objUsuario.accessToken;
            objUsuarioHeders.keyUser = objUsuario.keyUser;
            objUsuarioHeders.idUser = objUsuario.idUser;


            request.Method = "GET";
            request.ContentType = "'application/json',\r\n";
            request.Headers.Add("accessToken", objUsuarioHeders.accessToken);
            request.Headers.Add("keyUser", objUsuarioHeders.keyUser);
            request.Headers.Add("idUser", objUsuarioHeders.idUser);
            request.KeepAlive = true;
            try
            {


                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return objModResponse;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                            objModResponse.Model = responseBody;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("CrearInicioDeSession")]
        public ClsModResponse CrearInicioDeSession([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosSessionActiva objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosSessionActiva>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModChoferes objUsuarios = new ClsNegChoferes().CrearInicioDeSession(objUsuario, objUsuario.user, objUsuario.idEmpresa, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, FormatoRespuesta.JSON);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EjecutarExtracciondeUbicaciones")]
        public ClsModResponse EjecutarExtracciondeUbicaciones([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosExtraccion objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosExtraccion>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;
            List<ClsModSessionActiva> lstObtenerSessiones = new ClsNegChoferes().ObtenerSessionesActivas(out objModResultado);
            ClsModVehiculos objVehiculos = new ClsModVehiculos();
            ClsModPosit lstPosit = new ClsModPosit();
            List<ClsModResultAppSessionActiva> lstSessionActiva = new List<ClsModResultAppSessionActiva>();
            lstSessionActiva = new ClsNegChoferes().ExtraerBitacora(out objModResultado);
            foreach (var n in lstSessionActiva)
            {
                foreach (var item in lstObtenerSessiones)
                {
                    objVehiculos = ObtenerPlacas(item.correo, item.accessToken, item.keyUser, item.idUser);
                    if (objVehiculos.data != null)
                    {
                        foreach (var itemV in objVehiculos.data)
                        {
                            if (n.placa == itemV.Vehiculo)
                            {
                                string FechaActual = objUsuario.fechaFin.ToString("yyyy-MM-dd");
                                string HoraInicial = objUsuario.fechaInicio.ToString("HH:mm:ss");
                                string HoraFinal = objUsuario.fechaFin.ToString("HH:mm:ss");
                                lstPosit = ObtenerBitacora(itemV.Vehiculo, FechaActual, HoraInicial, HoraFinal, item.accessToken, item.keyUser, item.idUser);
                                ClsModParamsBit objParametros = new ClsModParamsBit();
                                int idestatus = 0;
                                ClsModParametrosStatusActivo objparametro = new ClsModParametrosStatusActivo();
                                objparametro.idChofer = n.idChofer;
                                estatusActivo objEstatus = new ClsNegChoferes().ObtenerEstatusActivo(objparametro, out objModResultado);

                                if (objEstatus != null)
                                {
                                    switch (objEstatus.idEstatus)
                                    {
                                        case 4:
                                            idestatus = (int)objEstatus.idEstatus;
                                            break;
                                        case 3:
                                            idestatus = (int)objEstatus.idEstatus;
                                            break;
                                        case 1:
                                            idestatus = lstPosit.data.positions.Select(y => y.velocidad).FirstOrDefault() != "0" ? 2 : 1;
                                            break;
                                        case 2:
                                            idestatus = lstPosit.data.positions.Select(y => y.velocidad).FirstOrDefault() != "0" ? 2 : 1;
                                            break;
                                    }
                                }
                                else
                                {
                                    idestatus = lstPosit.data.positions.Select(y => y.velocidad).FirstOrDefault() != "0" ? 2 : 1;
                                }

                                objParametros.idEstado = idestatus;
                                objParametros.fecha = Convert.ToDateTime(FechaActual);
                                objParametros.fechaInicio = objUsuario.fechaInicio;
                                objParametros.fechaFin = objUsuario.fechaFin;
                                objParametros.logituf = lstPosit.data.positions.Select(y => y.longitud).FirstOrDefault();
                                objParametros.latitud = lstPosit.data.positions.Select(y => y.latitud).FirstOrDefault();
                                objParametros.placa = itemV.Vehiculo;
                                objParametros.idChofer = n.idChofer;

                                ClsModBitacora Respuesta = new ClsNegChoferes().GuardarBitacora(objParametros, out objModResultado);
                            }

                        }

                    }

                }


            }
            ClsModChoferes objUsuarios = new ClsNegChoferes().EjecutarExtracciondeUbicaciones(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, FormatoRespuesta.JSON);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        public ClsModVehiculos ObtenerPlacas(string correo, string accessToken, string keyUser, string idUser)
        {
            var url = $"https://ci8dp85wa4.execute-api.us-east-1.amazonaws.com/imovit/cars/getVehiclesEvents?user=" + correo;
            var request = (HttpWebRequest)WebRequest.Create(url);

            ClsModObtenerVehiculosHeders objUsuarioHeders = new ClsModObtenerVehiculosHeders();
            ClsModVehiculos objVehiculos = new ClsModVehiculos();

            objUsuarioHeders.accessToken = accessToken;
            objUsuarioHeders.keyUser = keyUser;
            objUsuarioHeders.idUser = idUser;

            request.Method = "GET";
            request.ContentType = "'application/json',\r\n";
            request.Headers.Add("accessToken", objUsuarioHeders.accessToken);
            request.Headers.Add("keyUser", objUsuarioHeders.keyUser);
            request.Headers.Add("idUser", objUsuarioHeders.idUser);
            request.KeepAlive = true;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return objVehiculos;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        // Do something with responseBody
                        Console.WriteLine(responseBody);
                        objVehiculos = new ClsModVehiculos();

                        ClsModRequest obj = new ClsModRequest();
                        obj.Model = responseBody;


                        objVehiculos = ClsObjectTransformation.Deserialize<ClsModVehiculos>(obj.Model, FormatoRespuesta.JSON);

                    }
                }
            }
            return objVehiculos;
        }

        public ClsModPosit ObtenerBitacora(string placa, string dia, string HoraInicial, string HoraFinal, string accessToken, string keyUser, string idUser)
        {
            var url = $"https://ci8dp85wa4.execute-api.us-east-1.amazonaws.com/imovit/positions/getHistoricalPositionHours?placa_vehiculo=" + placa + "&day=" + dia + "&startHour=" + HoraInicial + "&endHour=" + HoraFinal;
            var request = (HttpWebRequest)WebRequest.Create(url);

            ClsModObtenerVehiculosHeders objUsuarioHeders = new ClsModObtenerVehiculosHeders();
            ClsModPosit objVehiculos = new ClsModPosit();

            objUsuarioHeders.accessToken = accessToken;
            objUsuarioHeders.keyUser = keyUser;
            objUsuarioHeders.idUser = idUser;

            request.Method = "GET";
            request.ContentType = "'application/json',\r\n";
            request.Headers.Add("accessToken", objUsuarioHeders.accessToken);
            request.Headers.Add("keyUser", objUsuarioHeders.keyUser);
            request.Headers.Add("idUser", objUsuarioHeders.idUser);
            request.KeepAlive = true;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return objVehiculos;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        // Do something with responseBody
                        Console.WriteLine(responseBody);
                        objVehiculos = new ClsModPosit();

                        ClsModRequest obj = new ClsModRequest();
                        obj.Model = responseBody;


                        objVehiculos = ClsObjectTransformation.Deserialize<ClsModPosit>(obj.Model, FormatoRespuesta.JSON);

                    }
                }
            }
            return objVehiculos;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("GuardarSessionAppActiva")]
        public ClsModResponse GuardarSessionAppActiva([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosAppSessionActiva objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosAppSessionActiva>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModResultAppSessionActiva objUsuarios = new ClsNegChoferes().GuardarSessionAppActiva(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("EditarBitacora")]
        public ClsModResponse EditarBitacora([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosBitacora objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosBitacora>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModBitacora objUsuarios = new ClsNegChoferes().EditarBitacora(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("choferTieneSesionByIdChofer")]
        public ClsModResponse TieneSesionByIdChofer(int idChofer)
        {
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;
            ClsModRequest objModRequest = new ClsModRequest();
            SessionAppActiva isSesionACtiva = new ClsNegChoferes().TieneSesionByIdChofer(idChofer, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(isSesionACtiva, FormatoRespuesta.JSON);
            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("CrearCertificacion")]
        public ClsModResponse CrearCertificacion([FromBody] ClsModRequest objModRequest)
        {
            ClsModEnvioCorreo objUsuario = ClsObjectTransformation.Deserialize<ClsModEnvioCorreo>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModEnvioCorreo objUsuarios = new ClsNegChoferes().CrearCertificacion(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("obtenerCertificadosInspeccion")]
        public ClsModResponse ObtenerCertificadosInspeccion(int idChofer)
        {
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;
            ClsModRequest objModRequest = new ClsModRequest();
            List<ClsModEnvioCorreo> isSesionACtiva = new ClsNegChoferes().ObtenerCertificadosInspeccion(idChofer, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(isSesionACtiva, FormatoRespuesta.JSON);
            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        public string ExtraerUbicaciones(string latitud, string longitud)
        {
            string a = "";

            string peticion = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitud + "," + longitud + "&key=AIzaSyBBB3TsMb0CvbnHbrufmSaa6hPEhputYmY";
            var request = (HttpWebRequest)WebRequest.Create(peticion);

            ClsModObtenerVehiculosHeders objUsuarioHeders = new ClsModObtenerVehiculosHeders();

            request.Method = "GET";
            request.ContentType = "'application/json',\r\n";
            request.Headers.Add("accessToken", objUsuarioHeders.accessToken);
            request.Headers.Add("keyUser", objUsuarioHeders.keyUser);
            request.Headers.Add("idUser", objUsuarioHeders.idUser);
            request.KeepAlive = true;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        // Do something with responseBody
                        Console.WriteLine(responseBody);

                        ClsModRequest obj = new ClsModRequest();
                        obj.Model = responseBody;


                        a = ClsObjectTransformation.Deserialize<string>(obj.Model, FormatoRespuesta.JSON);

                    }
                }
            }


            return a;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerReloj")]
        public ClsModResponse ObtenerReloj([FromBody] ClsModRequest objModRequest)
        {
            ClsModTimer objUsuario = ClsObjectTransformation.Deserialize<ClsModTimer>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<spObtenerReloj_Result> objUsuarios = new ClsNegChoferes().ObtenerReloj(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("CerrarSession")]
        public ClsModResponse CerrarSession([FromBody] ClsModRequest objModRequest)
        {
            ClsModTimer objUsuario = ClsObjectTransformation.Deserialize<ClsModTimer>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            var objUsuarios = new ClsNegChoferes().CerrarSession(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerChoferNombre")]
        public ClsModResponse ObtenerChoferNombre([FromBody] ClsModRequest objModRequest)
        {
            ClsModTimer objUsuario = ClsObjectTransformation.Deserialize<ClsModTimer>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            var objUsuarios = new ClsNegChoferes().ObtenerChoferNombre(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }



        [HttpPost]
        [AllowAnonymous]
        [ActionName("obtenerVehiculosYaAsignados")]
        public ClsModResponse obtenerVehiculosYaAsignados([FromBody] ClsModRequest objModRequest)
        {
            ClsModTimer objUsuario = ClsObjectTransformation.Deserialize<ClsModTimer>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            var objUsuarios = new ClsNegChoferes().obtenerVehiculosYaAsignados(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

    }
}
