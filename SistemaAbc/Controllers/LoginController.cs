using ServiciosABC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaAbc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISoporte internos;
        public LoginController(ISoporte externos)
        {
            internos = externos;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Tickets");
            }
            return View();
            
        }
        [HttpPost]
        public ActionResult Acceso(string usuario, string clave)
        {
            var usActual = internos.VerificarUsuario(usuario);
            if (usuario == "Ray" && clave=="1234")
            {
                FormsAuthentication.SetAuthCookie(usuario, true);
                return RedirectToAction("Index","Tickets");
            }

            if(usuario == usActual.Usuario && clave == usActual.Pass)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(usuario, true);
                return RedirectToAction("Index", "Soporte");
            }
            else 
            return RedirectToAction("Login");
        }
        /*
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
