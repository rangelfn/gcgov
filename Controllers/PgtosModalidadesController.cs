using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCGov.Models;

namespace GCGov.Controllers
{
    public class PgtosModalidadesController : Controller
    {
        private readonly GCGovContext _context;

        public PgtosModalidadesController(GCGovContext context)
        {
            _context = context;
        }

        // GET: PgtosModalidades
        public async Task<IActionResult> Index()
        {
              return _context.PgtosModalidades != null ? 
                          View(await _context.PgtosModalidades.ToListAsync()) :
                          Problem("Entity set 'GCGovContext.PgtosModalidades'  is null.");
        }

        // GET: PgtosModalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PgtosModalidades == null)
            {
                return NotFound();
            }

            var pgtosModalidade = await _context.PgtosModalidades
                .FirstOrDefaultAsync(m => m.PgtoModId == id);
            if (pgtosModalidade == null)
            {
                return NotFound();
            }

            return View(pgtosModalidade);
        }

        // GET: PgtosModalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PgtosModalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PgtoModId,PgtoModNome")] PgtosModalidade pgtosModalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pgtosModalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pgtosModalidade);
        }

        // GET: PgtosModalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PgtosModalidades == null)
            {
                return NotFound();
            }

            var pgtosModalidade = await _context.PgtosModalidades.FindAsync(id);
            if (pgtosModalidade == null)
            {
                return NotFound();
            }
            return View(pgtosModalidade);
        }

        // POST: PgtosModalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PgtoModId,PgtoModNome")] PgtosModalidade pgtosModalidade)
        {
            if (id != pgtosModalidade.PgtoModId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pgtosModalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PgtosModalidadeExists(pgtosModalidade.PgtoModId))
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
            return View(pgtosModalidade);
        }

        // GET: PgtosModalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PgtosModalidades == null)
            {
                return NotFound();
            }

            var pgtosModalidade = await _context.PgtosModalidades
                .FirstOrDefaultAsync(m => m.PgtoModId == id);
            if (pgtosModalidade == null)
            {
                return NotFound();
            }

            return View(pgtosModalidade);
        }

        // POST: PgtosModalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PgtosModalidades == null)
            {
                return Problem("Entity set 'GCGovContext.PgtosModalidades'  is null.");
            }
            var pgtosModalidade = await _context.PgtosModalidades.FindAsync(id);
            if (pgtosModalidade != null)
            {
                _context.PgtosModalidades.Remove(pgtosModalidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PgtosModalidadeExists(int id)
        {
          return (_context.PgtosModalidades?.Any(e => e.PgtoModId == id)).GetValueOrDefault();
        }
    }
}
