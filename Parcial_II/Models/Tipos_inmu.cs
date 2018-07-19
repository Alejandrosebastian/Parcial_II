using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Tipos_inmu
    {
        public int Tipos_inmuId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo de immueble")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El Tipo de Inmueble debe estar entre 3 y 220 caracteres")]
        public String nombre { get; set; }
    }
}
