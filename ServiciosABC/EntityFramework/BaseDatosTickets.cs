using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ServiciosABC.Objetos;

namespace ServiciosABC.EntityFramework
{
    public class BaseDatosTickets : DbContext
    {
        public DbSet<Tickets> Tikects { get; set; }
        
        public BaseDatosTickets() : base("SistemaDBA")
        {

        }
    }
}
