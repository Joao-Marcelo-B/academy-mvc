using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class SessionController : Controller
    {
        private static List<Usuario> usuarios = new()
        {
            new()
            {
                Nome = "Admin",
                Email = "admin@admin.com",
                Senha = "admin"
            }
        };

        public IActionResult Index()
        {
            var acesso = HttpContext.Session.GetString("usuario_session");
            if(acesso == null)
                return RedirectToAction("Login");

            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuarios.Add(usuario);
            usuario.UsuarioId = usuarios.Select(u => u.UsuarioId).Max() + 1;
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var confirma = usuarios.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
            if(confirma != null)
            {
                HttpContext.Session.SetString("usuario_session", confirma.Nome);
                return RedirectToAction("Index", "Academy");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
 