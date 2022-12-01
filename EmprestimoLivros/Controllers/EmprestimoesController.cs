using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using EmprestimoLivros.Migrations;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoesController : Controller
    {
        private readonly EmprestimoLivrosContext _context;

        public EmprestimoesController(EmprestimoLivrosContext context)
        {
            _context = context;
        }

        // GET: Emprestimoes
        public async Task<IActionResult> Index()
        {
            var emprestimoLivrosContext = _context.Emprestimo.Include(e => e.Cliente).Include(e => e.Livro);
            return View(await emprestimoLivrosContext.ToListAsync());
        }

        // GET: Emprestimoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Cliente)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.EmprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "Titulo");
            return View();
        }

        // POST: Emprestimoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmprestimoId,DtEmpretimo,DtDevolucao,LivroId,ClienteId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", emprestimo.ClienteId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "Titulo", emprestimo.LivroId);


            return View(emprestimo);
            

        }

        // GET: Emprestimoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", emprestimo.ClienteId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "Titulo", emprestimo.LivroId);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmprestimoId,DtEmpretimo,DtDevolucao,LivroId,ClienteId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.EmprestimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.EmprestimoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Nome", emprestimo.ClienteId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "Titulo", emprestimo.LivroId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Cliente)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.EmprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emprestimo == null)
            {
                return Problem("Entity set 'EmprestimoLivrosContext.Emprestimo'  is null.");
            }
            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimo.Remove(emprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
          return _context.Emprestimo.Any(e => e.EmprestimoId == id);
        }
    }
}
