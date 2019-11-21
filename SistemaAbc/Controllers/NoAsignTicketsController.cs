using ServiciosABC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAbc.Controllers
{
    [Authorize]
    public class NoAsignTicketsController : Controller
    {
        // GET: NoAsignTickets
        private readonly ITicketsNoAsign interno2;
        public NoAsignTicketsController(ITicketsNoAsign externo2)
        {
            interno2 = externo2;

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListTicketsPending()
        {
            return View(interno2.ListarTicketsNoAsignado());
        }

        // GET: NoAsignTickets/Details/5
        public ActionResult Details(int id)
        {
            return View(interno2.getTickets(id));
        }

        // GET: NoAsignTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoAsignTickets/Create
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var unTicket = interno2.getTickets(id);
            return View(unTicket);
        }

        // POST: NoAsignTickets/Edit/5
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

       [HttpGet]
        public ActionResult Delete(int id)
        {
            var unTicket = interno2.getTickets(id);
            return View(unTicket);
        }

        // POST: NoAsignTickets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                interno2.Cerrar(id);
                //interno.closeTik(NuevoTicket);
                return RedirectToAction("ListTicketsPending");
            }
            catch
            {
                return View(Index());
            }
        }
    }
}
