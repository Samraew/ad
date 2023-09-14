using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using o.Data;
using o.Models;

namespace o.Controllers
{
    public class ekinssController : Controller
    {
        private readonly oContext _context;

        public ekinssController(oContext context)
        {
            _context = context;
        }

        // GET: ekinss
        public async Task<IActionResult> Index()
        {
            var oContext = _context.ekin.Include(e => e.tarla);
            return View(await oContext.ToListAsync());
        }

        // GET: ekinss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ekin == null)
            {
                return NotFound();
            }

            var ekin = await _context.ekin
                .Include(e => e.tarla)
                .FirstOrDefaultAsync(m => m.ekinId == id);
            if (ekin == null)
            {
                return NotFound();
            }

            return View(ekin);
        }

        // GET: ekinss/Create
        public IActionResult Create()
        {
            ViewData["tarlaId"] = new SelectList(_context.tarla, "tarlaId", "tarlaId");
            return View();
        }

        // POST: ekinss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ekinId,ekinAdı,ekinFiyat,ekinstock,tarlaId")] ekin ekin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tarlaId"] = new SelectList(_context.tarla, "tarlaId", "tarlaId", ekin.tarlaId);
            return View(ekin);
        }

        // GET: ekinss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ekin == null)
            {
                return NotFound();
            }

            var ekin = await _context.ekin.FindAsync(id);
            if (ekin == null)
            {
                return NotFound();
            }
            ViewData["tarlaId"] = new SelectList(_context.tarla, "tarlaId", "tarlaId", ekin.tarlaId);
            return View(ekin);
        }

        // POST: ekinss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ekinId,ekinAdı,ekinFiyat,ekinstock,tarlaId")] ekin ekin)
        {
            if (id != ekin.ekinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ekinExists(ekin.ekinId))
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
            ViewData["tarlaId"] = new SelectList(_context.tarla, "tarlaId", "tarlaId", ekin.tarlaId);
            return View(ekin);
        }

        // GET: ekinss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ekin == null)
            {
                return NotFound();
            }

            var ekin = await _context.ekin
                .Include(e => e.tarla)
                .FirstOrDefaultAsync(m => m.ekinId == id);
            if (ekin == null)
            {
                return NotFound();
            }

            return View(ekin);
        }

        // POST: ekinss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ekin == null)
            {
                return Problem("Entity set 'oContext.ekin'  is null.");
            }
            var ekin = await _context.ekin.FindAsync(id);
            if (ekin != null)
            {
                _context.ekin.Remove(ekin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ekinExists(int id)
        {
          return (_context.ekin?.Any(e => e.ekinId == id)).GetValueOrDefault();
        }
    }
}
