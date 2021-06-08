using ClsDatFlotillas;
using ClsModFlotillas.Bitacora;
using ClsModFlotillas.Session;
using ClsModHarodoor.Common;
using ClsNegFlotillas.Choferes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebFlotillasTrack.Controllers
{
    public class BitacoraController : ApiController
    {

        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerBitacoraEventos")]
        public ClsModResponse ObtenerBitacoraEventos([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosBitacora objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosBitacora>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<ClsModBitacora> objUsuarios = new ClsNegChoferes().ObtenerBitacoraEventos(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerBitacoraInformacion")]
        public ClsModResponse ObtenerBitacoraInformacion([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosBitacora objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosBitacora>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<ClsModBitacoraInformacion> objUsuarios = new ClsNegChoferes().ObtenerBitacoraInformacion(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("BotonesStatus")]
        public ClsModResponse BotonesStatus([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosStatusActivo objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosStatusActivo>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModResultStatusActivo objUsuarios = new ClsNegChoferes().BotonesStatus(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerEstatusActivo")]
        public ClsModResponse ObtenerEstatusActivo([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosStatusActivo objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosStatusActivo>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            estatusActivo objUsuarios = new ClsNegChoferes().ObtenerEstatusActivo(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }


    }
}
