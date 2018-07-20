using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial_II.Data;
using Parcial_II.Models;

namespace Parcial_II.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private InmueblesModel claseinmuebles;

        public InmueblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inmuebles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inmuebles.Include(i => i.Parroquia).Include(i => i.Propietario).Include(i => i.Tipos_inmu);
            return View(await applicationDbContext.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaInmueble(String Direccion, String Nhabitcion, int cos, int Tipo, int Propio, int Parro, Boolean Activo)
        {
            return claseinmuebles.ModeloGrabaInmueble(Direccion, Nhabitcion, cos, Tipo, Propio, Parro, Activo);
        }

        public List<object[]> ControladorListaInmueble()
        {
            return claseinmuebles.ModeloListaInmueble();
        }
        public List<Tipos_inmu> ControladorUnInmueble(int inmuebleId)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var sexo = (from t in _context.Tipos_inmu
                        where t.Tipos_inmuId == inmuebleId
                        select t).ToList();
            return sexo;
        }

        public List<IdentityError> ControladorEditaInmueble(string direccion, string nhabitacion, int inmuebleid, int parra, int pro, int tipoinmuId, int costo, Boolean Activo)
        {
            return claseinmuebles.ModeloEditarInmueble(direccion, nhabitacion, inmuebleid, parra, pro, tipoinmuId, costo, Activo);
        }
        //public List<IdentityError> ControladorEliminarSexo(int id)
        //{
        //    return claseinmu.Model(id);
        //}
        public List<object[]> ContronladorImprimirInmuble()
        {
            return claseinmuebles.ModeloImpresionInmueble();
        }
    }
}
