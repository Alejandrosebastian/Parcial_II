using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Inmuebles
    {
        public int InmueblesId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escriba la direccion del inmueble")]
        public String direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Numenro de habitacion")]
        public String N_habitaciones { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "El valor que tendra la havitacion")]
        public int Costo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = " ")]
        public Boolean activo { get; set; }

        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }

        public int ParroquiaId { get; set; }
        public Parroquia Parroquia { get; set; }

        public int Tipos_inmuid { get; set; }
        public Tipos_inmu Tipos_inmu { get; set; }
    }
}
