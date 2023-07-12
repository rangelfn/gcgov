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
    public class PagamentosController : Controller
    {
        private readonly GCGovContext _context;

        public PagamentosController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            var gCGovContext = _context.Pagamentos.Include(p => p.PgtosOrigens);
            return View(await gCGovContext.ToListAsync());
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.PgtosOrigens)
                .FirstOrDefaultAsync(m => m.PgtoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            ViewData["PgtoOrigemId"] = new SelectList(_context.PgtosOrigens, "PgtoOrigemId", "PgtoOrigemId");
            return View();
        }

        // POST: Pagamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PgtoId,NotaLancamento,PreparacaoPagamento,OrdemBancaria,Valor,DataPagamento,Parcela,PgtoOrigemId")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PgtoOrigemId"] = new SelectList(_context.PgtosOrigens, "PgtoOrigemId", "PgtoOrigemId", pagamento.PgtoOrigemId);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["PgtoOrigemId"] = new SelectList(_context.PgtosOrigens, "PgtoOrigemId", "PgtoOrigemId", pagamento.PgtoOrigemId);
            return View(pagamento);
        }

        // POST: Pagamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PgtoId,NotaLancamento,PreparacaoPagamento,OrdemBancaria,Valor,DataPagamento,Parcela,PgtoOrigemId")] Pagamento pagamento)
        {
            if (id != pagamento.PgtoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PgtoId))
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
            ViewData["PgtoOrigemId"] = new SelectList(_context.PgtosOrigens, "PgtoOrigemId", "PgtoOrigemId", pagamento.PgtoOrigemId);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.PgtosOrigens)
                .FirstOrDefaultAsync(m => m.PgtoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'GCGovContext.Pagamentos'  is null.");
            }
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
          return (_context.Pagamentos?.Any(e => e.PgtoId == id)).GetValueOrDefault();
        }
    }
}