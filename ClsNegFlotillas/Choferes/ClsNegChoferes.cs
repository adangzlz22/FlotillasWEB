using ClsDatFlotillas;
using ClsDatFlotillas.Choferes;
using ClsModFlotillas.Bitacora;
using ClsModFlotillas.Choferes;
using ClsModFlotillas.Session;
using ClsModHarodoor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsNegFlotillas.Choferes
{
    public class ClsNegChoferes
    {
        public List<ClsModChoferes> ObtenerChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModChoferes> objUsuarios = new List<ClsModChoferes>();
            try
            {
                objUsuarios = new ClsDatChoferes().ObtenerChoferes(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModChoferes CrearEditarChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarios = new ClsModChoferes();
            try
            {
                objUsuarios = new ClsDatChoferes().CrearEditarChoferes(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModChoferes EliminarChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarios = new ClsModChoferes();
            try
            {
                objUsuarios = new ClsDatChoferes().EliminarChoferes(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModChoferes LogearseChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarios = new ClsModChoferes();
            try
            {
                objUsuarios = new ClsDatChoferes().LogearseChoferes(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModChoferes CrearInicioDeSession(ClsModParametrosSessionActiva objModel, string user, int idEmpresa, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarios = new ClsModChoferes();
            ClsModParametrosAppSessionActiva objSessionActiva = new ClsModParametrosAppSessionActiva();
            try
            {
                objUsuarios = new ClsDatChoferes().CrearInicioDeSession(objModel, user, idEmpresa, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModChoferes EjecutarExtracciondeUbicaciones(ClsModParametrosExtraccion objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarios = new ClsModChoferes();
            try
            {
                objUsuarios = new ClsDatChoferes().EjecutarExtracciondeUbicaciones(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public List<ClsModSessionActiva> ObtenerSessionesActivas(out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModSessionActiva> objUsuarios = new List<ClsModSessionActiva>();
            try
            {
                objUsuarios = new ClsDatChoferes().ObtenerSessionesActivas(out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public List<ClsModBitacora> ObtenerBitacoraEventos(ClsModParametrosBitacora objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModBitacora> objUsuarios = new List<ClsModBitacora>();
            try
            {
                objUsuarios = new ClsDatChoferes().ObtenerBitacoraEventos(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public List<ClsModBitacoraInformacion> ObtenerBitacoraInformacion(ClsModParametrosBitacora objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModBitacoraInformacion> objUsuarios = new List<ClsModBitacoraInformacion>();
            try
            {
                objUsuarios = new ClsDatChoferes().ObtenerBitacoraInformacion(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModBitacora GuardarBitacora(ClsModParamsBit objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModBitacora objUsuarios = new ClsModBitacora();
            try
            {
                objUsuarios = new ClsDatChoferes().GuardarBitacora(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModResultAppSessionActiva GuardarSessionAppActiva(ClsModParametrosAppSessionActiva objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModResultAppSessionActiva objUsuarios = new ClsModResultAppSessionActiva();
            try
            {
                objUsuarios = new ClsDatChoferes().GuardarSessionAppActiva(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModBitacora GuardarStatusActivo(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModBitacora objUsuarios = new ClsModBitacora();
            try
            {
                objUsuarios = new ClsDatChoferes().GuardarStatusActivo(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public List<ClsModResultAppSessionActiva> ExtraerBitacora(out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModResultAppSessionActiva> objUsuarios = new List<ClsModResultAppSessionActiva>();
            try
            {
                objUsuarios = new ClsDatChoferes().ExtraerBitacora(out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModBitacora EditarBitacora(ClsModParametrosBitacora objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModBitacora objUsuarios = new ClsModBitacora();
            try
            {
                objUsuarios = new ClsDatChoferes().EditarBitacora(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModResultStatusActivo BotonesStatus(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModResultStatusActivo objUsuarios = new ClsModResultStatusActivo();
            try
            {
                objUsuarios = new ClsDatChoferes().BotonesStatus(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }

        public estatusActivo ObtenerEstatusActivo(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            estatusActivo objUsuarios = new estatusActivo();
            try
            {
                objUsuarios = new ClsDatChoferes().ObtenerEstatusActivo(objParametros, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }

        public SessionAppActiva TieneSesionByIdChofer(int idChofer, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            SessionAppActiva isSessionActiva = new SessionAppActiva();
            try
            {
                isSessionActiva = new ClsDatChoferes().TieneSesionByIdChofer(idChofer, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return isSessionActiva;
        }

        public ClsModEnvioCorreo CrearCertificacion(ClsModEnvioCorreo objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModEnvioCorreo objUsuarios = new ClsModEnvioCorreo();
            try
            {
                objUsuarios = new ClsDatChoferes().CrearCertificacion(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }

        public List<ClsModEnvioCorreo> ObtenerCertificadosInspeccion(int idChofer, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEnvioCorreo> isSessionActiva = new List<ClsModEnvioCorreo>();
            try
            {
                isSessionActiva = new ClsDatChoferes().ObtenerCertificadosInspeccion(idChofer, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return isSessionActiva;
        }


    }
}
