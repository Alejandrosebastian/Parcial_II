using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = " Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Salario")]
        public string Salario { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        public int UsuarioId { get; set; }


        public Usuario Usuario { get; set; }

        public int CategoriaLaboralId { get; set; }

        public Categoria_Laboral Categoria_Laboral { get; set; }

    }
}
