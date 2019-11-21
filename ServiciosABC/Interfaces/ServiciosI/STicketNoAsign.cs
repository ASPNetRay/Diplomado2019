using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosABC.EntityFramework;
using ServiciosABC.Objetos;

namespace ServiciosABC.Interfaces.ServiciosI
{
    public class STicketNoAsign : ITicketsNoAsign

    {
        private readonly BaseDatosNoneTickets ticketNoAsignado;
        public STicketNoAsign(BaseDatosNoneTickets data)
        {
            ticketNoAsignado = data;
        }
        public void Cerrar(int id)
        {
            var unTicket = ticketNoAsignado.TikectsNoAsignado.Single(e => e.codigo == id);
            ticketNoAsignado.TikectsNoAsignado.Remove(unTicket);
            ticketNoAsignado.SaveChanges();
        }

        public void closeTik(CloseT unTicket)
        {
            throw new NotImplementedException();
        }

        public void CrearNoAsignado(TicketNoAsign unTicket)
        {
            ticketNoAsignado.TikectsNoAsignado.Add(unTicket);
            ticketNoAsignado.SaveChanges();
        }

        public TicketNoAsign getTickets(int id)
        {
            return ticketNoAsignado.TikectsNoAsignado.SingleOrDefault(e => e.codigo == id);
        }

        public IEnumerable<TicketNoAsign> ListarTicketsNoAsignado()
        {
            return ticketNoAsignado.TikectsNoAsignado;
        }

        public void Modificar(TicketNoAsign unTicket)
        {
            throw new NotImplementedException();
        }
    }
}
