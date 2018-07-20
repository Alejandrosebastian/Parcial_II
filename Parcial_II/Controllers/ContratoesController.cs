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
    public class ContratoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ContratoModel claseContrato;

        public ContratoesController(ApplicationDbContext context)
        {
            _context = context;
            claseContrato = new ContratoModel(context);
        }

        // GET: Contratoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propietario.ToListAsync());
        }
        //public List<object[]>Controladorlistaindex()
        //{
          //  return clasecontrato.ModeloListaContrato();
        //}
        public List<IdentityError> ControladorGuardarContrato(int deposito, string duracion,
            DateTime fecha_ini, DateTime fecha_vence, int tipopagoId, int sucursalId, int clienteId)
        {
            return claseContrato.ClaseGuardarContrato(deposito, duracion, fecha_ini, fecha_vence, tipopagoId, sucursalId, clienteId);
        }
        public List<Contrato>ControladorUnContrato(int ContId)
        {
            var contra = (from c in _context.Contrato where c.ContratoId == ContId select c).ToList();
            return contra;
        }
    }
}
