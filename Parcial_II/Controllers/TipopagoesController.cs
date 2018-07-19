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
    public class TipopagoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipopagoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipopagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipopago.ToListAsync());
        }

        // GET: Tipopagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopago = await _context.Tipopago
                .SingleOrDefaultAsync(m => m.TipopagoId == id);
            if (tipopago == null)
            {
                return NotFound();
            }

            return View(tipopago);
        }

        // GET: Tipopagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipopagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipopagoId,Nombre_tipopago")] Tipopago tipopago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipopago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipopago);
        }

        // GET: Tipopagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopago = await _context.Tipopago.SingleOrDefaultAsync(m => m.TipopagoId == id);
            if (tipopago == null)
            {
                return NotFound();
            }
            return View(tipopago);
        }

        // POST: Tipopagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipopagoId,Nombre_tipopago")] Tipopago tipopago)
        {
            if (id != tipopago.TipopagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipopago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipopagoExists(tipopago.TipopagoId))
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
            return View(tipopago);
        }

        // GET: Tipopagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopago = await _context.Tipopago
                .SingleOrDefaultAsync(m => m.TipopagoId == id);
            if (tipopago == null)
            {
                return NotFound();
            }

            return View(tipopago);
        }

        // POST: Tipopagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipopago = await _context.Tipopago.SingleOrDefaultAsync(m => m.TipopagoId == id);
            _context.Tipopago.Remove(tipopago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipopagoExists(int id)
        {
            return _context.Tipopago.Any(e => e.TipopagoId == id);
        }
    }
}
