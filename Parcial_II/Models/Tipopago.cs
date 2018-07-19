using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Parcial_II.Models
{
    public class Tipopago
    {
        public int TipopagoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre de tipo pago")]
        public String Nombre_tipopago { get; set; }
    }
}
