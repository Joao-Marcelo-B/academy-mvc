using Academy.Data;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class ExercicioController : Controller
    {
        private readonly AcademyContext _academy;

        public ExercicioController(AcademyContext academy)
        {
            _academy = academy;
        }

        public IActionResult Index()
        {
            return View(_academy.Exercicios);
        }

        public IActionResult Details(int id)
        {
            var exercicio = _academy.Exercicios.Find(id);
            return View(exercicio);
        }

        public IActionResult Create() =>
            View();

        [HttpPost]
        public IActionResult Create(Exercicio exercicio)
        {
            _academy.Exercicios.Add(exercicio);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var exercicio = _academy.Exercicios.Find(id);
            _academy.Exercicios.Remove(exercicio);
            _academy.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var exercicio = _academy.Exercicios.Find(id);
            return View(exercicio);
        }

        [HttpPost]
        public IActionResult Edit(Exercicio exercicio)
        {
            _academy.Exercicios.Update(exercicio);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
