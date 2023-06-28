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
    public class ContratosController : Controller
    {
        private readonly GCGovContext _context;

        public ContratosController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var gestorContratosContext = _context.Contratos.Include(c => c.ModLicitacao).Include(c => c.UgCodigo).Include(c => c.UgDp);
            return View(await gestorContratosContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.ModLicitacao)
                .Include(c => c.UgCodigo)
                .Include(c => c.UgDp)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacaos, "ModLicitacaoId", "ModLicitacaoId");
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId");
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,Extrato,Contratante,Contratada,Objeto,Vigencia,DataInicio,ProcessoSei,LinkPublico,DataAssinatura,ProtocoloDiof,ModLicitacaoId,Valor,UgCodigoId,UgDpId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacaos, "ModLicitacaoId", "ModLicitacaoId", contrato.ModLicitacaoId);
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", contrato.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", contrato.UgDpId);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacaos, "ModLicitacaoId", "ModLicitacaoId", contrato.ModLicitacaoId);
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", contrato.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", contrato.UgDpId);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,Extrato,Contratante,Contratada,Objeto,Vigencia,DataInicio,ProcessoSei,LinkPublico,DataAssinatura,ProtocoloDiof,ModLicitacaoId,Valor,UgCodigoId,UgDpId")] Contrato contrato)
        {
            if (id != contrato.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.ContratoId))
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
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacaos, "ModLicitacaoId", "ModLicitacaoId", contrato.ModLicitacaoId);
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", contrato.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", contrato.UgDpId);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.ModLicitacao)
                .Include(c => c.UgCodigo)
                .Include(c => c.UgDp)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contratos == null)
            {
                return Problem("Entity set 'GestorContratosContext.Contratos'  is null.");
            }
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
          return (_context.Contratos?.Any(e => e.ContratoId == id)).GetValueOrDefault();
        }
    }
}
