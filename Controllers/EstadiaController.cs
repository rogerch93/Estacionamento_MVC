using EstacionamentoDotnet6.Data;
using EstacionamentoDotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoDotnet6.Controllers
{
    public class EstadiaController : Controller
    {
              private readonly Context _context;

        public EstadiaController(Context context)
        {
            _context = context;
        }

        // [HttpGet] // GET: Pessoa
        // public async Task <IActionResult> Index(string searchString)
        // {
        //     var estadia = from e in _context.Estadias
        //                   select e;
            
        //     if(!string.IsNullOrEmpty(searchString))
        //     {
        //         estadia = estadia.Where(e => e.NumVaga.Contains(searchString));
        //     }
        //     return View(estadia);
        // }

        //GET Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound("Estadia não encontrada");
            }

            var estadia = await _context.Estadias
                .FirstOrDefaultAsync(p => p.Id == id);
                if(estadia == null)
                {
                    return NotFound("Estadia não encontrada");
                }
                return View(estadia);
        }

        // GET: Pessoa/Create
        public IActionResult Estadia()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Estadia([Bind("NumVaga,HoraEntrada,HoraSaida")] Estadia estadia)
        {
            if(ModelState.IsValid)
            {
                _context.Add(estadia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadia);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound("Estadia Inexistente");
            }
            var estadia = await _context.Estadias.FindAsync(id);
            if(estadia == null)
            {
                return NotFound("Estadia Inexistente");
            }
            return View(estadia);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("NumVaga,HoraEntrada,HoraSaida")] Estadia estadia)
        {
            if(id != estadia.Id)
            {
                return NotFound("Estadia Inexistente");
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadia);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!EstadiaExists(estadia.Id))
                    {
                        return NotFound("Estadia Inexistente");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadia);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound("Estadia Inexistente");
            }

            var estadia = await _context.Estadias
                .FirstOrDefaultAsync(p => p.Id == id);
            if(estadia == null)
            {
                return NotFound("Estadia Inexistente");
            }
            return View(estadia);
        }

        private bool EstadiaExists(int Id)
        {
            return _context.Estadias.Any(e => e.Id == Id);
        }
    }
}
