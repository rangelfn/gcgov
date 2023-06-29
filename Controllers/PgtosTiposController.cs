using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gcgov.Models;

namespace gcgov.Controllers
{
    public class PgtosTiposController : Controller
    {
        private readonly GCGovContext _context;

        public PgtosTiposController(GCGovContext context)
        {
            _context = context;
        }

        // GET: PgtosTipos
        public async Task<IActionResult> Index()
        {
            var gCGovContext = _context.PgtosTipos.Include(p => p.Contrato).Include(p => p.NaturezaDespesaNavigation).Include(p => p.PgtoMod);
            return View(await gCGovContext.ToListAsync());
        }

        // GET: PgtosTipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PgtosTipos == null)
            {
                return NotFound();
            }

            var pgtosTipo = await _context.PgtosTipos
                .Include(p => p.Contrato)
                .Include(p => p.NaturezaDespesaNavigation)
                .Include(p => p.PgtoMod)
                .FirstOrDefaultAsync(m => m.PgtoTipoId == id);
            if (pgtosTipo == null)
            {
                return NotFound();
            }

            return View(pgtosTipo);
        }

        // GET: PgtosTipos/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId");
            ViewData["NaturezaDespesa"] = new SelectList(_context.DotacaoOrcamentarias, "NaturezaDespesa", "NaturezaDespesa");
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModId");
            return View();
        }

        // POST: PgtosTipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PgtoTipoId,NotaEmpenho,DataCadastro,PgtoModId,ContratoId,NaturezaDespesa")] PgtosTipo pgtosTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pgtosTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", pgtosTipo.ContratoId);
            ViewData["NaturezaDespesa"] = new SelectList(_context.DotacaoOrcamentarias, "NaturezaDespesa", "NaturezaDespesa", pgtosTipo.NaturezaDespesa);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModId", pgtosTipo.PgtoModId);
            return View(pgtosTipo);
        }

        // GET: PgtosTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PgtosTipos == null)
            {
                return NotFound();
            }

            var pgtosTipo = await _context.PgtosTipos.FindAsync(id);
            if (pgtosTipo == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", pgtosTipo.ContratoId);
            ViewData["NaturezaDespesa"] = new SelectList(_context.DotacaoOrcamentarias, "NaturezaDespesa", "NaturezaDespesa", pgtosTipo.NaturezaDespesa);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModId", pgtosTipo.PgtoModId);
            return View(pgtosTipo);
        }

        // POST: PgtosTipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PgtoTipoId,NotaEmpenho,DataCadastro,PgtoModId,ContratoId,NaturezaDespesa")] PgtosTipo pgtosTipo)
        {
            if (id != pgtosTipo.PgtoTipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pgtosTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PgtosTipoExists(pgtosTipo.PgtoTipoId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", pgtosTipo.ContratoId);
            ViewData["NaturezaDespesa"] = new SelectList(_context.DotacaoOrcamentarias, "NaturezaDespesa", "NaturezaDespesa", pgtosTipo.NaturezaDespesa);
            ViewData["PgtoModId"] = new SelectList(_context.PgtosModalidades, "PgtoModId", "PgtoModId", pgtosTipo.PgtoModId);
            return View(pgtosTipo);
        }

        // GET: PgtosTipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PgtosTipos == null)
            {
                return NotFound();
            }

            var pgtosTipo = await _context.PgtosTipos
                .Include(p => p.Contrato)
                .Include(p => p.NaturezaDespesaNavigation)
                .Include(p => p.PgtoMod)
                .FirstOrDefaultAsync(m => m.PgtoTipoId == id);
            if (pgtosTipo == null)
            {
                return NotFound();
            }

            return View(pgtosTipo);
        }

        // POST: PgtosTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PgtosTipos == null)
            {
                return Problem("Entity set 'GCGovContext.PgtosTipos'  is null.");
            }
            var pgtosTipo = await _context.PgtosTipos.FindAsync(id);
            if (pgtosTipo != null)
            {
                _context.PgtosTipos.Remove(pgtosTipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PgtosTipoExists(int id)
        {
          return (_context.PgtosTipos?.Any(e => e.PgtoTipoId == id)).GetValueOrDefault();
        }
    }
}
