using EstacionamentoDotnet6.Data;
using EstacionamentoDotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoDotnet6.Controllers
{
    public class CarroController : Controller
    {
        private readonly Context _context;
        
        public CarroController(Context context)
        {
            _context = context;     
        }

        
        [HttpGet] // GET: Carro
        public async Task <IActionResult> Index(string searchString)
        {
            var carros = from c in _context.Carros
                            select c;

            if(!string.IsNullOrEmpty(searchString))
            {
                carros = carros.Where(c => c.Placa.Contains(searchString));
            }
            return View(carros);
        }

        //GET Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound("Carro não encontrado");
            }

            var carro = await _context.Carros
                .FirstOrDefaultAsync(c => c.CarroId == id);
                if(carro == null)
                {
                    return NotFound("Carro não encontrado");
                }
                return View(carro);

        }

        // GET: Carro/Create
        public IActionResult Carro()
        {
            return View();
        }

        // POST: Carro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Carro([Bind("CarroId,NomeCarro,Modelo,Placa,Marca")] Carro carro)
        {
            if(ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return NotFound("Carro não encontrado");
            }
            var carro = await _context.Carros.FindAsync(id);
            if(carro == null)
            {
                return NotFound("Carro não encontrado");
            }

            return View(carro);
        }

        // POST: Carro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("CarroId,NomeCarro,Modelo,Marca")] Carro carro)
        {
            if(id != carro.CarroId)
            {
                return NotFound("Carro não encontrado");
            }
            
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!CarroExists(carro.CarroId))
                    {
                        return NotFound("Carro não encontrado");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound("Carro não encontrado");
            }
            var carro = await _context.Carros
                .FirstOrDefaultAsync(c => c.CarroId == id);

            if (carro == null)
            {
                return NotFound("Carro não encontrado");
            }    
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int carroId)
        {
            return _context.Carros.Any(c => c.CarroId == carroId);
        }
    }
   
}