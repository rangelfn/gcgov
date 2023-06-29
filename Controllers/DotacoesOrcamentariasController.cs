using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gcgov.Models;

namespace gcgov.Controllers
{
    public class DotacoesOrcamentariasController : Controller
    {
        private readonly GCGovContext _context;

        public DotacoesOrcamentariasController(GCGovContext context)
        {
            _context = context;
        }

        // GET: DotacoesOrcamentarias
        public async Task<IActionResult> Index()
        {
              return _context.DotacaoOrcamentarias != null ? 
                          View(await _context.DotacaoOrcamentarias.ToListAsync()) :
                          Problem("Entity set 'GCGovContext.DotacaoOrcamentarias'  is null.");
        }

        // GET: DotacoesOrcamentarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DotacaoOrcamentarias == null)
            {
                return NotFound();
            }

            var dotacaoOrcamentaria = await _context.DotacaoOrcamentarias
                .FirstOrDefaultAsync(m => m.NaturezaDespesa == id);
            if (dotacaoOrcamentaria == null)
            {
                return NotFound();
            }

            return View(dotacaoOrcamentaria);
        }

        // GET: DotacoesOrcamentarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DotacoesOrcamentarias/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NaturezaDespesa,FonteRecurso,ProgramaTrabalho")] DotacaoOrcamentaria dotacaoOrcamentaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dotacaoOrcamentaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dotacaoOrcamentaria);
        }

        // GET: DotacoesOrcamentarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DotacaoOrcamentarias == null)
            {
                return NotFound();
            }

            var dotacaoOrcamentaria = await _context.DotacaoOrcamentarias.FindAsync(id);
            if (dotacaoOrcamentaria == null)
            {
                return NotFound();
            }
            return View(dotacaoOrcamentaria);
        }

        // POST: DotacoesOrcamentarias/Edit/5


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NaturezaDespesa,FonteRecurso,ProgramaTrabalho")] DotacaoOrcamentaria dotacaoOrcamentaria)
        {
            if (id != dotacaoOrcamentaria.NaturezaDespesa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dotacaoOrcamentaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DotacaoOrcamentariaExists(dotacaoOrcamentaria.NaturezaDespesa))
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
            return View(dotacaoOrcamentaria);
        }

        // GET: DotacoesOrcamentarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DotacaoOrcamentarias == null)
            {
                return NotFound();
            }

            var dotacaoOrcamentaria = await _context.DotacaoOrcamentarias
                .FirstOrDefaultAsync(m => m.NaturezaDespesa == id);
            if (dotacaoOrcamentaria == null)
            {
                return NotFound();
            }

            return View(dotacaoOrcamentaria);
        }

        // POST: DotacoesOrcamentarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DotacaoOrcamentarias == null)
            {
                return Problem("Entity set 'GCGovContext.DotacaoOrcamentarias'  is null.");
            }
            var dotacaoOrcamentaria = await _context.DotacaoOrcamentarias.FindAsync(id);
            if (dotacaoOrcamentaria != null)
            {
                _context.DotacaoOrcamentarias.Remove(dotacaoOrcamentaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DotacaoOrcamentariaExists(int id)
        {
          return (_context.DotacaoOrcamentarias?.Any(e => e.NaturezaDespesa == id)).GetValueOrDefault();
        }
    }
}
