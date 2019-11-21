using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.Interfaces
{
    public interface ITickets
    {
        IEnumerable<Tickets> ListarTickets();
        IEnumerable<Tickets> ListarTickets(string soporte);
        Tickets getTickets(int id);
        void Crear(Tickets unTicket);
       
        void Modificar(Tickets unTicket);
        void Cerrar(int id);
        void closeTik(CloseT unTicket);
    }
}
