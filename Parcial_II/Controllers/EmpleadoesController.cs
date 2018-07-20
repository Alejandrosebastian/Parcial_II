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
    public class EmpleadoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EmpleadoModel claseEmpleado;

        public EmpleadoesController(ApplicationDbContext context)
        {
            _context = context;
            claseEmpleado = new EmpleadoModel(context);
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        public List<object[]> Controladorlistaindexpro()
        {
            return claseEmpleado.ModeloListaempleado();
        }

        public List<IdentityError> ControladorGuardaEmpleado(string primernombre, string segundonombre, string primerapellido, string segundoapellido, string direccion,
           string salario,
           string correo,
            DateTime fecha_nacimiento,
             int edad,int UsuarioId,int Categoria_LaboralId)
        {
            return claseEmpleado.ModeloGrabaEmpleado(primernombre,segundonombre,primerapellido,segundoapellido,direccion,salario,correo,fecha_nacimiento,edad,UsuarioId,Categoria_LaboralId);
        }

        public List<Empleado> ControladorUnemple(int EmpleId)
        {
            var propie = (from p in _context.Empleado where p.EmpleadoId == EmpleId select p).ToList();
            return propie;
        }
        public List<IdentityError> ControladorEditarEmpleado(string primernombre, string segundonombre, string primerapellido, string segundoapellido, string direccion,
        string salario,
        string correo,
         DateTime fecha_nacimiento,
          int edad,
          int UsuarioId,
          int Categoria_LaboralId,int EmpleadoId)
        {
            return claseEmpleado.Modaleditaremple(primernombre, segundonombre, primerapellido, segundoapellido, direccion, salario, correo, fecha_nacimiento, edad, UsuarioId, Categoria_LaboralId,EmpleadoId);
        }
    }
}
