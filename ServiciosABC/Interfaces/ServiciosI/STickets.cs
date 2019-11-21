using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using ServiciosABC.EntityFramework;

namespace ServiciosABC.Interfaces.ServiciosI
{
    public class STickets : ITickets
    {
        private readonly BaseDatosTickets ticketAsignado;
        private readonly BaseDatosCloseTickets ticketClose;
       
        public STickets(BaseDatosTickets data, BaseDatosCloseTickets data2)
        {
            ticketAsignado = data;
            ticketClose = data2;
            
        }

        public void Cerrar(int id)
        {

            var unTicket = ticketAsignado.Tikects.Single(e => e.codigo == id);
            ticketAsignado.Tikects.Remove(unTicket);
            ticketAsignado.SaveChanges();
        }

        public void closeTik(CloseT unTicket)
        {
            var closet = unTicket;
            ticketClose.CloseTikects.Add(closet);
        }
        public void Crear(Tickets unTicket)

        {
            /*
            var codigoDinamigo = getTickets(unTicket.codigo);
            
            if (codigoDinamigo==null)
            {
                nuevoCod = 2019001;
            } else
            {
                nuevoCod = Int32.Parse(codigoDinamigo.ToString());
                nuevoCod++;
            }
            unTicket.codigo = nuevoCod;*/
            ticketAsignado.Tikects.Add(unTicket);
            ticketAsignado.SaveChanges();
        }

        

       
        public Tickets getTickets(int codigo)
        {

            return ticketAsignado.Tikects.SingleOrDefault(e => e.codigo == codigo);
        }

     
        public IEnumerable<Tickets> ListarTickets()
        {
            return ticketAsignado.Tikects ;
        }

        public IEnumerable<Tickets> ListarTickets(string soporte)
        {
            return ticketAsignado.Tikects;
            //return ticketAsignado.Tikects(e => e.soporteAsignado == soporte);
        }

        public void Modificar(Tickets unTicket)
        {
            var modTicket = ticketAsignado.Tikects.Single(e => e.codigo == unTicket.codigo);
            modTicket.soporteAsignado = unTicket.soporteAsignado;
            modTicket.InfAdicional = unTicket.InfAdicional;
            ticketAsignado.SaveChanges();
        }
    }
}
