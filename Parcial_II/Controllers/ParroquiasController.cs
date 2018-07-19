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
    public class ParroquiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParroquiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parroquias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parroquia.Include(p => p.Ciudad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parroquias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parroquia = await _context.Parroquia
                .Include(p => p.Ciudad)
                .SingleOrDefaultAsync(m => m.ParroquiaId == id);
            if (parroquia == null)
            {
                return NotFound();
            }

            return View(parroquia);
        }

        // GET: Parroquias/Create
        public IActionResult Create()
        {
            ViewData["CiudadId"] = new SelectList(_context.Ciudad, "CiudadId", "Nombre");
            return View();
        }

        // POST: Parroquias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParroquiaId,Nombre,CiudadId")] Parroquia parroquia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parroquia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudad, "CiudadId", "Nombre", parroquia.CiudadId);
            return View(parroquia);
        }

        // GET: Parroquias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parroquia = await _context.Parroquia.SingleOrDefaultAsync(m => m.ParroquiaId == id);
            if (parroquia == null)
            {
                return NotFound();
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudad, "CiudadId", "Nombre", parroquia.CiudadId);
            return View(parroquia);
        }

        // POST: Parroquias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParroquiaId,Nombre,CiudadId")] Parroquia parroquia)
        {
            if (id != parroquia.ParroquiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parroquia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParroquiaExists(parroquia.ParroquiaId))
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
            ViewData["CiudadId"] = new SelectList(_context.Ciudad, "CiudadId", "Nombre", parroquia.CiudadId);
            return View(parroquia);
        }

        // GET: Parroquias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parroquia = await _context.Parroquia
                .Include(p => p.Ciudad)
                .SingleOrDefaultAsync(m => m.ParroquiaId == id);
            if (parroquia == null)
            {
                return NotFound();
            }

            return View(parroquia);
        }

        // POST: Parroquias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parroquia = await _context.Parroquia.SingleOrDefaultAsync(m => m.ParroquiaId == id);
            _context.Parroquia.Remove(parroquia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParroquiaExists(int id)
        {
            return _context.Parroquia.Any(e => e.ParroquiaId == id);
        }
    }
}
