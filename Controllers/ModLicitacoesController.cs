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
    public class ModLicitacoesController : Controller
    {
        private readonly GCGovContext _context;

        public ModLicitacoesController(GCGovContext context)
        {
            _context = context;
        }

        // GET: ModLicitacoes
        public async Task<IActionResult> Index()
        {
              return _context.ModLicitacoes != null ? 
                          View(await _context.ModLicitacoes.ToListAsync()) :
                          Problem("Entity set 'GCGovContext.ModLicitacoes'  is null.");
        }

        // GET: ModLicitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModLicitacoes == null)
            {
                return NotFound();
            }

            var modLicitacao = await _context.ModLicitacoes
                .FirstOrDefaultAsync(m => m.ModLicitacaoId == id);
            if (modLicitacao == null)
            {
                return NotFound();
            }

            return View(modLicitacao);
        }

        // GET: ModLicitacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModLicitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModLicitacaoId,ModNome")] ModLicitacao modLicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modLicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modLicitacao);
        }

        // GET: ModLicitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModLicitacoes == null)
            {
                return NotFound();
            }

            var modLicitacao = await _context.ModLicitacoes.FindAsync(id);
            if (modLicitacao == null)
            {
                return NotFound();
            }
            return View(modLicitacao);
        }

        // POST: ModLicitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModLicitacaoId,ModNome")] ModLicitacao modLicitacao)
        {
            if (id != modLicitacao.ModLicitacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modLicitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModLicitacaoExists(modLicitacao.ModLicitacaoId))
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
            return View(modLicitacao);
        }

        // GET: ModLicitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModLicitacoes == null)
            {
                return NotFound();
            }

            var modLicitacao = await _context.ModLicitacoes
                .FirstOrDefaultAsync(m => m.ModLicitacaoId == id);
            if (modLicitacao == null)
            {
                return NotFound();
            }

            return View(modLicitacao);
        }

        // POST: ModLicitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModLicitacoes == null)
            {
                return Problem("Entity set 'GCGovContext.ModLicitacoes'  is null.");
            }
            var modLicitacao = await _context.ModLicitacoes.FindAsync(id);
            if (modLicitacao != null)
            {
                _context.ModLicitacoes.Remove(modLicitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModLicitacaoExists(int id)
        {
          return (_context.ModLicitacoes?.Any(e => e.ModLicitacaoId == id)).GetValueOrDefault();
        }
    }
}
