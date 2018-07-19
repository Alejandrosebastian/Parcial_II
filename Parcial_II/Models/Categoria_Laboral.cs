using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Categoria_Laboral
    {
        public int Categoria_LaboralId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
