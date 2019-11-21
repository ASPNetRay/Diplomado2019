using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.Interfaces
{
    public interface ITicketsNoAsign
    {
       
        IEnumerable<TicketNoAsign> ListarTicketsNoAsignado();
        TicketNoAsign getTickets(int id);
        
        void CrearNoAsignado(TicketNoAsign unTicket);
        void Modificar(TicketNoAsign unTicket);
        void Cerrar(int id);
        void closeTik(CloseT unTicket);
    }
}
