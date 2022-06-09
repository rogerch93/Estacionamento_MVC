using EstacionamentoDotnet6.Data;
using EstacionamentoDotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoDotnet6.Controllers
{
    public class PagamentosController : Controller
    {
                private readonly Context _context;

        public PagamentosController(Context context)
        {
            _context = context;
        }

        [HttpGet] // GET: Pessoa
        public async Task <IActionResult> Index(string searchDecimal)
        {
            return View();
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
        public IActionResult Pagamentos()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pagamentos([Bind("Pago,Total")] Pagamento pagamento)
        {
            if(ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamento);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound("Cliente Inexistente");
            }
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if(pagamento == null)
            {
                return NotFound("Cliente Inexistente");
            }
            return View(pagamento);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Pago,Total")] Pagamento pagamento)
        {
            if(id != pagamento.Id)
            {
                return NotFound("Não é possivel encontra");
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!PagamentoExists(pagamento.Id))
                    {
                        return NotFound("Não é possivel encontra");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pagamento);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound("Não é possivel encontra");
            }

            var pagamento = await _context.Pagamentos
                .FirstOrDefaultAsync(p => p.Id == id);
            if(pagamento == null)
            {
                return NotFound("Cliente Inexistente");
            }
            return View(pagamento);
        }

        private bool PagamentoExists(int Id)
        {
            return _context.Pagamentos.Any(p => p.Id == Id);
        }
    }
}
