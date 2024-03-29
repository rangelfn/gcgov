﻿using GCGov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gcgov.Controllers
{
    public class AditivosController : Controller
    {
        private readonly GCGovContext _context;

        public AditivosController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Aditivos
        public async Task<IActionResult> Index()
        {
            var aditivos = await _context.Aditivos.Include(a => a.Contrato).ToListAsync();
            return View(aditivos);
        }

        // GET: Aditivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aditivo = await _context.Aditivos.Include(a => a.Contrato)
                .FirstOrDefaultAsync(m => m.AdtId == id);
            if (aditivo == null)
            {
                return NotFound();
            }

            return View(aditivo);
        }

        // GET: Aditivos/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            ViewBag.Contratos = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdtId,AdtNum,AdtDesc,AdtData,Valor,ContratoId")] Aditivo aditivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aditivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", aditivo.ContratoId);
            ViewBag.Contratos = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            return View(aditivo);
        }

        // GET: Aditivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aditivo = await _context.Aditivos.FindAsync(id);
            if (aditivo == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", aditivo.ContratoId);
            return View(aditivo);
        }

        // POST: Aditivos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdtId,AdtNum,AdtDesc,AdtData,AdtValor,ContratoId")] Aditivo aditivo)
        {
            if (id != aditivo.AdtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aditivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AditivoExists(aditivo.AdtId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", aditivo.ContratoId);
            return View(aditivo);
        }

        // GET: Aditivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aditivo = await _context.Aditivos
                .Include(a => a.Contrato)
                .FirstOrDefaultAsync(m => m.AdtId == id);
            if (aditivo == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", aditivo);
        }


        // POST: Aditivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aditivo = await _context.Aditivos.FindAsync(id);
            if (aditivo == null)
            {
                return Problem("Entity set 'GestorContratosContext.Editais'  is null.");
            }

            _context.Aditivos.Remove(aditivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AditivoExists(int id)
        {
            return _context.Aditivos.Any(e => e.AdtId == id);
        }
    }
}
