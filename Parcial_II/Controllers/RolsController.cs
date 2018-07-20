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
    public class RolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private RolModel claserol;


        public RolsController(ApplicationDbContext context)
        {
            _context = context;
            claserol = new RolModel(context);

        }

        // GET: Rols
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rol.ToListAsync());
        }

        public List<object[]> Controladorlistaindexrol()
        {
            return claserol.ModeloListarol();
        }

        public List<IdentityError> ControladorGuardaRol(string Nombre)
        {
            return claserol.ClaseGuardarRol(Nombre);
        }

        public List<Rol> ControladorUnrol(int rolId)
        {
            var rol = (from p in _context.Rol where p.RolId == rolId select p).ToList();
            return rol;
        }
        public List<IdentityError> ControladorEditarol(string Nombre, int RolId)
        {
            return claserol.Modaleditarrol(Nombre,RolId);
        }
    }
}