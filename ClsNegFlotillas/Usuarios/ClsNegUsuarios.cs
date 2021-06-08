using ClsDatFlotillas;
using ClsDatFlotillas.Usuarios;
using ClsModFlotillas.Empresas;
using ClsModFlotillas.Usuarios;
using ClsModHarodoor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsNegFlotillas.Usuarios
{
   public  class ClsNegUsuarios
    {
        public ClsModUsuarios Login(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuarios = new ClsModUsuarios();

            try
            {
                objUsuarios = new ClsDatUsuarios().Login(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return objUsuarios;
        }
        public List<ClsModUsuarios> ObtenerUsuarioYEmpresa(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModUsuarios> objUsuarios = new List<ClsModUsuarios>();

            try
            {
                objUsuarios = new ClsDatUsuarios().ObtenerUsuarioYEmpresa(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuarios;
        }
        public ClsModUsuarios CrearEditarUsuario(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuarios = new ClsModUsuarios();
            try
            {
                objUsuarios = new ClsDatUsuarios().CrearEditarUsuario(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModUsuarios EliminarUsuario(ClsModParametrosUsuarios objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModUsuarios objUsuarios = new ClsModUsuarios();
            try
            {
                objUsuarios = new ClsDatUsuarios().EliminarUsuario(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public List<ClsModEmpresas> ObtenerEmpresas(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEmpresas> objUsuarios = new List<ClsModEmpresas>();
            try
            {
                objUsuarios = new ClsDatUsuarios().ObtenerEmpresas(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModEmpresas CrearEditarEmpresa(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModEmpresas objUsuarios = new ClsModEmpresas();
            try
            {
                objUsuarios = new ClsDatUsuarios().CrearEditarEmpresa(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }
        public ClsModEmpresas EliminarEmpresa(ClsModParametrosEmpresas objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            ClsModEmpresas objUsuarios = new ClsModEmpresas();
            try
            {
                objUsuarios = new ClsDatUsuarios().EliminarEmpresa(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuarios;
        }

    }
}
