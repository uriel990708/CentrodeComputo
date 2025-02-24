using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using GestorTareas.Data;
using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestorTareas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Página de login (GET)
        public IActionResult Login()
        {
            return View();
        }

        // ✅ Procesa el formulario de login (POST)
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // ✅ Cerrar sesión
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        // ✅ Página principal (Index)
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var tasks = _context.TodoTasks.ToList();
            var folders = _context.Folders.ToList(); // Obtener carpetas

            ViewBag.Folders = folders;
            return View(tasks);
        }


        // ✅ Agregar tareas
        [HttpPost]
        public IActionResult AddTask(string description, int? folderId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            if (!string.IsNullOrEmpty(description))
            {
                var todoTask = new TodoTask
                {
                    Description = description,
                    CreatedDate = DateTime.Now,
                    IsCompleted = false,
                    FolderId = folderId // Asociar la tarea con una carpeta si se proporciona
                };

                _context.TodoTasks.Add(todoTask);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }


        // ✅ Completar tarea
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = _context.TodoTasks.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // ✅ Eliminar tarea
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.TodoTasks.Find(id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
