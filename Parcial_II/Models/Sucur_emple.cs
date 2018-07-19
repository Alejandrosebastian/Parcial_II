using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class Sucur_emple
    {
        public int Sucur_empleId { get; set; }
        public int SucursualesId { get; set; }
        public Sucursal Sucursal { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
