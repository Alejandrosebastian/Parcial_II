using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Parcial_II.Data;
using Parcial_II.Models;

namespace Parcial_II.Controllers
{
    public class CiudadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CiudadModels claseciudad;

        public CiudadsController(ApplicationDbContext context)
        {
            _context = context;
            claseciudad = new CiudadModels(context);
            
        }
        // GET: Ciudads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ciudad.ToListAsync());
        }
        public List<object[]> Controladorlistaindexciud()
        {
            return claseciudad.ModeloListaCiudad();
        }
        public List<IdentityError> ControladorGuardaCiudad(string Nombre)
        {
            return claseciudad.ClaseGuardarCiudad(Nombre);
        }
        public List<Ciudad> ControlunaCiudad(int Ciuid)
        {
            var ciu = (from c in _context.Ciudad where c.CiudadId == Ciuid select c).ToList();
            return ciu;
        }
        // GET: Ciudads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiudadId,Nombre")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudad == null)
            {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiudadId,Nombre")] Ciudad ciudad)
        {
            if (id != ciudad.CiudadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadExists(ciudad.CiudadId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _context.Ciudad.SingleOrDefaultAsync(m => m.CiudadId == id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudad.Any(e => e.CiudadId == id);
        }
    }
}
