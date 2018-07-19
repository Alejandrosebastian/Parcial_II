using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
