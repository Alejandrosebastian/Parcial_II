using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial_II.Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Deposito")]
        public int deposito { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Duracion")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "la duracion debe estar entre 3 y 220 caracteres")]
        public string Duracion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha de inicio")]
        public DateTime fecha_ini { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha vencimiento")]
        public DateTime fecha_vence { get; set; }

        public int TipopagosId { get; set; }

        public Tipopago Tipopago { get; set; }

        public int SucursalId { get; set; }

        public Sucursal Sucursal { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
