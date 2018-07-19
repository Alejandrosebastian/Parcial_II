using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escriba el nombre de la ciudad ")]
        public string Nombre { get; set; }
    }
}
