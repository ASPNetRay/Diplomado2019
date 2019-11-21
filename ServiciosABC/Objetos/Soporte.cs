using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.Objetos
{
    public class Soporte
    {
        [Key]
        [Display(Name = "Codigo de Empleado")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
    }
}
