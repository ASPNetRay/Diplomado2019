using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosABC.Objetos
{
    public class CloseT
    {
        [Key]
        [Display(Name = "Codigo de Ticket")]
        public int codigo { get; set; }

        [Display(Name = "Requerido Por")]
        public string cliente { get; set; }

        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaSolicitud { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Soporte Asignado")]
        public string soporteAsignado { get; set; }

        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
    }
}
