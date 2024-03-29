﻿using GCGov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GCGov.Controllers
{
    public class ApostilamentosController : Controller
    {
        private readonly GCGovContext _context;

        public ApostilamentosController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Apostilamentos
        public async Task<IActionResult> Index()
        {
            var apostilamentos = await _context.Apostilamentos.Include(a => a.Contrato).ToListAsync();
            return View(apostilamentos); 
        }

        // GET: Apostilamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Apostilamentos == null)
            {
                return NotFound();
            }

            var apostilamento = await _context.Apostilamentos
                .Include(a => a.Contrato)
                .FirstOrDefaultAsync(m => m.AptId == id);
            if (apostilamento == null)
            {
                return NotFound();
            }

            return View(apostilamento);
        }

        // GET: Apostilamentos/Create
        public IActionResult Create()
        {

            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            ViewBag.Contratos = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            return View();
        }

        // POST: Apostilamentos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AptId,AptNum,AptDesc,AptData,AptValor,ContratoId")] Apostilamento apostilamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apostilamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", apostilamento.ContratoId);
            return View(apostilamento);
        }

        // GET: Apostilamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Apostilamentos == null)
            {
                return NotFound();
            }

            var apostilamento = await _context.Apostilamentos.FindAsync(id);
            if (apostilamento == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", apostilamento.ContratoId);
            return View(apostilamento);
        }

        // POST: Apostilamentos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AptId,AptNum,AptDesc,AptData,AptValor,ContratoId")] Apostilamento apostilamento)
        {
            if (id != apostilamento.AptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apostilamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApostilamentoExists(apostilamento.AptId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "ContratoId", apostilamento.ContratoId);
            return View(apostilamento);
        }

        // GET: Apostilamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Apostilamentos == null)
            {
                return NotFound();
            }

            var apostilamento = await _context.Apostilamentos
                .Include(a => a.Contrato)
                .FirstOrDefaultAsync(m => m.AptId == id);
            if (apostilamento == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", apostilamento);
        }

        // POST: Apostilamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Apostilamentos == null)
            {
                return Problem("Entity set 'GCGovContext.Apostilamentos'  is null.");
            }
            var apostilamento = await _context.Apostilamentos.FindAsync(id);
            if (apostilamento != null)
            {
                _context.Apostilamentos.Remove(apostilamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApostilamentoExists(int id)
        {
            return (_context.Apostilamentos?.Any(e => e.AptId == id)).GetValueOrDefault();
        }
    }
}