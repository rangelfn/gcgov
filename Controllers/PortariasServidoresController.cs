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
    public class PortariasServidoresController : Controller
    {
        private readonly GCGovContext _context;

        public PortariasServidoresController(GCGovContext context)
        {
            _context = context;
        }

        // GET: PortariasServidores
        public async Task<IActionResult> Index()
        {
            var gCGovContext = _context.PortariasServidores.Include(p => p.MatriculaNavigation).Include(p => p.Portaria);
            return View(await gCGovContext.ToListAsync());

        }

        // GET: PortariasServidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PortariasServidores == null)
            {
                return NotFound();
            }

            var portariaServidor = await _context.PortariasServidores
                .Include(p => p.MatriculaNavigation)
                .Include(p => p.Portaria)
                .FirstOrDefaultAsync(m => m.PortariasServidorID == id);
            if (portariaServidor == null)
            {
                return NotFound();
            }

            return View(portariaServidor);
        }

        // GET: PortariasServidores/Create
        public IActionResult Create()
        {
            ViewData["Matricula"] = new SelectList(_context.Servidores, "Matricula", "Matricula");
            ViewData["PortariaId"] = new SelectList(_context.Portarias, "PortariaId", "PortariaNumero");
            return View();
        }

        // POST: PortariasServidores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortariasServidorID,Funcao,Resolucao,PortariaId,Matricula")] PortariaServidor portariaServidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portariaServidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matricula"] = new SelectList(_context.Servidores, "Matricula", "Matricula", portariaServidor.Matricula);
            ViewData["PortariaId"] = new SelectList(_context.Portarias, "PortariaId", "PortariaNumero", portariaServidor.PortariaId);
            return View(portariaServidor);
        }

        // GET: PortariasServidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PortariasServidores == null)
            {
                return NotFound();
            }

            var portariaServidor = await _context.PortariasServidores.FindAsync(id);
            if (portariaServidor == null)
            {
                return NotFound();
            }
            ViewData["Matricula"] = new SelectList(_context.Servidores, "Matricula", "Matricula", portariaServidor.Matricula);
            ViewData["PortariaId"] = new SelectList(_context.Portarias, "PortariaId", "PortariaNumero", portariaServidor.PortariaId);
            return View(portariaServidor);
        }

        // POST: PortariasServidores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortariasServidorID,Funcao,Resolucao,PortariaId,Matricula")] PortariaServidor portariaServidor)
        {
            if (id != portariaServidor.PortariasServidorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portariaServidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortariaServidorExists(portariaServidor.PortariasServidorID))
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
            ViewData["Matricula"] = new SelectList(_context.Servidores, "Matricula", "Matricula", portariaServidor.Matricula);
            ViewData["PortariaId"] = new SelectList(_context.Portarias, "PortariaId", "PortariaNumero", portariaServidor.PortariaId);
            return View(portariaServidor);
        }

        // GET: PortariasServidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PortariasServidores == null)
            {
                return NotFound();
            }

            var portariaServidor = await _context.PortariasServidores
                .Include(p => p.MatriculaNavigation)
                .Include(p => p.Portaria)
                .FirstOrDefaultAsync(m => m.PortariasServidorID == id);
            if (portariaServidor == null)
            {
                return NotFound();
            }

			return PartialView("_Delete", portariaServidor);
        }

        // POST: PortariasServidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PortariasServidores == null)
            {
                return Problem("Entity set 'GCGovContext.PortariasServidores'  is null.");
            }
            var portariaServidor = await _context.PortariasServidores.FindAsync(id);
            if (portariaServidor != null)
            {
                _context.PortariasServidores.Remove(portariaServidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortariaServidorExists(int id)
        {
          return (_context.PortariasServidores?.Any(e => e.PortariasServidorID == id)).GetValueOrDefault();
        }
    }
}
