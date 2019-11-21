using ServiciosABC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaAbc.Controllers
{

    [Authorize]
    public class SoporteController : Controller
    {
         public string soporteNombre;
         private readonly ISoporte internos;
        private readonly ITickets interno;
        public SoporteController(ISoporte externos, ITickets externo)
        {
            internos = externos;
            interno = externo;


        }
        // GET: Soporte
        
        public ActionResult Index()
        {
            
                return View();
            
        }
        public ActionResult ListTickets()
        {
            soporteNombre = User.Identity.Name;
            return View(internos.tickesAsignados(soporteNombre));
        }
        // GET: Soporte/Details/5
        public ActionResult Details(int id)
        {
            return View(interno.getTickets(id));
        }
        /*
        // GET: Soporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soporte/Create
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
        }*/

        // GET: Soporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Soporte/Edit/5
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

        // GET: Soporte/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var unTicket = interno.getTickets(id);
            return View(unTicket);
        }

        // POST: Soporte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                interno.Cerrar(id);
                //interno.closeTik(NuevoTicket);
                return RedirectToAction("ListTickets");
            }
            catch
            {
                return View(Index());
            }
        }
        public ActionResult CloseSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}
