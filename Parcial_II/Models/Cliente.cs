using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Cedula de Cliente")]
        [StringLength(10, ErrorMessage = "El numero de cedula debe tener 10  caracteres")]
        public int Cedula { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Nombre")]
        public string Primernombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Nombre")]
        public string Segundonombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Paterno")]
        public string Primerapellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "   aPELLIDO Materno")]
        public string Segundoapellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Email")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo Inmueble")]
        public string Tipo_prefe_inmueble { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Importe")]
        public int Importe_maximo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha")]
        public DateTime Fecha_registro { get; set; }
    }
}
