using ClsModFlotillas.Bitacora;
using ClsModFlotillas.Choferes;
using ClsModFlotillas.Session;
using ClsModHarodoor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsDatFlotillas.Choferes
{
    public class ClsDatChoferes
    {
        public List<ClsModChoferes> ObtenerChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModChoferes> objUsuarioReturn = new List<ClsModChoferes>();
            try
            {
                objUsuarioReturn = db.CatChoferes.Where(r => r.idEmpresa == objModel.idEmpresa).ToList().Select(y => new ClsModChoferes
                {
                    id = y.id,
                    users = y.users,
                    pass = y.pass,
                    nombre = y.nombre,
                    apeidoP = y.apeidoP,
                    apeidoM = y.apeidoM,
                    idEmpresa = (int)y.idEmpresa,
                    Empresa = db.CatEmpresas.Where(r => r.id == y.idEmpresa).FirstOrDefault().Empresa,
                }).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuarioReturn;
        }
        public ClsModChoferes CrearEditarChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarioReturn = new ClsModChoferes();
            CatChoferes objChoferes = new CatChoferes();
            try
            {
                objChoferes = db.CatChoferes.Where(r => r.id == objModel.id).FirstOrDefault();
                if (objChoferes == null)
                {
                    objChoferes = new CatChoferes();
                    objChoferes.users = objModel.users;
                    objChoferes.pass = objModel.pass;
                    objChoferes.nombre = objModel.nombre;
                    objChoferes.apeidoP = objModel.apeidoP;
                    objChoferes.apeidoM = objModel.apeidoM;
                    objChoferes.idEmpresa = objModel.idEmpresa;
                    db.CatChoferes.Add(objChoferes);
                    db.SaveChanges();

                    objUsuarioReturn.status = 1;
                    objUsuarioReturn.mensaje = "Usuario guardado con exito.";
                }
                else
                {
                    objChoferes.users = objModel.users;
                    objChoferes.pass = objModel.pass;
                    objChoferes.nombre = objModel.nombre;
                    objChoferes.apeidoP = objModel.apeidoP;
                    objChoferes.apeidoM = objModel.apeidoM;
                    db.SaveChanges();

                    objUsuarioReturn.status = 2;
                    objUsuarioReturn.mensaje = "Usuario editado con exito.";
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuarioReturn;
        }
        public ClsModChoferes EliminarChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuarioReturn = new ClsModChoferes();
            CatChoferes objEmpresa = new CatChoferes();
            try
            {
                objEmpresa = db.CatChoferes.Where(r => r.id == objModel.id).FirstOrDefault();
                db.CatChoferes.Remove(objEmpresa);
                db.SaveChanges();
                objUsuarioReturn.status = 1;
                objUsuarioReturn.mensaje = "Usuario eliminado con exito.";
            }
            catch (Exception ex)
            {
                objUsuarioReturn.status = 4;
                objUsuarioReturn.mensaje = "Ocurrio algun problema.";
                throw;
            }

            return objUsuarioReturn;
        }
        public ClsModChoferes LogearseChoferes(ClsModParametrosChoferes objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuario = new ClsModChoferes();
            try
            {
                objUsuario = db.CatChoferes.Where(r => r.users == objModel.users && r.pass == objModel.pass).Select(y => new ClsModChoferes
                {
                    id = y.id,
                    users = y.users,
                    pass = y.pass,
                    idEmpresa = (int)y.idEmpresa,
                    passSmbTrack = db.CatUsuarios.Where(n => n.idEmpresa == y.idEmpresa).Select(g => g.passSmbTrack).FirstOrDefault(),
                    userSmbTrack = db.CatUsuarios.Where(n => n.idEmpresa == y.idEmpresa).Select(g => g.userSmbTrack).FirstOrDefault(),
                }).FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public ClsModChoferes CrearInicioDeSession(ClsModParametrosSessionActiva objModel, string user, int idEmpresa, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuario = new ClsModChoferes();
            try
            {
                sessionActiva obj = new sessionActiva();
                obj = db.sessionActiva.Where(r => r.correo == user && r.idEmpresa == idEmpresa && r.idUser == objModel.idUser).FirstOrDefault();
                if (obj == null)
                {
                    obj.idEmpresa = idEmpresa;
                    obj.accessToken = objModel.accessToken;
                    obj.idUser = objModel.idUser;
                    obj.keyUser = "smbtrack";
                    obj.correo = user;
                    db.sessionActiva.Add(obj);
                    db.SaveChanges();

                }
                else
                {
                    obj.accessToken = objModel.accessToken;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public ClsModChoferes EjecutarExtracciondeUbicaciones(ClsModParametrosExtraccion objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModChoferes objUsuario = new ClsModChoferes();
            try
            {




            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public List<ClsModSessionActiva> ObtenerSessionesActivas(out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModSessionActiva> objUsuario = new List<ClsModSessionActiva>();
            try
            {
                objUsuario = db.sessionActiva.ToList().Select(y => new ClsModSessionActiva
                {
                    accessToken = y.accessToken,
                    correo = y.correo,
                    idUser = y.idUser,
                    keyUser = y.keyUser,
                }).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public List<ClsModBitacora> ObtenerBitacoraEventos(ClsModParametrosBitacora objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModBitacora> objUsuario = new List<ClsModBitacora>();
            try
            {

                objUsuario = db.spObtenerExtraccionEvents(objModel.fechaActual, objModel.idChofer).Select(y => new ClsModBitacora
                {
                    id = y.id.ToString(),
                    resourceId = y.idEstado.ToString(),
                    start = y.fechaInicio,
                    end = y.fechaFin,
                }).ToList();


            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public List<ClsModBitacoraInformacion> ObtenerBitacoraInformacion(ClsModParametrosBitacora objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModBitacoraInformacion> objUsuario = new List<ClsModBitacoraInformacion>();
            try
            {

                objUsuario = db.spObtenerExtraccionInformacion(objModel.fechaActual, objModel.idChofer).Select(y => new ClsModBitacoraInformacion
                {
                    id = y.id,
                    idChofer = y.idChofer,
                    idEstado = y.idEstado,
                    fecha = y.fecha,
                    fechaInicio = y.fechaInicio,
                    fechaFin = y.fechaFin,
                    longitud = y.longitud,
                    latitud = y.latitud,
                    nombreUbicacion = y.nombreUbicacion,
                    EstadoAccion = y.EstadoAccion,

                }).ToList();


            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public ClsModBitacora GuardarBitacora(ClsModParamsBit objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModBitacora obj = new ClsModBitacora();
            Bitacora objUsuario = new Bitacora();
            try
            {

                objUsuario = db.Bitacora.Where(r => r.placa == objParametros.placa && r.fecha == objParametros.fecha && r.longitud == objParametros.logituf && r.latitud == objParametros.latitud).FirstOrDefault();
                if (objUsuario == null)
                {
                    if (objParametros.logituf != "" && objParametros.latitud != "")
                    {
                        objUsuario = new Bitacora();
                        objUsuario.idChofer = objParametros.idChofer;
                        objUsuario.idEstado = objParametros.idEstado;
                        objUsuario.fecha = objParametros.fecha;
                        objUsuario.fechaInicio = objParametros.fechaInicio;
                        objUsuario.fechaFin = objParametros.fechaFin;
                        objUsuario.longitud = objParametros.logituf;
                        objUsuario.latitud = objParametros.latitud;
                        objUsuario.placa = objParametros.placa;
                        objUsuario.nombreUbicacion = objParametros.nombreUbicacion;
                        objUsuario.Activo = true;

                        db.Bitacora.Add(objUsuario);
                        db.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return obj;
        }
        public ClsModResultAppSessionActiva GuardarSessionAppActiva(ClsModParametrosAppSessionActiva objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModResultAppSessionActiva obj = new ClsModResultAppSessionActiva();
            SessionAppActiva objUsuario = new SessionAppActiva();
            try
            {
                objUsuario = db.SessionAppActiva.Where(x => x.idChofer == objParametros.idChofer && x.inicioSession == true).FirstOrDefault();
                if (objUsuario == null)
                {
                    objUsuario = new SessionAppActiva();
                    objUsuario.idChofer = objParametros.idChofer;
                    objUsuario.inicioSession = objParametros.inicioSession;
                    objUsuario.fechaInicio = objParametros.fechaInicio;

                    db.SessionAppActiva.Add(objUsuario);
                    db.SaveChanges();

                    obj = db.SessionAppActiva.Where(x => x.idChofer == objParametros.idChofer && x.inicioSession == true).Select(y => new ClsModResultAppSessionActiva
                    {
                        id = (int)y.id,
                    }).FirstOrDefault();

                }
                else
                {

                    objUsuario.placa = objParametros.placa;
                    db.SaveChanges();

                    obj = db.SessionAppActiva.Where(x => x.idChofer == objParametros.idChofer && x.inicioSession == true).Select(y => new ClsModResultAppSessionActiva
                    {
                        id = (int)y.id,
                    }).FirstOrDefault();
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return obj;
        }
        public ClsModBitacora GuardarStatusActivo(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModBitacora obj = new ClsModBitacora();
            Bitacora objUsuario = new Bitacora();
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }

            return obj;
        }
        public List<ClsModResultAppSessionActiva> ExtraerBitacora(out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModResultAppSessionActiva> objUsuario = new List<ClsModResultAppSessionActiva>();
            try
            {
                objUsuario = db.SessionAppActiva.Where(r => r.inicioSession == true).ToList().Select(y => new ClsModResultAppSessionActiva
                {
                    id = y.id,
                    idChofer = (int)y.idChofer,
                    placa = y.placa
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public ClsModBitacora EditarBitacora(ClsModParametrosBitacora objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModBitacora obj = new ClsModBitacora();
            Bitacora objUsuario = new Bitacora();
            try
            {
                objUsuario = db.Bitacora.Where(r => r.id == objParametros.id).FirstOrDefault();
                if (objUsuario != null)
                {
                    objUsuario.Activo = false;
                    db.SaveChanges();

                    objUsuario.Activo = true;
                    objUsuario.idEstado = objParametros.idEstado;
                    db.Bitacora.Add(objUsuario);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return obj;
        }

        public ClsModResultStatusActivo BotonesStatus(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModResultStatusActivo obj = new ClsModResultStatusActivo();
            estatusActivo objUsuario = new estatusActivo();
            try
            {
                objUsuario = db.estatusActivo.Where(r => r.idChofer == objParametros.idChofer).FirstOrDefault();
                if (objUsuario == null)
                {
                    objUsuario = new estatusActivo();
                    objUsuario.idChofer = objParametros.idChofer;
                    objUsuario.idEstatus = objParametros.idEstatus;
                    objUsuario.fechaInicio = DateTime.Now;
                    db.estatusActivo.Add(objUsuario);
                    db.SaveChanges();
                }
                else
                {
                    objUsuario.idEstatus = objParametros.idEstatus;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return obj;
        }

        public estatusActivo ObtenerEstatusActivo(ClsModParametrosStatusActivo objParametros, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            estatusActivo objUsuario = new estatusActivo();
            try
            {
                objUsuario = db.estatusActivo.Where(r => r.idChofer == objParametros.idChofer).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }
    }
}
