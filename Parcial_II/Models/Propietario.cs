using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Propietario
    {
        public int PropietarioId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Nombre")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El primer nombre debe estar entre 3 y 220 caracteres")]
        public String Nombre1 { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Nombre")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El segundo nombre debe estar entre 3 y 220 caracteres")]
        public String Nombre2 { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Apellido")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El primer apellido debe estar entre 3 y 220 caracteres")]
        public String Apellido1 { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Apellido")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El segundo apellido debe estar entre 3 y 220 caracteres")]
        public String Apellido2 { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dirreccion")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El direccion debe estar entre 3 y 220 caracteres")]
        public String Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El correo debe estar entre 3 y 220 caracteres")]
        public String Correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

    }
}
