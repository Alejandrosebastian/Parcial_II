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
    public class InmueblesController : Controller
    {
        private readonly ApplicationDbContext _context;

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

        // GET: Inmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles
                .Include(i => i.Parroquia)
                .Include(i => i.Propietario)
                .Include(i => i.Tipos_inmu)
                .SingleOrDefaultAsync(m => m.InmueblesId == id);
            if (inmuebles == null)
            {
                return NotFound();
            }

            return View(inmuebles);
        }

        // GET: Inmuebles/Create
        public IActionResult Create()
        {
            ViewData["ParroquiaId"] = new SelectList(_context.Set<Parroquia>(), "ParroquiaId", "Nombre");
            ViewData["PropietarioId"] = new SelectList(_context.Set<Propietario>(), "PropietarioId", "Apellido1");
            ViewData["Tipos_inmuid"] = new SelectList(_context.Set<Tipos_inmu>(), "Tipos_inmuId", "nombre");
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InmueblesId,direccion,N_habitaciones,Costo,activo,PropietarioId,ParroquiaId,Tipos_inmuid")] Inmuebles inmuebles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inmuebles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParroquiaId"] = new SelectList(_context.Set<Parroquia>(), "ParroquiaId", "Nombre", inmuebles.ParroquiaId);
            ViewData["PropietarioId"] = new SelectList(_context.Set<Propietario>(), "PropietarioId", "Apellido1", inmuebles.PropietarioId);
            ViewData["Tipos_inmuid"] = new SelectList(_context.Set<Tipos_inmu>(), "Tipos_inmuId", "nombre", inmuebles.Tipos_inmuid);
            return View(inmuebles);
        }

        // GET: Inmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles.SingleOrDefaultAsync(m => m.InmueblesId == id);
            if (inmuebles == null)
            {
                return NotFound();
            }
            ViewData["ParroquiaId"] = new SelectList(_context.Set<Parroquia>(), "ParroquiaId", "Nombre", inmuebles.ParroquiaId);
            ViewData["PropietarioId"] = new SelectList(_context.Set<Propietario>(), "PropietarioId", "Apellido1", inmuebles.PropietarioId);
            ViewData["Tipos_inmuid"] = new SelectList(_context.Set<Tipos_inmu>(), "Tipos_inmuId", "nombre", inmuebles.Tipos_inmuid);
            return View(inmuebles);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InmueblesId,direccion,N_habitaciones,Costo,activo,PropietarioId,ParroquiaId,Tipos_inmuid")] Inmuebles inmuebles)
        {
            if (id != inmuebles.InmueblesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inmuebles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InmueblesExists(inmuebles.InmueblesId))
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
            ViewData["ParroquiaId"] = new SelectList(_context.Set<Parroquia>(), "ParroquiaId", "Nombre", inmuebles.ParroquiaId);
            ViewData["PropietarioId"] = new SelectList(_context.Set<Propietario>(), "PropietarioId", "Apellido1", inmuebles.PropietarioId);
            ViewData["Tipos_inmuid"] = new SelectList(_context.Set<Tipos_inmu>(), "Tipos_inmuId", "nombre", inmuebles.Tipos_inmuid);
            return View(inmuebles);
        }

        // GET: Inmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles
                .Include(i => i.Parroquia)
                .Include(i => i.Propietario)
                .Include(i => i.Tipos_inmu)
                .SingleOrDefaultAsync(m => m.InmueblesId == id);
            if (inmuebles == null)
            {
                return NotFound();
            }

            return View(inmuebles);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inmuebles = await _context.Inmuebles.SingleOrDefaultAsync(m => m.InmueblesId == id);
            _context.Inmuebles.Remove(inmuebles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InmueblesExists(int id)
        {
            return _context.Inmuebles.Any(e => e.InmueblesId == id);
        }
    }
}
