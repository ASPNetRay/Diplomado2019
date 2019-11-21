using ServiciosABC.Interfaces;
using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;

namespace SistemaAbc.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITickets interno;
        private readonly ISoporte internos;
        private readonly ITicketsNoAsign interno2;

        public TicketsController(ITickets externo, ISoporte externos, ITicketsNoAsign externo2)
        {
            interno = externo;
            internos = externos;
            interno2 = externo2; 

        }
        void llenarComboSoporte()
        {
            var lista = internos.listarTecnico();
            var soportes = new List<SelectListItem>();

            for (int x = 0; x < lista.Tables[0].Rows.Count; x++)
            {
                soportes = new List<SelectListItem>{
                new SelectListItem { Text = lista.Tables[0].Rows[x]["Empleado"].ToString(),
                                    Value = lista.Tables[0].Rows[x]["Empleado"].ToString()}
                };
            }
            ViewBag.soporteAsignado = soportes;


    }
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ListTickets()
        {
            return View(interno.ListarTickets());
        }
        public ActionResult ListTicketsPending()
        {
            return View(interno2.ListarTicketsNoAsignado());
        }

        public ActionResult Details(int id)
        {
            return View(interno.getTickets(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            //llenarComboSoporte();
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        public ActionResult Create(Tickets NuevoTicket)
        {
            TicketNoAsign Nuevoti = new TicketNoAsign();
            Nuevoti.codigo = Int32.Parse(NuevoTicket.codigo.ToString());
            Nuevoti.cliente = NuevoTicket.cliente;
            Nuevoti.descripcion = NuevoTicket.descripcion;
            Nuevoti.fechaSolicitud = NuevoTicket.fechaSolicitud;
            Nuevoti.soporteAsignado = NuevoTicket.soporteAsignado;
            Nuevoti.InfAdicional = NuevoTicket.InfAdicional;


            try
            {
                if(NuevoTicket.soporteAsignado != null) {
                interno.Crear(NuevoTicket);
                } else { interno2.CrearNoAsignado(Nuevoti); }

                return RedirectToAction("ListTickets");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            
                var unTicket = interno.getTickets(id);
                return View(unTicket);
           
            
            
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("ListTickets");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            var unTicket = interno.getTickets(id);
            return View(unTicket);
        }

        // POST: Tickets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CloseT NuevoTicket)
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

        [HttpGet]
        public ActionResult SoporteReg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SoporteReg(Soporte Nuevo)
        {
            internos.registrar(Nuevo);
            return View("Index");
        }
        public ActionResult CloseSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}
