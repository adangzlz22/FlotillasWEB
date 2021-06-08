using ClsModFlotillas.Empresas;
using ClsModFlotillas.Usuarios;
using ClsModHarodoor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsDatFlotillas.Usuarios
{
    public class ClsDatUsuarios
    {
        public ClsModUsuarios Login(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuario = new ClsModUsuarios();
            try
            {
                objUsuario = db.CatUsuarios.Where(r => r.users == objModel.users && r.pass == objModel.pass).Select(y => new ClsModUsuarios
                {
                    users = y.users,
                    pass = y.pass,
                    idNivel = (int)y.idNivel,
                    idEmpresa = (int)y.idEmpresa,
                }).FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
        public List<ClsModUsuarios> ObtenerUsuarioYEmpresa(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModUsuarios> objUsuarioReturn = new List<ClsModUsuarios>();
            try
            {
                objUsuarioReturn = db.spObtenerUsuario().ToList().Select(y => new ClsModUsuarios
                {
                    id = y.id,
                    users = y.users,
                    pass = y.pass,
                    correo = y.correo,
                    nombre = y.nombre,
                    apeidoPaterno = y.apeidoPaterno,
                    apeidoMaterno = y.apeidoMaterno,
                    idNivel = (int)y.idNivel,
                    idEmpresa = (int)y.idEmpresa,
                    Empresa = y.Empresa
                }).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }

            return objUsuarioReturn;
        }
        public ClsModUsuarios CrearEditarUsuario(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuarioReturn = new ClsModUsuarios();
            CatUsuarios objUsuario = new CatUsuarios();
            try
            {
                objUsuario = db.CatUsuarios.Where(r => r.id == objModel.id).FirstOrDefault();
                if (objUsuario == null)
                {
                    objUsuario = new CatUsuarios();
                    objUsuario.nombre = objModel.nombre;
                    objUsuario.apeidoPaterno = objModel.ApeidoP;
                    objUsuario.apeidoMaterno = objModel.ApeidoM;
                    objUsuario.correo = objModel.Correo;
                    objUsuario.idNivel = 1;
                    objUsuario.idEmpresa = objModel.idEmpresa;
                    objUsuario.pass = objModel.pass;
                    objUsuario.users = objModel.users;
                    objUsuario.userSmbTrack = objModel.userSmbTrack;
                    objUsuario.passSmbTrack = objModel.passSmbTrack;
                    db.CatUsuarios.Add(objUsuario);
                    db.SaveChanges();

                    objUsuarioReturn.status = 1;
                    objUsuarioReturn.mensaje = "Usuario guardado con exito.";
                }
                else
                {
                    objUsuario.nombre = objModel.nombre;
                    objUsuario.apeidoPaterno = objModel.ApeidoP;
                    objUsuario.apeidoMaterno = objModel.ApeidoM;
                    objUsuario.correo = objModel.Correo;
                    objUsuario.idEmpresa = objModel.idEmpresa;
                    objUsuario.pass = objModel.pass;
                    objUsuario.users = objModel.users;
                    objUsuario.nombre = objModel.nombre;
                    objUsuario.userSmbTrack = objModel.userSmbTrack;
                    objUsuario.passSmbTrack = objModel.passSmbTrack;
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
        public ClsModUsuarios EliminarUsuario(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuarioReturn = new ClsModUsuarios();
            CatUsuarios objUsuario = new CatUsuarios();
            try
            {
                objUsuario = db.CatUsuarios.Where(r => r.id == objModel.id).FirstOrDefault();
                db.CatUsuarios.Remove(objUsuario);
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
        public List<ClsModEmpresas> ObtenerEmpresas(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            List<ClsModEmpresas> objUsuarioReturn = new List<ClsModEmpresas>();
            try
            {
                objUsuarioReturn = db.CatEmpresas.ToList().Select(y => new ClsModEmpresas
                {
                    id = y.id,
                    Empresa = y.Empresa
                }).ToList();

            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuarioReturn;
        }
        public ClsModEmpresas CrearEditarEmpresa(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModEmpresas objUsuarioReturn = new ClsModEmpresas();
            CatEmpresas objEmpresa = new CatEmpresas();
            try
            {
                objEmpresa = db.CatEmpresas.Where(r => r.id == objModel.id).FirstOrDefault();
                if (objEmpresa == null)
                {
                    objEmpresa = new CatEmpresas();
                    objEmpresa.Empresa = objModel.Empresa;
                    db.CatEmpresas.Add(objEmpresa);
                    db.SaveChanges();

                    objUsuarioReturn.status = 1;
                    objUsuarioReturn.mensaje = "Usuario guardado con exito.";
                }
                else
                {
                    objEmpresa.Empresa = objModel.Empresa;
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
        public ClsModEmpresas EliminarEmpresa(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            dbFlotillasCamionEntities db = new dbFlotillasCamionEntities();
            objClsModResultado = new ClsModResultado();
            ClsModEmpresas objUsuarioReturn = new ClsModEmpresas();
            CatEmpresas objEmpresa = new CatEmpresas();
            try
            {
                objEmpresa = db.CatEmpresas.Where(r => r.id == objModel.id).FirstOrDefault();
                db.CatEmpresas.Remove(objEmpresa);
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

    }
}
