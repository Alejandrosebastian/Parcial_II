using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Parroquia
    {
        public int ParroquiaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escriba el nombre de la parroquia ")]
        public string Nombre { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
