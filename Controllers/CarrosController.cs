using CrudAspNetCoreCodFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAspNetCoreCodFirst.Controllers
{
    public class CarrosController : Controller
    {
        private readonly Contexto _contexto;

        public CarrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(_contexto.Carros.ToList());
        }

        public IActionResult NovoCarro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NovoCarro(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(carro);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if (Id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(Id);
            return View(carro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Carro carro)
        {
            if (carro.Id == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _contexto.Update(carro);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        public IActionResult Detalhes(int Id)
        {
            if (Id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(Id);
            return View(carro);
        }

        [HttpGet]
        public IActionResult Excluir(int? Id)
        {
            if (Id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(Id);
            return View(carro);

        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int Id)
        {
            if (Id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(Id);
            _contexto.Remove(carro);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
