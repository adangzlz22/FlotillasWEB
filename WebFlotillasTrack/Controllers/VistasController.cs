using ClsDatFlotillas.clases;
using ClsModFlotillas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace WebFlotillasTrack.Controllers
{
    public class VistasController : Controller
    {
        // GET: Vistas

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logearse(string users,int idNivel,int idEmpresa)
        {
            if (Session["users"] == null)
            {
                Session["users"] = users;
                Session["idNivel"] = idNivel;
                Session["idEmpresa"] = idEmpresa;
                return RedirectToAction("Index", "Vistas");
            }
            else
            {
                return RedirectToAction("Index", "Vistas");
            }
            return View();
        }
        public ActionResult Index()
        {
            string users = (string)Session["users"];
            int idNivel = (int)Session["idNivel"];
            ViewBag.idNivel = idNivel;
            ViewBag.users = users;
            ViewBag.idEmpresa = (int)Session["idEmpresa"];
            ViewBag.Vista = "Index";
            return View();
        }

        public ActionResult Empresa()
        {
            string users = (string)Session["users"];
            int idNivel = (int)Session["idNivel"];
            ViewBag.idNivel = idNivel;
            ViewBag.users = users;
            ViewBag.idEmpresa = (int)Session["idEmpresa"];
            ViewBag.Vista = "Empresa";
            return View();
        }
        public ActionResult Bitacora()
        {
            string users = (string)Session["users"];
            int idNivel = (int)Session["idNivel"];
            ViewBag.idNivel = idNivel;
            ViewBag.users = users;
            ViewBag.idEmpresa = (int)Session["idEmpresa"];
            ViewBag.Vista = "Bitacora";
            return View();
        }
        public ActionResult Choferes()
        {
            string users = (string)Session["users"];
            int idNivel = (int)Session["idNivel"];
            ViewBag.idNivel = idNivel;
            ViewBag.users = users;
            ViewBag.idEmpresa = (int)Session["idEmpresa"];
            ViewBag.Vista = "Choferes";
            ViewBag.idEmpresa = Session["idEmpresa"];

            return View();
        }
        public ActionResult desLogearse()
        {
            Session["users"] = null;
            Session["idEmpresa"] = null;
            Session["idNivel"] = null;
            Session["idEmpresa"] = null;
            return RedirectToAction("Login", "Vistas");
        }
    }
}
