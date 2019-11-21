using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.EntityFramework
{
    public class BaseDatosCloseTickets : DbContext
    {
        public DbSet<CloseT> CloseTikects { get; set; }
        public BaseDatosCloseTickets() : base("SistemaDBA")
        {

        }
    }
}
