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
    public class PropietariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private PropitarioModel clasepropietario;

        public PropietariosController(ApplicationDbContext context)
        {
            _context = context;
            clasepropietario = new PropitarioModel(context);
        }

        // GET: Propietarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propietario.ToListAsync());
        }

        public List<object[]> Controladorlistaindexpro()
        {
            return clasepropietario.ModeloListapropietario();
        }

        public List<IdentityError> ControladorGuardaPropietario(string Nombre1, string Nombre2, string Apellido1, string Apellido2, string Direccion, string Correo, int Telefono)
        {
            return clasepropietario.ClaseGuardarPropietario(Nombre1, Nombre2, Apellido1, Apellido2, Direccion, Correo, Telefono);
        }
        public List<Propietario> ControladorUnpropi(int PropietarioId)
        {
            var propie = (from p in _context.Propietario where p.PropietarioId == PropietarioId select p).ToList();
            return propie;
        }
        public List<IdentityError> ControladorEditapropi(string Nombre1, string Nombre2, string Apellido1, string Apellido2, string Direccion, string Correo, int Telefono, int PropietarioId)
        {
            return clasepropietario.Modaleditarpro(Nombre1, Nombre2, Apellido1, Apellido2, Direccion, Correo, Telefono, PropietarioId);
        }
    }
}
