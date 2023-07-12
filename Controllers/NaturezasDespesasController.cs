    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCGov.Models;

namespace gcgov.Controllers
{
    public class NaturezasDespesasController : Controller
    {
        private readonly GCGovContext _context;

        public NaturezasDespesasController(GCGovContext context)
        {
            _context = context;
        }

        // GET: NaturezasDespesas
        public async Task<IActionResult> Index()
        {
              return _context.NaturezasDespesas != null ? 
                          View(await _context.NaturezasDespesas.ToListAsync()) :
                          Problem("Entity set 'GCGovContext.NaturezasDespesas'  is null.");
        }

        // GET: NaturezasDespesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NaturezasDespesas == null)
            {
                return NotFound();
            }

            var naturezaDespesa = await _context.NaturezasDespesas
                .FirstOrDefaultAsync(m => m.NatDespId == id);
            if (naturezaDespesa == null)
            {
                return NotFound();
            }

            return View(naturezaDespesa);
        }

        // GET: NaturezasDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturezasDespesas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NatDespId,FonteRecurso,ProgramaTrabalho,ElementoDespesa")] NaturezaDespesa naturezaDespesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naturezaDespesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naturezaDespesa);
        }

        // GET: NaturezasDespesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NaturezasDespesas == null)
            {
                return NotFound();
            }

            var naturezaDespesa = await _context.NaturezasDespesas.FindAsync(id);
            if (naturezaDespesa == null)
            {
                return NotFound();
            }
            return View(naturezaDespesa);
        }

        // POST: NaturezasDespesas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NatDespId,FonteRecurso,ProgramaTrabalho,ElementoDespesa")] NaturezaDespesa naturezaDespesa)
        {
            if (id != naturezaDespesa.NatDespId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturezaDespesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturezaDespesaExists(naturezaDespesa.NatDespId))
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
            return View(naturezaDespesa);
        }

        // GET: NaturezasDespesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NaturezasDespesas == null)
            {
                return NotFound();
            }

            var naturezaDespesa = await _context.NaturezasDespesas
                .FirstOrDefaultAsync(m => m.NatDespId == id);
            if (naturezaDespesa == null)
            {
                return NotFound();
            }

            return View(naturezaDespesa);
        }

        // POST: NaturezasDespesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NaturezasDespesas == null)
            {
                return Problem("Entity set 'GCGovContext.NaturezasDespesas'  is null.");
            }
            var naturezaDespesa = await _context.NaturezasDespesas.FindAsync(id);
            if (naturezaDespesa != null)
            {
                _context.NaturezasDespesas.Remove(naturezaDespesa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaturezaDespesaExists(int id)
        {
          return (_context.NaturezasDespesas?.Any(e => e.NatDespId == id)).GetValueOrDefault();
        }
    }
}
