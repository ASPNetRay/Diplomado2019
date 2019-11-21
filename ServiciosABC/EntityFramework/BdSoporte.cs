using ServiciosABC.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.EntityFramework
{
   public class BdSoporte : DbContext
    {
        public DbSet<Soporte> unSoporte { get; set; }
        public BdSoporte() : base("SistemaDBA")
        {

        }
    }
}

  
         
