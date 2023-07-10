using GCGov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GCGov.Controllers
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
        public IActionResult Details(int id)
        {
            var contrato = _context.Contratos.Include(c => c.ModLicitacao).Include(c => c.UgCodigo).Include(c => c.UgDp)
                .FirstOrDefault(c => c.ContratoId == id);

            if (contrato == null)
            {
                return NotFound();
            }

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

            return View(contrato);
        }

        // GET: Contratos/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.ModLicitacao)
                .Include(c => c.UgCodigo)
                .Include(c => c.UgDp)
                .FirstOrDefaultAsync(c => c.ContratoId == id);

            if (contrato == null)
            {
                return NotFound();
            }

            // Recuperar as listas de opções para os campos de seleção
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacoes, "ModLicitacaoId", "ModNome", contrato.ModLicitacaoId);
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgNome", contrato.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpNome", contrato.UgDpId);

            return View(contrato);
        }

        // POST: Contratos/Edit/id
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

            // Recuperar as listas de opções para os campos de seleção
            ViewData["ModLicitacaoId"] = new SelectList(_context.ModLicitacoes, "ModLicitacaoId", "ModNome", contrato.ModLicitacaoId);
            ViewData["UgCodigoId"] = new SelectList(_context.UnidadesGestoras, "UgCodigoId", "UgNome", contrato.UgCodigoId);
            ViewData["UgDpId"] = new SelectList(_context.UgDepartamentos, "UgDpId", "UgDpNome", contrato.UgDpId);

            return View(contrato);
        }

        // GET: Contratos/Delete/id
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

            return PartialView("_Delete", contrato);
        }

        // POST: Contratos/Delete/id
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