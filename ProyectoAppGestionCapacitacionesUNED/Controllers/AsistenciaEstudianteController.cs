using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class AsistenciaEstudianteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AsistenciaEstudianteController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Confirmacion()
        {
            return View();

        }

        public IActionResult ConfirmacionActualizacion()
        {
            return View();

        }

        public IActionResult Create()
        {
            var Estudiante = Enumerable.Empty<RegistroEstudiante>().AsQueryable();
            return View(Estudiante);
        }

        [HttpPost]
        public IActionResult Create(string searchCodeA)
        {
            ViewBag.CurrentFilter = searchCodeA;

            var Estudiante = Enumerable.Empty<RegistroEstudiante>().AsQueryable();

            Estudiante = from b in _db.RegistroEstudiantes.Include(m => m.CapacitacionEstudiante) select b;
            Estudiante = Estudiante.Where(m => m.CapacitacionEstudiante.Codigo == searchCodeA);

            if (String.IsNullOrEmpty(searchCodeA))
            {
                return View(Estudiante);
            }
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCodeA))
            {
                if (Estudiante.Where(m => m.CapacitacionEstudiante.Codigo == searchCodeA).Any())
                {
                    return View(Estudiante);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha creado registros de estudiantes para este código");
                    return View(Estudiante);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(Estudiante);
            }

        }

        [HttpPost]
        public IActionResult Action(List<AsistenciaEstudiante> AsistenciaEstudiante)
        {
            if (AsistenciaEstudiante.Any())
            {
                var id = AsistenciaEstudiante[0].CapacitacionEstudianteID;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var eliminarRegistros = _db.AsistenciaEstudiantes.Where(c => c.CapacitacionEstudianteID == id).ToList();
                    _db.AsistenciaEstudiantes.RemoveRange(eliminarRegistros);

                    _db.AsistenciaEstudiantes.AddRange(AsistenciaEstudiante);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("ConfirmacionActualizacion", "AsistenciaEstudiante") });
                }
                else
                {
                    _db.AsistenciaEstudiantes.AddRange(AsistenciaEstudiante);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("Confirmacion", "AsistenciaEstudiante") });
                }

            }

            return Json(new { newUrl = Url.Action("Create", "AsistenciaEstudiante") });
        }
    }
}