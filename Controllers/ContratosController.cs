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
    public class ContratosController : Controller
    {
        private readonly GCGovContext _context;

        public ContratosController(GCGovContext context)
        {
            _context = context;
        }

        // Método auxiliar para obter as listas necessárias
        private async Task PopulateSelectListsAsync()
        {
            var modLicitacoes = await _context.ModLicitacoes.Select(m => new { m.ModLicitacaoId, m.ModNome }).ToListAsync();
            var unidadesGestoras = await _context.UnidadesGestoras.Select(u => new { u.UgCodigoId, u.UgNome }).ToListAsync();
            var ugDepartamentos = await _context.UgDepartamentos.Select(d => new { d.UgDpId, d.UgDpNome }).ToListAsync();

            ViewData["ModLicitacaoId"] = new SelectList(modLicitacoes, "ModLicitacaoId", "ModNome");
            ViewData["UgCodigoId"] = new SelectList(unidadesGestoras, "UgCodigoId", "UgNome");
            ViewData["UgDpId"] = new SelectList(ugDepartamentos, "UgDpId", "UgDpNome");
        }
        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var gestorContratosContext = _context.Contratos.Include(c => c.ModLicitacao).Include(c => c.UgCodigo).Include(c => c.UgDp);
            await PopulateSelectListsAsync();
            return View(await gestorContratosContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
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

            await PopulateSelectListsAsync();
            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacoes, "ModLicitacaoId", "ModNome");
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgNome");
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpNome");
            return View();
        }

        // POST: Contratos/Create
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
            await PopulateSelectListsAsync();
            return View(contrato);
        }

        // GET: Contratos/Edit/ID
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
            await PopulateSelectListsAsync();
            return View(contrato);
        }

        // POST: Contratos/Edit/ID


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

            await PopulateSelectListsAsync();
            return View(contrato);
        }

        // GET: Contratos/Delete/ID
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.ModLicitacao).Include(c => c.UgCodigo).Include(c => c.UgDp)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contrato == null)
            {
                return NotFound();
            }
            await PopulateSelectListsAsync();
            return View(contrato);
        }

        // POST: Contratos/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contratos == null)
            {
                return Problem("O Conjunto de entidades 'GestorContratosContext.Contratos' é nulo.");
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
