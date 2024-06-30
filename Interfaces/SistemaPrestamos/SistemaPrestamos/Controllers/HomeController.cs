using SistemaPrestamos.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPrestamos.Models;
using System.Diagnostics;

namespace SistemaPrestamos.Controllers
{
    [Authorize]
    public class HomeController : ActionUserController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Encargado"))
            {
                return View("IndexEncargado");
            }
            else if (User.IsInRole("Alumno"))
            {
                return View("IndexAlumno");
            }

            // Si no tiene un rol v�lido, redirigir a una p�gina de error o login
            return RedirectToAction("Login", "Security");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
