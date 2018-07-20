using Parcial_II.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial_II.Models
{
    public class EmpleadoModel
    {

        ApplicationDbContext _contexto;
        public EmpleadoModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }

    }
}
