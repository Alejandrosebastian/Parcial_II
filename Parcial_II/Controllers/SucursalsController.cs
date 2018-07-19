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
    public class SucursalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sucursals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sucursal.Include(s => s.Parroquia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal
                .Include(s => s.Parroquia)
                .SingleOrDefaultAsync(m => m.SucursalId == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursals/Create
        public IActionResult Create()
        {
            ViewData["ParroquiaId"] = new SelectList(_context.Parroquia, "ParroquiaId", "Nombre");
            return View();
        }

        // POST: Sucursals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SucursalId,Direccion,Telefono,ParroquiaId")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParroquiaId"] = new SelectList(_context.Parroquia, "ParroquiaId", "Nombre", sucursal.ParroquiaId);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal.SingleOrDefaultAsync(m => m.SucursalId == id);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewData["ParroquiaId"] = new SelectList(_context.Parroquia, "ParroquiaId", "Nombre", sucursal.ParroquiaId);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SucursalId,Direccion,Telefono,ParroquiaId")] Sucursal sucursal)
        {
            if (id != sucursal.SucursalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.SucursalId))
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
            ViewData["ParroquiaId"] = new SelectList(_context.Parroquia, "ParroquiaId", "Nombre", sucursal.ParroquiaId);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursal
                .Include(s => s.Parroquia)
                .SingleOrDefaultAsync(m => m.SucursalId == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursal = await _context.Sucursal.SingleOrDefaultAsync(m => m.SucursalId == id);
            _context.Sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
            return _context.Sucursal.Any(e => e.SucursalId == id);
        }
    }
}
