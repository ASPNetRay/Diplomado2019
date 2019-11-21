using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.EntityFramework
{
   public class BaseDatosNoneTickets : DbContext
    {
        public DbSet<TicketNoAsign> TikectsNoAsignado { get; set; }
        public BaseDatosNoneTickets() : base("SistemaDBA")
        {

        }
    }
}
