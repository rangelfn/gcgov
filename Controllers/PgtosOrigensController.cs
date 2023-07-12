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
    public class PgtosOrigensController : Controller
    {
        private readonly GCGovContext _context;

        public PgtosOrigensController(GCGovContext context)
        {
            _context = context;
        }

        // GET: PgtosOrigens
        public async Task<IActionResult> Index()
        {
            var pgtosOrigem = await _context.PgtosOrigens.Include(p => p.Contrato).Include(p => p.NatDesp).Include(p => p.PgtoMod).ToListAsync();
            return View(pgtosOrigem);
        }

        // GET: PgtosOrigens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PgtosOrigens == null)
            {
                return NotFound();
            }

            var pgtosOrigem = await _context.PgtosOrigens.Include(p => p.Contrato).Include(p => p.NatDesp).Include(p => p.PgtoMod)
                .FirstOrDefaultAsync(m => m.PgtoOrigemId == id);
            if (pgtosOrigem == null)
            {
                return NotFound();
            }

            return View(pgtosOrigem);
        }

        // GET: PgtosOrigens/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            ViewData["NatDespId"] = new SelectList(_context.NaturezasDespesas, "NatDespId", "ElementoDespesa");
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModNome");
            return View();
        }

        // POST: PgtosOrigens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PgtoOrigemId,NotaEmpenho,DataCadastro,PgtoModId,ContratoId,NatDespId")] PgtosOrigem pgtosOrigem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pgtosOrigem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", pgtosOrigem.ContratoId);
            ViewData["NatDespId"] = new SelectList(_context.NaturezasDespesas, "NatDespId", "ElementoDespesa", pgtosOrigem.NatDespId);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModNome", pgtosOrigem.PgtoModId);
            return View(pgtosOrigem);
        }

        // GET: PgtosOrigens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PgtosOrigens == null)
            {
                return NotFound();
            }

            var pgtosOrigem = await _context.PgtosOrigens.FindAsync(id);
            if (pgtosOrigem == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", pgtosOrigem.ContratoId);
            ViewData["NatDespId"] = new SelectList(_context.NaturezasDespesas, "NatDespId", "ElementoDespesa", pgtosOrigem.NatDespId);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModNome", pgtosOrigem.PgtoModId);
            return View(pgtosOrigem);
        }

        // POST: PgtosOrigens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PgtoOrigemId,NotaEmpenho,DataCadastro,PgtoModId,ContratoId,NatDespId")] PgtosOrigem pgtosOrigem)
        {
            if (id != pgtosOrigem.PgtoOrigemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pgtosOrigem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PgtosOrigemExists(pgtosOrigem.PgtoOrigemId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", pgtosOrigem.ContratoId);
            ViewData["NatDespId"] = new SelectList(_context.NaturezasDespesas, "NatDespId", "ElementoDespesa", pgtosOrigem.NatDespId);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModNome", pgtosOrigem.PgtoModId);
            return View(pgtosOrigem);
        }

        // GET: PgtosOrigens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PgtosOrigens == null)
            {
                return NotFound();
            }

            var pgtosOrigem = await _context.PgtosOrigens
                .Include(p => p.Contrato)
                .Include(p => p.NatDesp)
                .Include(p => p.PgtoMod)
                .FirstOrDefaultAsync(m => m.PgtoOrigemId == id);
            if (pgtosOrigem == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", pgtosOrigem);
        }

        // POST: PgtosOrigens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PgtosOrigens == null)
            {
                return Problem("Entity set 'GCGovContext.PgtosOrigens'  is null.");
            }
            var pgtosOrigem = await _context.PgtosOrigens.FindAsync(id);
            if (pgtosOrigem != null)
            {
                _context.PgtosOrigens.Remove(pgtosOrigem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PgtosOrigemExists(int id)
        {
          return (_context.PgtosOrigens?.Any(e => e.PgtoOrigemId == id)).GetValueOrDefault();
        }
    }
}
