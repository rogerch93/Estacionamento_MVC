using EstacionamentoDotnet6.Data;
using EstacionamentoDotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoDotnet6.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Context _context;

        public PessoaController(Context context)
        {
            _context = context;
        }

        [HttpGet] // GET: Pessoa
        public async Task <IActionResult> Index(string searchString)
        {
            var pessoas = from p in _context.Pessoas
                          select p;
            
            if(!string.IsNullOrEmpty(searchString))
            {
                pessoas = pessoas.Where(p => p.Nome.Contains(searchString));
            }
            return View(pessoas);
        }

        //GET Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(p => p.PessoaId == id);
                if(pessoa == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                return View(pessoa);
        }

        // GET: Pessoa/Create
        public IActionResult Pessoa()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pessoa([Bind("PessoaId,Nome,CPF")] Pessoa pessoa)
        {
            if(ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound("Cliente Inexistente");
            }
            var pessoa = await _context.Pessoas.FindAsync(id);
            if(pessoa == null)
            {
                return NotFound("Cliente Inexistente");
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("PessoaId,Nome,CPF")] Pessoa pessoa)
        {
            if(id != pessoa.PessoaId)
            {
                return NotFound("Cliente Inexistente");
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!PessoaExists(pessoa.PessoaId))
                    {
                        return NotFound("Cliente Inexistente");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound("Cliente Inexistente");
            }

            var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(p => p.PessoaId == id);
            if(pessoa == null)
            {
                return NotFound("Cliente Inexistente");
            }
            return View(pessoa);
        }

        private bool PessoaExists(int pessoaId)
        {
            return _context.Pessoas.Any(p => p.PessoaId == pessoaId);
        }
    }
}