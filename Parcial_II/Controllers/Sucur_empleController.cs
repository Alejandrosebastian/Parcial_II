using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial_II.Data;
using Parcial_II.Models;

namespace Parcial_II.Controllers
{
    public class Sucur_empleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Sucur_empleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sucur_emple
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sucur_emple.Include(s => s.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sucur_emple/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucur_emple = await _context.Sucur_emple
                .Include(s => s.Empleado)
                .SingleOrDefaultAsync(m => m.Sucur_empleId == id);
            if (sucur_emple == null)
            {
                return NotFound();
            }

            return View(sucur_emple);
        }

        // GET: Sucur_emple/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Correo");
            return View();
        }

        // POST: Sucur_emple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sucur_empleId,SucursualesId,EmpleadoId")] Sucur_emple sucur_emple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucur_emple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Correo", sucur_emple.EmpleadoId);
            return View(sucur_emple);
        }

        // GET: Sucur_emple/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucur_emple = await _context.Sucur_emple.SingleOrDefaultAsync(m => m.Sucur_empleId == id);
            if (sucur_emple == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Correo", sucur_emple.EmpleadoId);
            return View(sucur_emple);
        }

        // POST: Sucur_emple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sucur_empleId,SucursualesId,EmpleadoId")] Sucur_emple sucur_emple)
        {
            if (id != sucur_emple.Sucur_empleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucur_emple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sucur_empleExists(sucur_emple.Sucur_empleId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Correo", sucur_emple.EmpleadoId);
            return View(sucur_emple);
        }

        // GET: Sucur_emple/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucur_emple = await _context.Sucur_emple
                .Include(s => s.Empleado)
                .SingleOrDefaultAsync(m => m.Sucur_empleId == id);
            if (sucur_emple == null)
            {
                return NotFound();
            }

            return View(sucur_emple);
        }

        // POST: Sucur_emple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucur_emple = await _context.Sucur_emple.SingleOrDefaultAsync(m => m.Sucur_empleId == id);
            _context.Sucur_emple.Remove(sucur_emple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sucur_empleExists(int id)
        {
            return _context.Sucur_emple.Any(e => e.Sucur_empleId == id);
        }
    }
}
