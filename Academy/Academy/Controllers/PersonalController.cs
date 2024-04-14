using Academy.Data;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy.Controllers
{
    public class PersonalController : Controller
    {
        private readonly AcademyContext _academy;

        public PersonalController(AcademyContext academy)
        {
            _academy = academy;
        }

        public IActionResult Index()
        {
            return View(_academy.Personais);
        }

        public IActionResult Create() =>
            View();

        [HttpPost]
        public IActionResult Create(Personal personal)
        {
            _academy.Personais.Add(personal);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var personal = _academy.Personais.Include(x => x.Alunos).FirstOrDefault(x => x.PersonalId == id);
            return View(personal);
        }

        public IActionResult Delete(int id)
        {
            var personal = _academy.Personais.Find(id);
            _academy.Personais.Remove(personal);
            _academy.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var personal = _academy.Personais.Find(id);
            return View(personal);
        }

        [HttpPost]
        public IActionResult Edit(Personal personal)
        {
            _academy.Personais.Update(personal);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
