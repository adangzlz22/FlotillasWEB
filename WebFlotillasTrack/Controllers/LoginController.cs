using ClsDatFlotillas.clases;
using ClsModFlotillas.Choferes;
using ClsModFlotillas.Empresas;
using ClsModFlotillas.Usuarios;
using ClsModHarodoor.Common;
using ClsNegFlotillas.Choferes;
using ClsNegFlotillas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebFlotillasTrack.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [ActionName("Logearse")]
        public ClsModResponse Logearse([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosUsuarios objModConteoFisico = ClsObjectTransformation.Deserialize<ClsModParametrosUsuarios>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModUsuarios objUsuarios = new ClsNegUsuarios().Login(objModConteoFisico, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerUsuarioYEmpresa")]
        public ClsModResponse ObtenerUsuarioYEmpresa([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosUsuarios objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosUsuarios>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<ClsModUsuarios> objUsuarios = new ClsNegUsuarios().ObtenerUsuarioYEmpresa(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("CrearEditarUsuario")]
        public ClsModResponse CrearEditarUsuario([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosUsuarios objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosUsuarios>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModUsuarios objUsuarios = new ClsNegUsuarios().CrearEditarUsuario(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EliminarUsuario")]
        public ClsModResponse EliminarUsuario([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosUsuarios objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosUsuarios>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModUsuarios objUsuarios = new ClsNegUsuarios().EliminarUsuario(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("ObtenerEmpresas")]
        public ClsModResponse ObtenerEmpresas([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosEmpresas objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosEmpresas>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            List<ClsModEmpresas> objUsuarios = new ClsNegUsuarios().ObtenerEmpresas(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("CrearEditarEmpresa")]
        public ClsModResponse CrearEditarEmpresa([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosEmpresas objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosEmpresas>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModEmpresas objUsuarios = new ClsNegUsuarios().CrearEditarEmpresa(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EliminarEmpresa")]
        public ClsModResponse EliminarEmpresa([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosEmpresas objUsuario = ClsObjectTransformation.Deserialize<ClsModParametrosEmpresas>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModEmpresas objUsuarios = new ClsNegUsuarios().EliminarEmpresa(objUsuario, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("LogearseChoferes")]
        public ClsModResponse LogearseChoferes([FromBody] ClsModRequest objModRequest)
        {
            ClsModParametrosChoferes objModConteoFisico = ClsObjectTransformation.Deserialize<ClsModParametrosChoferes>(objModRequest.Model, objModRequest.Formato);
            ClsModResponse objModResponse = new ClsModResponse();
            ClsModResultado objModResultado = null;

            ClsModChoferes objUsuarios = new ClsNegChoferes().LogearseChoferes(objModConteoFisico, out objModResultado);
            objModResponse.Model = ClsObjectTransformation.SerializeObjectToString<object>(objUsuarios, objModRequest.Formato);

            objModResponse.ObjModResultado = objModResultado;


            return objModResponse;
        }
    }
}
