using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
        public IActionResult MenuEstudiante()
        {
            return View();
        }
        [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
        public IActionResult MenuPersonalAcademico()
        {
            return View();
        }
        [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
        public IActionResult MenuPersonalAdministrativo()
        {
            return View();
        }
    }
}
