using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using o.Data;
using o.Models;

namespace o.Controllers
{
    
    public class ilacsController : Controller
    {
        private readonly oContext _context;

        public ilacsController(oContext context)
        {
            _context = context;
        }

        // GET: ilacs
        public async Task<IActionResult> Index()
        {
            var oContext = _context.ilac.Include(i => i.ekin);
            return View(await oContext.ToListAsync());
        }

        // GET: ilacs/Details/5
         [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ilac == null)
            {
                return NotFound();
            }

            var ilac = await _context.ilac
                .Include(i => i.ekin)
                .FirstOrDefaultAsync(m => m.ilacId == id);
            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // GET: ilacs/Create
        public IActionResult Create()
        {
            ViewData["ekinId"] = new SelectList(_context.Set<ekin>(), "ekinId", "ekinId");
            return View();
        }

        // POST: ilacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ilacId,ilacAdı,ilacFiyat,ilacStock,ekinId")] ilac ilac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ekinId"] = new SelectList(_context.Set<ekin>(), "ekinId", "ekinId", ilac.ekinId);
            return View(ilac);
        }

        // GET: ilacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ilac == null)
            {
                return NotFound();
            }

            var ilac = await _context.ilac.FindAsync(id);
            if (ilac == null)
            {
                return NotFound();
            }
            ViewData["ekinId"] = new SelectList(_context.Set<ekin>(), "ekinId", "ekinId", ilac.ekinId);
            return View(ilac);
        }

        // POST: ilacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ilacId,ilacAdı,ilacFiyat,ilacStock,ekinId")] ilac ilac)
        {
            if (id != ilac.ilacId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ilacExists(ilac.ilacId))
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
            ViewData["ekinId"] = new SelectList(_context.Set<ekin>(), "ekinId", "ekinId", ilac.ekinId);
            return View(ilac);
        }

        // GET: ilacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ilac == null)
            {
                return NotFound();
            }

            var ilac = await _context.ilac
                .Include(i => i.ekin)
                .FirstOrDefaultAsync(m => m.ilacId == id);
            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // POST: ilacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ilac == null)
            {
                return Problem("Entity set 'oContext.ilac'  is null.");
            }
            var ilac = await _context.ilac.FindAsync(id);
            if (ilac != null)
            {
                _context.ilac.Remove(ilac);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ilacExists(int id)
        {
          return (_context.ilac?.Any(e => e.ilacId == id)).GetValueOrDefault();
        }
    }
}
