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
    public class Categoria_LaboralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Categoria_LaboralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categoria_Laboral
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria_Laboral.ToListAsync());
        }

        // GET: Categoria_Laboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Laboral = await _context.Categoria_Laboral
                .SingleOrDefaultAsync(m => m.Categoria_LaboralId == id);
            if (categoria_Laboral == null)
            {
                return NotFound();
            }

            return View(categoria_Laboral);
        }

        // GET: Categoria_Laboral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Laboral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categoria_LaboralId,Nombre")] Categoria_Laboral categoria_Laboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria_Laboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria_Laboral);
        }

        // GET: Categoria_Laboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Laboral = await _context.Categoria_Laboral.SingleOrDefaultAsync(m => m.Categoria_LaboralId == id);
            if (categoria_Laboral == null)
            {
                return NotFound();
            }
            return View(categoria_Laboral);
        }

        // POST: Categoria_Laboral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Categoria_LaboralId,Nombre")] Categoria_Laboral categoria_Laboral)
        {
            if (id != categoria_Laboral.Categoria_LaboralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria_Laboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoria_LaboralExists(categoria_Laboral.Categoria_LaboralId))
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
            return View(categoria_Laboral);
        }

        // GET: Categoria_Laboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Laboral = await _context.Categoria_Laboral
                .SingleOrDefaultAsync(m => m.Categoria_LaboralId == id);
            if (categoria_Laboral == null)
            {
                return NotFound();
            }

            return View(categoria_Laboral);
        }

        // POST: Categoria_Laboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria_Laboral = await _context.Categoria_Laboral.SingleOrDefaultAsync(m => m.Categoria_LaboralId == id);
            _context.Categoria_Laboral.Remove(categoria_Laboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoria_LaboralExists(int id)
        {
            return _context.Categoria_Laboral.Any(e => e.Categoria_LaboralId == id);
        }
    }
}
