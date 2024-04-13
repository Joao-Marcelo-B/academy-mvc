using Academy.Data;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Academy.Controllers
{
    public class AcademyController : Controller
    {
        private readonly AcademyContext _academy;

        public AcademyController(AcademyContext academy)
        {
            _academy = academy;
        }

        public ActionResult Index()
        {
            return View(_academy.Alunos.Include(x => x.Personal));
        }

        public IActionResult Details(int id)
        {
            var aluno = _academy.Alunos.Find(id);
            var treino = _academy.Treinos.Include(x => x.Aluno).Include(x => x.Exercicios).FirstOrDefault(x => x.AlunoId == id);

            return View(treino);
        }

        public IActionResult Create()
        {
            ViewBag.Personais = new SelectList(_academy.Personais.OrderBy(x => x.Nome) , "PersonalId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            _academy.Alunos.Add(aluno);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var aluno = _academy.Alunos.Find(id);
            ViewBag.Personais = new SelectList(_academy.Personais.OrderBy(x => x.Nome), "PersonalId", "Nome");
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit(Aluno aluno)
        {
            _academy.Alunos.Update(aluno);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var aluno = _academy.Alunos.Find(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Delete(Aluno aluno)
        {
            _academy.Alunos.Remove(aluno);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CreateTreinos()
        {
            ViewBag.Alunos = new SelectList(_academy.Alunos.OrderBy(x => x.Nome), "AlunoId", "Nome");
            ViewBag.Exercicios = new MultiSelectList(_academy.Exercicios.OrderBy(x => x.Nome), "ExercicioId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult CreateTreinos(Treino treino, int[] ExerciciosSelecionados)
        {
            treino.Exercicios = new List<Exercicio>();
            if (ExerciciosSelecionados != null)
            {
                foreach (var exercicioId in ExerciciosSelecionados)
                {
                    var exercicio = _academy.Exercicios.Find(exercicioId);
                    if (exercicio != null)
                    {
                        treino.Exercicios.Add(exercicio);
                    }
                }
            }

            _academy.Treinos.Add(treino);
            _academy.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTreinos(int id)
        {
            var treino = _academy.Treinos.Find(id);

            var alunoId = treino.AlunoId;

            _academy.Treinos.Remove(treino);
            _academy.SaveChanges();
            return RedirectToAction("Details", alunoId);
        }
    }
}
