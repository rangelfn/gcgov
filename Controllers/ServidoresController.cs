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
    public class ServidoresController : Controller
    {
        private readonly GCGovContext _context;

        public ServidoresController(GCGovContext context)
        {
            _context = context;
        }

        // GET: Servidores
        public async Task<IActionResult> Index()
        {
            var gCGovContext = _context.Servidores.Include(s => s.UgCodigo).Include(s => s.UgDp);
            return View(await gCGovContext.ToListAsync());
        }

        // GET: Servidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servidores == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .Include(s => s.UgCodigo)
                .Include(s => s.UgDp)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // GET: Servidores/Create
        public IActionResult Create()
        {
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId");
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId");
            return View();
        }

        // POST: Servidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Cpf,UgCodigoId,UgDpId")] Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", servidor.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", servidor.UgDpId);
            return View(servidor);
        }

        // GET: Servidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servidores == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return NotFound();
            }
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", servidor.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", servidor.UgDpId);
            return View(servidor);
        }

        // POST: Servidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Cpf,UgCodigoId,UgDpId")] Servidor servidor)
        {
            if (id != servidor.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServidorExists(servidor.Matricula))
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
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgCodigoId", servidor.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpId", servidor.UgDpId);
            return View(servidor);
        }

        // GET: Servidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servidores == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidores
                .Include(s => s.UgCodigo)
                .Include(s => s.UgDp)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // POST: Servidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servidores == null)
            {
                return Problem("Entity set 'GCGovContext.Servidores'  is null.");
            }
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor != null)
            {
                _context.Servidores.Remove(servidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServidorExists(int id)
        {
          return (_context.Servidores?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
    }
}
