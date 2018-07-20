using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Parcial_ll.Models;
using Parcial_II.Data;
using Parcial_II.Models;

namespace Parcial_ll.Controllers
{
    public class Tipos_inmusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Tipos_inmuModels claseinmu;

        public Tipos_inmusController(ApplicationDbContext context)
        {
            _context = context;
            claseinmu = new Tipos_inmuModels(context);
        }

        // GET: Tipos_inmus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos_inmu.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaTipoinmu(string nombre)
        {
            return claseinmu.ModeloGrabaTipos_inmu(nombre);
        }

        public List<object[]> ControladorListaTipo_inmu()
        {
            return claseinmu.ModeloListaTipoinmu();
        }
        public List<Tipos_inmu> ControladorUnTipoinmu(int tipoinmuId)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var sexo = (from t in _context.Tipos_inmu
                        where t.Tipos_inmuId == tipoinmuId
                        select t).ToList();
            return sexo;
        }

        public List<IdentityError> ControladorEditaTipoinmu(int id, string nombre)
        {
            return claseinmu.ModeloEditarTipoinmu(id, nombre);
        }
        //public List<IdentityError> ControladorEliminarSexo(int id)
        //{
        //    return claseinmu.Model(id);
        //}
        public List<object[]> ContronladorImprimirTipoinmu()
        {
            return claseinmu.ModeloImpresionTipo_inmu();
        }
    }
}