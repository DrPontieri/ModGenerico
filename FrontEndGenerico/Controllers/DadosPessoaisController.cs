using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain;

namespace FrontEndGenerico.Controllers
{
    public class DadosPessoaisController : Controller
    {
        private readonly AppDbContext _context;

        public DadosPessoaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DadosPessoais
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.DadosPessoaisS.Include(d => d.Pessoa);
            return View(await appDbContext.ToListAsync());
        }

        // GET: DadosPessoais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DadosPessoaisS == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _context.DadosPessoaisS
                .Include(d => d.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id");
            return View();
        }

        // POST: DadosPessoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,Pais,DtNascimento,PessoaId,Id")] DadosPessoais dadosPessoais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosPessoais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", dadosPessoais.PessoaId);
            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DadosPessoaisS == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _context.DadosPessoaisS.FindAsync(id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", dadosPessoais.PessoaId);
            return View(dadosPessoais);
        }

        // POST: DadosPessoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Email,Pais,DtNascimento,PessoaId,Id")] DadosPessoais dadosPessoais)
        {
            if (id != dadosPessoais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosPessoais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosPessoaisExists(dadosPessoais.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", dadosPessoais.PessoaId);
            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DadosPessoaisS == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _context.DadosPessoaisS
                .Include(d => d.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }

        // POST: DadosPessoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DadosPessoaisS == null)
            {
                return Problem("Entity set 'AppDbContext.DadosPessoaisS'  is null.");
            }
            var dadosPessoais = await _context.DadosPessoaisS.FindAsync(id);
            if (dadosPessoais != null)
            {
                _context.DadosPessoaisS.Remove(dadosPessoais);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosPessoaisExists(int id)
        {
          return (_context.DadosPessoaisS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
