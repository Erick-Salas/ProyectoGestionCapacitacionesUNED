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
    public class AsistenciaPersonalAdministrativoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AsistenciaPersonalAdministrativoController(ApplicationDbContext db)
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
            var PersonalAdministrativo = Enumerable.Empty<RegistroPersonalAdministrativo>().AsQueryable();
            return View(PersonalAdministrativo);
        }

        [HttpPost]
        public IActionResult Create(string searchCodeA)
        {
            ViewBag.CurrentFilter = searchCodeA;

            var PersonalAdministrativo = Enumerable.Empty<RegistroPersonalAdministrativo>().AsQueryable();

            PersonalAdministrativo = from b in _db.RegistroPersonalAdministrativos.Include(m => m.CapacitacionPersonalAdministrativo) select b;
            PersonalAdministrativo = PersonalAdministrativo.Where(m => m.CapacitacionPersonalAdministrativo.Codigo == searchCodeA);

            if (String.IsNullOrEmpty(searchCodeA))
            {
                return View(PersonalAdministrativo);
            }
            if (_db.CapacitacionPersonalAdministrativos.Any(c => c.Codigo == searchCodeA))
            {
                if (PersonalAdministrativo.Where(m => m.CapacitacionPersonalAdministrativo.Codigo == searchCodeA).Any())
                {
                    return View(PersonalAdministrativo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha creado registros de personal académico para este código");
                    return View(PersonalAdministrativo);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(PersonalAdministrativo);
            }

        }

        [HttpPost]
        public IActionResult Action(List<AsistenciaPersonalAdministrativo> AsistenciaPersonalAdministrativo)
        {
            if (AsistenciaPersonalAdministrativo.Any())
            {
                var id = AsistenciaPersonalAdministrativo[0].CapacitacionPersonalAdministrativoID;
                if (_db.AsistenciaPersonalAdministrativos.Any(c => c.CapacitacionPersonalAdministrativoID == id))
                {
                    var eliminarRegistros = _db.AsistenciaPersonalAdministrativos.Where(c => c.CapacitacionPersonalAdministrativoID == id).ToList();
                    _db.AsistenciaPersonalAdministrativos.RemoveRange(eliminarRegistros);

                    _db.AsistenciaPersonalAdministrativos.AddRange(AsistenciaPersonalAdministrativo);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("ConfirmacionActualizacion", "AsistenciaPersonalAdministrativo") });
                }
                else
                {
                    _db.AsistenciaPersonalAdministrativos.AddRange(AsistenciaPersonalAdministrativo);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("Confirmacion", "AsistenciaPersonalAdministrativo") });
                }

            }

            return Json(new { newUrl = Url.Action("Create", "AsistenciaPersonalAdministrativo") });
        }
    }
}