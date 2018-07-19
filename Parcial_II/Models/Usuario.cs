using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Parcial_II.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = " Usuario")]
        public string Usuarios { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = " Clave")]
        public string Clave { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
