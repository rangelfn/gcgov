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
    public class PortariasController : Controller
    {
        private readonly GCGovContext _context;

        public PortariasController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Portarias
        public async Task<IActionResult> Index()
        {
            var portarias = await _context.Portarias.Include(p => p.Contrato).ToListAsync();
            return View(portarias);
        }

        // GET: Portarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Portarias == null)
            {
                return NotFound();
            }

            var portaria = await _context.Portarias
                .Include(p => p.Contrato)
                .FirstOrDefaultAsync(m => m.PortariaId == id);
            if (portaria == null)
            {
                return NotFound();
            }

            return View(portaria);
        }

        // GET: Portarias/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            ViewBag.Contratos = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            return View();
        }

        // POST: Portarias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortariaId,PortariaNumero,ProtocoloDiof,DataPublicacao,DataInicio,ContratoId")] Portaria portaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", portaria.ContratoId);
            return View(portaria);
        }

        // GET: Portarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Portarias == null)
            {
                return NotFound();
            }

            var portaria = await _context.Portarias.FindAsync(id);
            if (portaria == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", portaria.ContratoId);
            ViewBag.Contratos = new SelectList(_context.Contratos, "ContratoId", "Extrato");
            return View(portaria);
        }

        // POST: Portarias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortariaId,PortariaNumero,ProtocoloDiof,DataPublicacao,DataInicio,ContratoId")] Portaria portaria)
        {
            if (id != portaria.PortariaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortariaExists(portaria.PortariaId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "Extrato", portaria.ContratoId);
            return View(portaria);
        }

        // GET: Portarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Portarias == null)
            {
                return NotFound();
            }

            var portaria = await _context.Portarias
                .Include(p => p.Contrato)
                .FirstOrDefaultAsync(m => m.PortariaId == id);
            if (portaria == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", portaria);
        }

        // POST: Portarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Portarias == null)
            {
                return Problem("Entity set 'GCGovContext.Portarias'  is null.");
            }
            var portaria = await _context.Portarias.FindAsync(id);
            if (portaria != null)
            {
                _context.Portarias.Remove(portaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortariaExists(int id)
        {
          return (_context.Portarias?.Any(e => e.PortariaId == id)).GetValueOrDefault();
        }
    }
}
