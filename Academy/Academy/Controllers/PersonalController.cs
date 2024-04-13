using Academy.Data;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;

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

    }
}
