using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Direccion o Ubicacion ")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }
        public int ParroquiaId { get; set; }
        public Parroquia Parroquia { get; set; }
    }
}
