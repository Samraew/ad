using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using o.Data;
using o.Models;


namespace o.Controllers
{   
    [Authorize]
    public class TarlasController : Controller
    {       
        private readonly oContext _context;

        public TarlasController(oContext context)
        {
            _context = context;
        }

        // GET: Tarlas
        public async Task<IActionResult> Index()
        {
              return _context.tarla != null ? 
                          View(await _context.tarla.ToListAsync()) :
                          Problem("Entity set 'oContext.tarla'  is null.");
        }

        // GET: Tarlas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tarla == null)
            {
                return NotFound();
            }

            var tarla = await _context.tarla
                .FirstOrDefaultAsync(m => m.tarlaId == id);
            if (tarla == null)
            {
                return NotFound();
            }

            return View(tarla);
        }

        // GET: Tarlas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarlas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tarlaId,TarlaAdı,TarlaGenislik,tarlaBolge")] tarla tarla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarla);
        }

        // GET: Tarlas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tarla == null)
            {
                return NotFound();
            }

            var tarla = await _context.tarla.FindAsync(id);
            if (tarla == null)
            {
                return NotFound();
            }
            return View(tarla);
        }

        // POST: Tarlas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tarlaId,TarlaAdı,TarlaGenislik,tarlaBolge")] tarla tarla)
        {
            if (id != tarla.tarlaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tarlaExists(tarla.tarlaId))
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
            return View(tarla);
        }

        // GET: Tarlas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tarla == null)
            {
                return NotFound();
            }

            var tarla = await _context.tarla
                .FirstOrDefaultAsync(m => m.tarlaId == id);
            if (tarla == null)
            {
                return NotFound();
            }

            return View(tarla);
        }

        // POST: Tarlas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tarla == null)
            {
                return Problem("Entity set 'oContext.tarla'  is null.");
            }
            var tarla = await _context.tarla.FindAsync(id);
            if (tarla != null)
            {
                _context.tarla.Remove(tarla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tarlaExists(int id)
        {
          return (_context.tarla?.Any(e => e.tarlaId == id)).GetValueOrDefault();
        }
    }
}
