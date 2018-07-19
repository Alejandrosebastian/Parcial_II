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
    public class Tipos_inmuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tipos_inmuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipos_inmu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos_inmu.ToListAsync());
        }

        // GET: Tipos_inmu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_inmu = await _context.Tipos_inmu
                .SingleOrDefaultAsync(m => m.Tipos_inmuId == id);
            if (tipos_inmu == null)
            {
                return NotFound();
            }

            return View(tipos_inmu);
        }

        // GET: Tipos_inmu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos_inmu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipos_inmuId,nombre")] Tipos_inmu tipos_inmu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipos_inmu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipos_inmu);
        }

        // GET: Tipos_inmu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_inmu = await _context.Tipos_inmu.SingleOrDefaultAsync(m => m.Tipos_inmuId == id);
            if (tipos_inmu == null)
            {
                return NotFound();
            }
            return View(tipos_inmu);
        }

        // POST: Tipos_inmu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipos_inmuId,nombre")] Tipos_inmu tipos_inmu)
        {
            if (id != tipos_inmu.Tipos_inmuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos_inmu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_inmuExists(tipos_inmu.Tipos_inmuId))
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
            return View(tipos_inmu);
        }

        // GET: Tipos_inmu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_inmu = await _context.Tipos_inmu
                .SingleOrDefaultAsync(m => m.Tipos_inmuId == id);
            if (tipos_inmu == null)
            {
                return NotFound();
            }

            return View(tipos_inmu);
        }

        // POST: Tipos_inmu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_inmu = await _context.Tipos_inmu.SingleOrDefaultAsync(m => m.Tipos_inmuId == id);
            _context.Tipos_inmu.Remove(tipos_inmu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipos_inmuExists(int id)
        {
            return _context.Tipos_inmu.Any(e => e.Tipos_inmuId == id);
        }
    }
}
