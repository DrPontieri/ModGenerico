using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Dto;

namespace FrontEndGenerico.Controllers
{
    public class PostPessoaDtoesController : Controller
    {
        private readonly AppDbContext _context;

        public PostPessoaDtoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PostPessoaDtoes
        public async Task<IActionResult> Index()
        {
              return _context.Posts != null ? 
                          View(await _context.Posts.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Posts'  is null.");
        }

        // GET: PostPessoaDtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var postPessoaDto = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postPessoaDto == null)
            {
                return NotFound();
            }

            return View(postPessoaDto);
        }

        // GET: PostPessoaDtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostPessoaDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DtCadastro,nome,email,pais,dtNascimento,cidade,estado,cep,endereco,numero,bairro,complemento,cardownername,cardnumber,expirationdate,securitycode,Id")] PostPessoaDto postPessoaDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postPessoaDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postPessoaDto);
        }

        // GET: PostPessoaDtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var postPessoaDto = await _context.Posts.FindAsync(id);
            if (postPessoaDto == null)
            {
                return NotFound();
            }
            return View(postPessoaDto);
        }

        // POST: PostPessoaDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DtCadastro,nome,email,pais,dtNascimento,cidade,estado,cep,endereco,numero,bairro,complemento,cardownername,cardnumber,expirationdate,securitycode,Id")] PostPessoaDto postPessoaDto)
        {
            if (id != postPessoaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postPessoaDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostPessoaDtoExists(postPessoaDto.Id))
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
            return View(postPessoaDto);
        }

        // GET: PostPessoaDtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var postPessoaDto = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postPessoaDto == null)
            {
                return NotFound();
            }

            return View(postPessoaDto);
        }

        // POST: PostPessoaDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'AppDbContext.Posts'  is null.");
            }
            var postPessoaDto = await _context.Posts.FindAsync(id);
            if (postPessoaDto != null)
            {
                _context.Posts.Remove(postPessoaDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostPessoaDtoExists(int id)
        {
          return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
